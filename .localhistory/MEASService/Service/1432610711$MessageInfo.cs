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
            var newsRecords = _unitOfWork.MessageRepository.Query().OrderBy(s => s.PushTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();//GetPagedList(pageIndex, pageSize, s => true, s => s.PushTime);
            if (newsRecords != null && newsRecords.Count > 0)
            {
                return newsRecords;
            }
            return null;
        }

        public MEASModel.DBModel.MessageInfo GetMessageModel(int id)
        {
            var model = this.GetListBy(s => s.Id == id).FirstOrDefault();
            return model;
        }

        public int AddMessage(MEASModel.DBModel.MessageInfo model)
        {
            try
            {
                return this.Add(model);
            }
            catch (DbEntityValidationException edm)
            {
                return -1;
            }
        }

    }
}
