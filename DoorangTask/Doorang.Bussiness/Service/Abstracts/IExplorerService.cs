using Doorang.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorang.Bussiness.Service.Abstracts
{
    public  interface IExplorerService
    {
        void AddExplorer(Explorer explorer);
        void RemoveExplorer(int id);
        void Update(int id, Explorer explorer);
        Explorer GetExplorer(Func<Explorer, bool>? func = null);
        List<Explorer> GetAllExplorer(Func<Explorer,bool>? func=null);

    }
}
