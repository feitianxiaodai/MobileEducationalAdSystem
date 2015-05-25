using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEASModel.DBModel;
namespace MEASService.IService
{
    public interface IMemeberInfo
    {
        MemberInfo Login(string memberID, string memberPwd);
    }
}
