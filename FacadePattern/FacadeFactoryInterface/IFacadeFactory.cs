using FacadePattern.FacadeInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.FacadeFactoryInterface
{
    public interface IFacadeFactory
    {
        IFacade Create();
    }
}
