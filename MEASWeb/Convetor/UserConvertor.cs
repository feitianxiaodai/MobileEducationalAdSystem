using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MEASModel.DBModel;
namespace MEASWeb.Convetor
{
    public static class UserConvertor
    {
        public static Models.MemberViewModel ConvertToUserViewModel(MemberInfo dbModel)
        {
            var userViewModel = new Models.MemberViewModel()
            {
                Id = dbModel.Id,
                SName = dbModel.SName,
                MemberId = dbModel.MemberId,
                DepName = dbModel.OrganStruct.Name,
                IsDel = dbModel.IsDel,
                IsAdmin = dbModel.IsAdmin,
                CreateTime = dbModel.CreateTime,

            };
            return userViewModel;
        }
    }
}