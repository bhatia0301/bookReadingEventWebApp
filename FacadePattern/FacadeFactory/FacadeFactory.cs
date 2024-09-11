using BookReadingApp.Application.Interfaces;
using FacadePattern.FacadeDP;
using FacadePattern.FacadeFactoryInterface;
using FacadePattern.FacadeInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.FacadeFactory
{
    public class FacadeFactory : IFacadeFactory
    {
        private readonly IEventRepository _eventRepo;
        private readonly ICommentRepository _commentRepo;

        public FacadeFactory(IEventRepository eventRepo, ICommentRepository commentRepo)
        {
            _eventRepo = eventRepo;
            _commentRepo = commentRepo;
        }
        public IFacade Create()
        {

            IFacade facade = new Facade(_commentRepo, _eventRepo);
            return facade;
        }
    }
}
