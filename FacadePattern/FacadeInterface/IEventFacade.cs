using BookReadingApp.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.FacadeInterface
{
    public interface IEventFacade
    {
        Task<IList<Event>> GetEvents();
        Task<Event> ViewDetails(int eventId);

        Task<int> CreateEvent(Event eventModel);
        int UpdateEvent(Event eventModel);

        Task<IList<Event>> MyEvents(string organiser);

        Task<IList<Comment>> GetAllCommentByEventId(int eventId);

    }
}
