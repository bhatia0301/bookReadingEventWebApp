using BookReadingApp.Application.Interfaces;
using BookReadingApp.Core.Modals;
using FacadePattern.FacadeInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.FacadeDP
{
    public class EventFacade : IEventFacade
    {
        private readonly IEventRepository _eventRepo;

        public EventFacade(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        public async Task<int> CreateEvent(Event eventModel)
        {
            var result = await _eventRepo.CreateEvent(eventModel);
            return result;
        }

        public async Task<IList<Comment>> GetAllCommentByEventId(int eventId)
        {
            var result = await _eventRepo.GetAllCommentByEventId(eventId);
            return result;

        }

        public async Task<IList<Event>> GetEvents()
        {
            var result = await _eventRepo.GetEvents();
            return result;
        }

        public async Task<IList<Event>> MyEvents(string organiser)
        {
            var result = await _eventRepo.MyEvents(organiser);
            return result;
        }

        public int UpdateEvent(Event eventModel)
        {
            var result = _eventRepo.UpdateEvent(eventModel);
            return result;
        }

        public async Task<Event> ViewDetails(int eventId)
        {
            var result = await _eventRepo.ViewDetails(eventId);
            return result;
        }
    }
}
