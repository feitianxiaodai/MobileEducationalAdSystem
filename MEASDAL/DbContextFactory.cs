using MEASModel.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MEASDAL
{
    public static class DbContextFactory
    {
        public static DbContext CreateDbContext()
        {
            //线程内实例唯一
            DbContext db = (DbContext)HttpContext.Current.Items["DbContext"];
            if (db == null)
            {
                db = new MEASEntities();
                HttpContext.Current.Items.Add("DbContext", db);
            }
            return db;
        }
    }
}
