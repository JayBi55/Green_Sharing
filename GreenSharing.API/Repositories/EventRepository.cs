using GreenSharing.API.Models;
using GreenSharing.API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {

        public EventRepository(GreenSharingContext context) : base(context)
        {

        }
    }
}
