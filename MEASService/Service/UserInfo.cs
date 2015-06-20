﻿using MEASDAL;
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
            if (userList != null && userList.Count > 0)
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

        #region 1.0 删除用户
        public bool DeleteUserByIds(int[] ids)
        {
            try
            {
                if (ids.Count() > 0)
                {
                    for (int i = 0; i < ids.Count(); i++)
                    {
                        int id = ids[i];
                        var user = _unitOfWork.UserRepository.Query().FirstOrDefault(s => s.Id == id);
                        if (user != null)
                        {
                            user.IsDel = 1;
                        }
                    }
                    
                    _unitOfWork.Commit();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        #endregion


        #region 2.0 更新用户
        public bool Update(MEASModel.DBModel.MemberInfo dbModel)
        {
            var user = _unitOfWork.UserRepository.Query().FirstOrDefault(s => s.Id == dbModel.Id);
            user.IsAdmin = dbModel.IsAdmin;
            user.IsDel = dbModel.IsDel;
            user.MemberId = dbModel.MemberId;
            user.DepId = dbModel.DepId;
            user.SName = dbModel.SName;
            _unitOfWork.Commit();
            return true;
        }
        #endregion
        /// <summary>
        /// 更新用户的订阅主题
        /// </summary>
        /// <param name="memberModel"></param>
        /// <param name="groupIds">订阅的topic数组</param>
        /// <returns></returns>
        public bool UpdateUserTopic(int memberId, int[] groupIds)
        {
            //1.先把原来订阅的主题给删除掉
            var userModel = _unitOfWork.UserRepository.Query().Where(s => s.Id == memberId).FirstOrDefault();
            userModel.Topic.Clear();
            //2.把新的主题添加上
            foreach (var topicId in groupIds)
            {
                var topic = _unitOfWork.TopicRepository.Query().FirstOrDefault(s => s.Id == topicId);
                userModel.Topic.Add(topic);
            }
            _unitOfWork.Commit();
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

        public bool UpdatePwd(string memberId, string oldPwd, string newPwd)
        {
            var userModel = _unitOfWork.UserRepository.Query().FirstOrDefault(s => s.MemberId == memberId && s.MemberPwd == oldPwd);
            if (userModel != null)
            {
                userModel.MemberPwd = newPwd;
            }
            return _unitOfWork.Commit() > 0;
        }

        public List<string> GetAllTopicByMemberID(string memberID)
        {
            return _unitOfWork.UserRepository.Query().FirstOrDefault(s => s.MemberId == memberID).Topic.Select(s => s.TopicMethod).ToList();
        }
    }
}
