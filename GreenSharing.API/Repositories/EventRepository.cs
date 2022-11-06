using GreenSharing.API.Repositories.DataAccessLayer;
using GreenSharing.API.Repositories.DataAccessLayer.Models;
using GreenSharing.API.Repositories.Interface;

namespace GreenSharing.API.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {

        public EventRepository(GreenSharingContext context) : base(context)
        {

        }
    }
}
