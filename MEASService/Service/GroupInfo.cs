using MEASDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEASService.Service
{
    public class GroupInfo
    {
        private UnitOfWork _unitOfWork = null;
        public GroupInfo()
        {
            _unitOfWork = new UnitOfWork();
        }
        public MEASModel.DBModel.GroupInfo GetGroupInfo(int id)
        {
            var model = _unitOfWork.GroupeRepository.Query().Where(s => s.Id == id).ToList();
            var temp = model[0];
            return temp;
        }


        public List<MEASModel.POCOModel.POCOGroupModel> GetGroupList()
        {

            var groupList = _unitOfWork.TopicRepository.Query().Select(s => new MEASModel.POCOModel.POCOGroupModel
            {
                GroupTitle = s.TopicName,
                ID = s.Id,
            }).ToList();
            return groupList;
        }
    }
}
