using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEASService.Service
{
    public class GroupInfo
    {

        public MEASModel.DBModel.GroupInfo GetGroupInfo(int id)
        {
            var model = this.GetListBy(s => s.Id == id).ToList();
            var temp = model[0];
            return temp;
        }


        public List<MEASModel.POCOModel.POCOGroupModel> GetGroupList()
        {
            var groupList = this.GetListBy(s => true).Select(s => new MEASModel.POCOModel.POCOGroupModel
            {
                GroupTitle = s.GroupTitle,
                ID = s.Id
            }).ToList();
            return groupList;
        }
    }
}
