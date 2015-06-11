using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MEASApi.Controllers
{
    public class StudentController : ApiController
    {
        MEASService.Service.UserInfo iMemberInforService = new MEASService.Service.UserInfo();
        MEASService.Service.TopicInfo iTopicInforService = new MEASService.Service.TopicInfo();
        MEASService.Service.CourseInfo iCourseInfoService = new MEASService.Service.CourseInfo();
        public Result UserLogin([FromBody]Student stu)
        {
            Result res = new Result();
            var resultModel = iMemberInforService.Login(stu.sNo, stu.sPwd);
            if (resultModel != null)
            {
                res.ErrorCode = 0;
                res.Message = "登录成功";
                var topic = iMemberInforService.GetAllTopicByMemberID(stu.sNo);
                res.Data = new Memeber { SName = resultModel.SName, MemberId = resultModel.MemberId, MemberPwd = resultModel.MemberPwd, TopicList = topic,ImageUrl = resultModel.ImageUrl };
            }
            else
            {
                res.ErrorCode = 1;
                res.Message = "登录失败";
                res.Data = null;
            }

            return res;
        }

        [HttpPost]
        public Models.CourseInfoResult GetCourseList(Models.ParameterModel.CourseInfoParameterModel model)
        {
            Models.CourseInfoResult result = new Models.CourseInfoResult() { ErrorCode = 0, Message = "获取成功" };
            try
            {
                var courseList = iCourseInfoService.GetCourseInfoById(model.MemberId, model.Week);
                if (courseList != null && courseList.Count > 0)
                {
                    var temp = courseList.Select(s => new Models.CourseInfoModel
                    {
                        id = s.id,
                        startSection = s.startSection,
                        classroom = s.classroom,
                        courseName = s.courseName,
                        dayOfWeek = s.dayOfWeek,
                        endSection = s.endSection,
                        endWeek = s.endWeek,
                        endYear = s.endYear,
                        everyWeek = s.everyWeek,
                        semester = s.semester,
                        startWeek = s.startWeek,
                        startYear = s.startYear,
                        teacher = s.teacher,
                    }).ToList();
                    result.Data.courseList = temp;
                }
                else
                {
                    result.Data.courseList = null;
                }

            }
            catch (Exception ex)
            {
                result.ErrorCode = 1;
                result.Message = ex.Message;
                result.Data.courseList = null;
            }
            return result;


        }



    }

    public class Result
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }

        public Memeber Data { get; set; }


    }

    public class Memeber
    {
        public string MemberId { get; set; }

        public string SName { get; set; }

        public string MemberPwd { get; set; }

        public string ImageUrl { get; set; }

        public List<string> TopicList { get; set; }

    }

    public class Student
    {
        public string sNo { get; set; }
        public string sPwd { get; set; }
    }



}