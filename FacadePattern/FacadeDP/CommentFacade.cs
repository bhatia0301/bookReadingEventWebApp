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
    public class CommentFacade : ICommentFacade
    {
        private readonly ICommentRepository _commentRepo;
        public CommentFacade(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }



        public async Task<IList<Comment>> GetComments()
        {
            var result = await _commentRepo.GetComments();
            return result;
        }

        public async Task<int> PostComment(Comment response)
        {
            var result = await _commentRepo.PostComment(response);
            return result;
        }

        public async Task<Comment> ViewComment(int commentId)
        {
            var result = await _commentRepo.ViewComment(commentId);
            return result;
        }

    }
}
