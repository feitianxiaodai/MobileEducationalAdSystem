using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEASService.IService
{
    public interface IMessage
    {
        List<MEASModel.DBModel.MessageInfo> GetMessageRecordsList(int pageIndex, int pageSize, out int pageTotalCount);

        MEASModel.DBModel.MessageInfo GetMessageModel(int id);

        int AddMessage(MEASModel.DBModel.MessageInfo model);
    }
}
