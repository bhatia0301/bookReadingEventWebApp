using BookReadingApp.Core.Modals;
using CustomExceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomExceptions.Validators
{
    public class CustomCommentValidator
    {
        public static void Validate(Comment comments)
        {
            if (comments.comment == null)
            {
                throw new CustomCommentException($"{nameof(comments)}is null");
            }

        }
    }
}
