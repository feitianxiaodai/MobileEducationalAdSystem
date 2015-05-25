using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEASService.IService
{
    public interface IGroupInfo
    {
        MEASModel.DBModel.GroupInfo GetGroupInfo(int id);

        List<MEASModel.POCOModel.POCOGroupModel> GetGroupList();
    }
}
