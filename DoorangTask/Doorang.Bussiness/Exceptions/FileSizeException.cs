using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorang.Bussiness.Exceptions
{
    public  class FileSizeException: Exception
    {
        public FileSizeException( string propertName,string? message) : base(message)
        {
            PropertyName = propertName;
        }

        public string PropertyName {  get; set; }
    }
}
