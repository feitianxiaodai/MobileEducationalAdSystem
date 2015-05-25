using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEASModel.DBModel;
using System.Data.Entity;
namespace MEASDAL
{
    public class NewsRepository:RepositoryBase<NewsInfo>
    {
        public NewsRepository(DbContext context)
            : base(context)
        {

        }
    }
}
