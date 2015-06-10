using MEASDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEASService.Service
{
    public class UserInfo
    {
        private UnitOfWork _unitOfWork = null;
        public UserInfo()
        {
            _unitOfWork = new UnitOfWork();
        }
        public List<MEASModel.DBModel.MemberInfo> GetUserRecords(int pageIndex, int pageSize, out int pageTotalCount)
        {
            pageTotalCount = _unitOfWork.UserRepository.Query().Count();
            var userList = _unitOfWork.UserRepository.Query().OrderBy(s => s.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            if(userList!=null && userList.Count>0)
            {
                return userList;
            }
            return null;
        }
        public MEASModel.DBModel.MemberInfo GetUserInfoByID(int id)
        {
            var userModel = _unitOfWork.UserRepository.Query().Where(s => s.Id == id).FirstOrDefault();
            return userModel;
        }



        /// <summary>
        /// 更新用户的订阅主题
        /// </summary>
        /// <param name="memberModel"></param>
        /// <param name="groupIds">订阅的topic数组</param>
        /// <returns></returns>
        public bool UpdateUserTopic(int memberId, int[] groupIds)
        {
            ////1.先把原来订阅的主题给删除掉
            //var userModel = _unitOfWork.UserRepository.Query().Where(s => s.Id == memberId).FirstOrDefault();
            //userModel.Topic.Clear();
            ////2.把新的主题添加上
            //foreach (var topicId in groupIds)
            //{
            //    var topic = _unitOfWork.TopicRepository.Query().FirstOrDefault(s => s.Id == topicId);
            //    userModel.Topic.Add(topic);
            //}
            //_unitOfWork.Commit();
            return true;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="memberPwd"></param>
        /// <returns></returns>
        public MEASModel.DBModel.MemberInfo Login(string memberID, string memberPwd)
        {
            MEASModel.DBModel.MemberInfo dbModel = null;
            if (!string.IsNullOrWhiteSpace(memberID) && !string.IsNullOrWhiteSpace(memberPwd))
            {
                var model = _unitOfWork.UserRepository.Query().FirstOrDefault(s => s.MemberId == memberID);
                if (model != null)
                {
                    if (model.MemberPwd == memberPwd)
                    {
                        dbModel = model;
                    }
                }
            }
            return dbModel;
        }


        public List<string> GetAllTopicByMemberID(string memberID)
        {
            var groupIDs = _unitOfWork.UserRepository.Query().FirstOrDefault(s => s.MemberId == memberID).GroupInfo.Select(s => s.Id).ToList();
            List<string> topic = new List<string>();
            if(groupIDs!=null && groupIDs.Count>0)
            {
                foreach(var item in groupIDs)
                {
                    var topicList = _unitOfWork.GroupeRepository.Query().FirstOrDefault(s => s.Id == item).Topic.Select(s => s.TopicMethod).ToList();

                    topic.AddRange(topicList);
                }
            }
            return topic;
        }
    }
}
