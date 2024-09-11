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
    public class Facade : IFacade
    {
        private readonly ICommentFacade commentFacade;
        private readonly IEventFacade eventFacade;

        private readonly ICommentRepository _commentRepo;
        private readonly IEventRepository _eventRepo;

        public Facade(ICommentRepository commentRepo, IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
            _commentRepo = commentRepo;

            commentFacade = new CommentFacade(_commentRepo);
            eventFacade = new EventFacade(_eventRepo);


        }

        public async Task<int> CreateEvent(Event eventModel)
        {
            var result = await eventFacade.CreateEvent(eventModel);
            return result;
        }



        public async Task<IList<Comment>> GetAllCommentByEventId(int eventId)
        {
            var result = await eventFacade.GetAllCommentByEventId(eventId);
            return result;
        }

        public async Task<IList<Comment>> GetComments()
        {
            var result = await commentFacade.GetComments();
            return result;

        }

        public async Task<IList<Event>> GetEvents()
        {
            var result = await eventFacade.GetEvents();
            return result;
        }

        public async Task<IList<Event>> MyEvents(string organiser)
        {
            var result = await eventFacade.MyEvents(organiser);
            return result;
        }

        public async Task<int> PostComment(Comment response)
        {
            var result = await commentFacade.PostComment(response);
            return result;

        }

        public int UpdateEvent(Event eventModel)
        {
            var result = eventFacade.UpdateEvent(eventModel);
            return result;
        }

        public async Task<Comment> ViewComment(int commentId)
        {
            var result = await commentFacade.ViewComment(commentId);
            return result;

        }

        public async Task<Event> ViewDetails(int eventId)
        {
            var result = await eventFacade.ViewDetails(eventId);
            return result;
        }
    }
}
