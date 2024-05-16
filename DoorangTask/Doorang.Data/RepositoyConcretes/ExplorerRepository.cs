using Doorang.Core.Models;
using Doorang.Core.RepositoryAbstracts;
using Doorang.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorang.Data.RepositoyConcretes
{
    public class ExplorerRepository : GenericRepository<Explorer>, IExplorerRepository
    {
        public ExplorerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
