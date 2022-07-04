using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oferton.WebExceptionsPresenter
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);

    }
}
