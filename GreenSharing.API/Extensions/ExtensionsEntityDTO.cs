using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GreenSharing.API.Extensions
{
    public static class ExtensionsEntityDTO
    {
        #region Generic

        /// <summary>
        /// Copies an object onto another
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static T Copy<T>(this T entity)
            where T : class
        {
            if (entity == null) throw new Exception(nameof(T));
            T copy = Activator.CreateInstance<T>();

            try
            {
                foreach (PropertyInfo property in (typeof(T)).GetProperties())
                {
                    if (property.CanWrite)
                    {
                        property.SetValue(copy, property.GetValue(entity));
                    }
                }

                return copy;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Generic method to produce DTOs. (Every DTO Property has to be present in the BASE entity)
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TDTO"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TDTO ToDTO<TEntity, TDTO>(this TEntity entity)
            where TEntity : class
            where TDTO : class
        {
            try
            {
                if (entity == null) throw new Exception(nameof(TEntity));

                TDTO dto = Activator.CreateInstance<TDTO>();

                //For each property of the class P(DTO/OUTPUT)
                //WHERE (For each of those properties) =>
                //For
                //If the entity has a property with the SAME NAME and that property is NOT NULL
                foreach (PropertyInfo dtoPropertyInfo in (typeof(TDTO)).GetProperties().Where(x => typeof(TEntity).GetProperty(x.Name) != null))
                {
                    if (dtoPropertyInfo.GetSetMethod() != null)
                    {
                        //TODO: enhancement. Later on find a way to add Properties attributes required by dto ?
                        var entityPropertyInfo = typeof(TEntity).GetProperty(dtoPropertyInfo.Name);
                        if (dtoPropertyInfo.CanWrite)
                        {
                            dtoPropertyInfo.SetValue(dto, entityPropertyInfo.GetValue(entity));
                        }
                    }
                }

                return dto;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Generic method to produce an entity from a dto. Since its not using a base, this is more for creation and such.
        /// </summary>
        /// <typeparam name="TDTO"></typeparam>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static TEntity ToEntity<TDTO, TEntity>(this TDTO dto)
            where TEntity : class
            where TDTO : class
        {
            try
            {
                if (dto == null) throw new Exception(nameof(TEntity));

                TEntity entity = Activator.CreateInstance<TEntity>();

                foreach (PropertyInfo dtoProperty in typeof(TDTO).GetProperties())
                {
                    if (dtoProperty.GetValue(dto) != null && entity.HasProperty(dtoProperty.Name))
                    {
                        PropertyInfo entityProperty = typeof(TEntity).GetProperty(dtoProperty.Name);
                        var isMapped = !entityProperty.GetCustomAttributes(typeof(NotMappedAttribute)).Any();
                        if (isMapped)
                        {
                            entityProperty.SetValue(entity, dtoProperty.GetValue(dto));
                        }
                    }
                }

                return entity;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Generic method to produce a list of DTOs from a list of Entities.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TDTO"></typeparam>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public static List<TDTO> ToDTOList<TEntity, TDTO>(this IEnumerable<TEntity> entityList)
            where TEntity : class
            where TDTO : class
        {
            try
            {
                if (entityList == null) throw new Exception(nameof(List<TEntity>));

                List<TDTO> dtoList = Activator.CreateInstance<List<TDTO>>();

                foreach (TEntity entity in entityList)
                {
                    dtoList.Add(entity.ToDTO<TEntity, TDTO>());
                }

                return dtoList;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        #endregion

        #region Having some Custom treatement

        /// <summary>
        /// Gets all differences between two objects of the same class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseEntity"></param>
        /// <param name="updatedEntity"></param>
        /// <returns></returns>
        public static string UpdateDifferences<T>(this T baseEntity, T updatedEntity)
            where T : class
        {
            //start with an empty String
            var differences = string.Empty;

            try
            {
                if (baseEntity == null) throw new Exception(nameof(T));

                //For exception details
                string propertyName = String.Empty;
                string value1 = String.Empty;
                string value2 = String.Empty;


                //check every property for differences
                foreach (PropertyInfo property in (typeof(T)).GetProperties())
                {
                    propertyName = property.Name;

                    value1 = property.GetValue(baseEntity) != null ? property.GetValue(baseEntity).ToString() : "null";

                    value2 = property.GetValue(updatedEntity) != null ? property.GetValue(updatedEntity).ToString() : "null";

                    if (value1 != value2)
                    {
                        differences += string.Format("Old :{0}={1}** New :{0}={2}*!*!", propertyName, value1, value2);
                    }
                }

                //if no differences, enter key for no changes
                if (string.IsNullOrWhiteSpace(differences))
                {
                    differences = "NoChangesUpdate";
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return differences;
        }

        public static TEntity ToNewEntity<TDTO, TEntity>(this TDTO dto)
            where TEntity : class
            where TDTO : class
        {
            TEntity entity;

            try
            {
                if (dto == null) throw new Exception(nameof(TEntity));

                entity = Activator.CreateInstance<TEntity>();

                foreach (PropertyInfo dtoProperty in typeof(TDTO).GetProperties())
                {
                    if (typeof(TEntity).GetProperty(dtoProperty.Name) != null)
                    {
                        if (dtoProperty.GetValue(dto) != null)
                        {
                            PropertyInfo entityProperty = typeof(TEntity).GetProperty(dtoProperty.Name);
                            var isMapped = !entityProperty.GetCustomAttributes(typeof(NotMappedAttribute)).Any();
                            if (isMapped)
                            {
                                entityProperty.SetValue(entity, dtoProperty.GetValue(dto));
                            }
                        }
                    }
                }

                if (entity.HasProperty("IsActive"))
                {
                    PropertyInfo isActive = typeof(TEntity).GetProperty("IsActive");
                    isActive.SetValue(entity, true);
                }
                if (entity.HasProperty("CreationDate"))
                {
                    PropertyInfo creationDate = typeof(TEntity).GetProperty("CreationDate");
                    creationDate.SetValue(entity, DateTime.UtcNow);
                }
                if (entity.HasProperty("Id"))
                {
                    PropertyInfo id = typeof(TEntity).GetProperty("Id");
                    if (id.PropertyType == typeof(Guid))
                    {
                        id.SetValue(entity, Guid.Empty);
                    }
                }
                if (entity.HasProperty("DateOfAction"))
                {
                    PropertyInfo dateOfAction = typeof(TEntity).GetProperty("DateOfAction");
                    dateOfAction.SetValue(entity, DateTime.UtcNow);
                }
                if (entity.HasProperty("IsDeleted"))
                {
                    PropertyInfo isDeleted = typeof(TEntity).GetProperty("IsDeleted");
                    isDeleted.SetValue(entity, false);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return entity;
        }

        /// <summary>
        /// Generic method to produce Entities. This one is more for updates, which is why we use a base, to make sure no info is lost.
        /// </summary>
        /// <typeparam name="TDTO"></typeparam>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dto"></param>
        /// <param name="baseEntity"></param>
        /// <returns></returns>
        public static TEntity ToEntityWithBase<TDTO, TEntity>(this TDTO dto, TEntity baseEntity)
            where TEntity : class
            where TDTO : class
        {
            TEntity entity;
            try
            {
                if (dto == null) throw new Exception(nameof(TEntity));

                entity = Activator.CreateInstance<TEntity>();

                //TODO: Manage Primary-Key : Id, we shouldn`t never override it with !!!
                if (baseEntity.HasProperty("Id"))
                {
                    PropertyInfo idProperty = typeof(TEntity).GetProperty("Id");
                    idProperty.SetValue(entity, idProperty.GetValue(baseEntity));
                }
                if (baseEntity.HasProperty("IsActive"))
                {
                    PropertyInfo isActiveProperty = typeof(TEntity).GetProperty("IsActive");
                    isActiveProperty.SetValue(entity, isActiveProperty.GetValue(baseEntity));
                }
                if (baseEntity.HasProperty("CreationDate"))
                {
                    PropertyInfo creationDateProperty = typeof(TEntity).GetProperty("CreationDate");
                    creationDateProperty.SetValue(entity, creationDateProperty.GetValue(baseEntity));
                }
                if (baseEntity.HasProperty("ClosingDate"))
                {
                    PropertyInfo closingDateProperty = typeof(TEntity).GetProperty("ClosingDate");
                    closingDateProperty.SetValue(entity, closingDateProperty.GetValue(baseEntity));
                }
                if (baseEntity.HasProperty("DateOfAction"))
                {
                    PropertyInfo dateOfActionProperty = typeof(TEntity).GetProperty("DateOfAction");
                    dateOfActionProperty.SetValue(entity, dateOfActionProperty.GetValue(baseEntity));
                }

                foreach (PropertyInfo dtoProperty in (typeof(TDTO)).GetProperties())
                {
                    PropertyInfo entityProperty = typeof(TEntity).GetProperty(dtoProperty.Name);
                    var isNull = entityProperty == null;

                    if (isNull)
                    {
                        continue;
                    }
                    var isMapped = !entityProperty.GetCustomAttributes(typeof(NotMappedAttribute)).Any();
                    if (!isMapped)
                    {
                        continue;
                    }
                    if ((dtoProperty.Name != "Id" || dtoProperty.Name != "CreationDate") && dtoProperty.GetValue(dto) != null && baseEntity.HasProperty(dtoProperty.Name))
                    {
                        entityProperty = typeof(TEntity).GetProperty(dtoProperty.Name);
                        entityProperty.SetValue(entity, dtoProperty.GetValue(dto));
                    }
                    else if ((dtoProperty.Name != "Id" || dtoProperty.Name != "CreationDate") && dtoProperty.GetValue(dto) == null && baseEntity.HasProperty(dtoProperty.Name))
                    {
                        entityProperty = typeof(TEntity).GetProperty(dtoProperty.Name);
                        entityProperty.SetValue(entity, (typeof(TEntity).GetProperty(dtoProperty.Name)).GetValue(baseEntity));
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return entity;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Generic method to get all property names and values as one big string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string GetPropertyInfos<T>(this T entity)
            where T : class
        {
            try
            {
                string propertyInfo = string.Empty;
                string value = string.Empty;

                foreach (PropertyInfo entityProperty in typeof(T).GetProperties())
                {
                    if (entityProperty.GetValue(entity) != null)
                    {
                        value = entityProperty.GetValue(entity).ToString();
                    }
                    else
                    {
                        value = "Null";
                    }
                    propertyInfo += String.Format("Property name :{0} - Value :{1}______", entityProperty.Name, value);
                }

                return propertyInfo;
            }
            catch (Exception e)
            {
                throw ;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool HasProperty(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }
        #endregion
    }
}
