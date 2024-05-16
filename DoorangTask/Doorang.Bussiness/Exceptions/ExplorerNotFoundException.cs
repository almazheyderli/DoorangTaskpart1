using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorang.Bussiness.Exceptions
{
    public class ExplorerNotFoundException : Exception
    {
        public ExplorerNotFoundException(string? message) : base(message)
        {
        }
    }
}
