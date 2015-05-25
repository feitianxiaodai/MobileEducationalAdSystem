using MEASModel.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEASService.IService
{
    public interface ITopicService
    {
        int AddTopic(MEASModel.DBModel.Topic topicModel);
        List<Topic> GetTopicRecords(int pageIndex, int pageSize, out int pageTotalCount);
        bool DeleteTopic(int id);
        List<Topic> GetAllTopicRecords();
    }
}
