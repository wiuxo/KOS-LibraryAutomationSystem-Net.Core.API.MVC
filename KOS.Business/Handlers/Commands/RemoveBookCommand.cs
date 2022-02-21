using KOS.Core.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOS.Business.Handlers.Commands
{
    public class RemoveBookCommand : IRequest<IResponse>
    {
        public int BookID { get; set; }
    }
}
