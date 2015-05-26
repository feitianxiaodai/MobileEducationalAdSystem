using MEASDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEASService.Service
{
    public class MessageInfo
    {
         private UnitOfWork _unitOfWork = null;
         public MessageInfo()
        {
            _unitOfWork = new UnitOfWork();
        }
        public List<MEASModel.DBModel.MessageInfo> GetMessageRecordsList(int pageIndex, int pageSize, out int pageTotalCount)
        {
            pageTotalCount = _unitOfWork.MessageRepository.Query().Count();
            var newsRecords = _unitOfWork.MessageRepository.Query().OrderBy(s => s.PushTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            if (newsRecords != null && newsRecords.Count > 0)
            {
                return newsRecords;
            }
            return null;
        }

        public MEASModel.DBModel.MessageInfo GetMessageModel(int id)
        {
            var model = _unitOfWork.MessageRepository.Query().FirstOrDefault(s => s.Id == id);
            return model;
        }

        public int AddMessage(MEASModel.DBModel.MessageInfo model)
        {
            try
            {
                _unitOfWork.MessageRepository.Insert(model);
                return _unitOfWork.Commit();
            }
            catch (DbEntityValidationException edm)
            {
                return -1;
            }
        }

        public List<string> GetTopicByGroupIds(int[] groupIds)
        {
            List<string> topicList = new List<string>();
            if(groupIds!=null && groupIds.Count()>0)
            {
                
            }
        }

    }
}
