using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASApi.Models
{
    public class CourseInfoResult : BaseResult
    {
        public CourseInfoResult()
        {
            Data = new CourseData();
        }
        public CourseData Data { get; set; }
    }

    public class CourseData
    {
        public CourseData()
        {
            courseList = new List<CourseInfoModel>();
        }
        public List<CourseInfoModel> courseList { get; set; }
    }

    public class CourseInfoModel
    {
        public int id { get; set; }

        public int startYear { get; set; }
        public int endYear { get; set; }
        public int semester { get; set; }

        public string courseName { get; set; }

        public string classroom { get; set; }
        public string teacher { get; set; }

        public int dayOfWeek { get; set; }
        public int startSection { get; set; }
        public int endSection { get; set; }
        public int startWeek { get; set; }

        public int endWeek { get; set; }

        public int everyWeek { get; set; }
    }
}