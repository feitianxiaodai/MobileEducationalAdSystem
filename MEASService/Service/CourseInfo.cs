using MEASDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEASModel.DBModel;
namespace MEASService.Service
{
    public class CourseInfo
    {
        private UnitOfWork _unitOfWork = null;
        public CourseInfo()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<Course> GetCourseInfoById(string memberID, int week)
        {
            List<Course> courseList = null;
            var user = _unitOfWork.UserRepository.Query().FirstOrDefault(s => s.MemberId == memberID);
            if (user != null)
            {
                courseList = user.Course.Where(s => s.startWeek <= week && s.endWeek >= week 
                                        && ((week % 2 == 0) ? (s.everyWeek == 0 || s.everyWeek == 2) : (s.everyWeek == 0 || s.everyWeek == 1)))
                                        .ToList();
            }
            return courseList;
        }

    }
}
