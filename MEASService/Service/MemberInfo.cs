using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEASService.Service
{
    public class MemberInfo : BaseService<MEASModel.DBModel.MemberInfo>, IService.IMemeberInfo
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="memberPwd"></param>
        /// <returns></returns>
        public MEASModel.DBModel.MemberInfo Login(string memberID, string memberPwd)
        {
            MEASModel.DBModel.MemberInfo dbModel = null;
            if(!string.IsNullOrWhiteSpace(memberID) && !string.IsNullOrWhiteSpace(memberPwd))
            {
                var model = this.GetListBy(s => s.MemberId == memberID).FirstOrDefault();
                if (model != null)
                {
                    if(model.MemberPwd==memberPwd)
                    {
                        dbModel = model;
                    }
                }
            }
            return dbModel;
        }
    }
}
