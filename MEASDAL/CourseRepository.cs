using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEASModel.DBModel;
using System.Data.Entity;
namespace MEASDAL
{
    public class CourseRepository:RepositoryBase<Course>
    {
        public CourseRepository(DbContext context)
            : base(context)
        {

        }
    }
}
