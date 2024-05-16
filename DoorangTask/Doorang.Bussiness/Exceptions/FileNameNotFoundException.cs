using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorang.Bussiness.Exceptions
{
    public  class FileNameNotFoundException:Exception
    {
        public FileNameNotFoundException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; set; }   
    
    }
}
