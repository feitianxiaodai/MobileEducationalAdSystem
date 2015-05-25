using MEASDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEASService.Service
{
    public class TopicInfo
    {
        private UnitOfWork _unitOfWork = null;
        public TopicInfo()
        {
            _unitOfWork = new UnitOfWork();
        }
        public int AddTopic(MEASModel.DBModel.Topic topicModel)
        {
            _unitOfWork.TopicRepository.Insert(topicModel);
            return _unitOfWork.Commit();
        }
        public List<MEASModel.DBModel.Topic> GetTopicRecords(int pageIndex, int pageSize, out int pageTotalCount)
        {
            pageTotalCount = _unitOfWork.TopicRepository.Query().Count();
            var topicRecords = _unitOfWork.TopicRepository.Query().OrderBy(s => s.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            if (topicRecords != null)
            {
                return topicRecords;
            }
            return null;
        }


        public bool DeleteTopic(int id)
        {
            var entity = _unitOfWork.TopicRepository.Query().FirstOrDefault(s => s.Id == id);
            _unitOfWork.TopicRepository.Delete(entity);
            if (_unitOfWork.Commit()>0)
            {
                return true;
            }
            return false;
        }


        public List<MEASModel.DBModel.Topic> GetAllTopicRecords()
        {
            var topicRecords = _unitOfWork.TopicRepository.Query().ToList();
            return topicRecords;
        }
    }
}
