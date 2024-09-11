using BookReadingApp.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.FacadeInterface
{
    public interface ICommentFacade
    {
        Task<int> PostComment(Comment response);

        Task<IList<Comment>> GetComments();

        Task<Comment> ViewComment(int commentId);

    }
}
