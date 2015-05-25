using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEASModel.DBModel;
namespace MEASService.IService
{
    public interface IUserInfo
    {
        List<MemberInfo> GetUserRecords(int pageIndex, int pageSize, out int pageTotalCount);
        MemberInfo GetUserInfoByID(int id);

        bool UpdateUserTopic(int memberId,int[] groupIds);
    }
}
