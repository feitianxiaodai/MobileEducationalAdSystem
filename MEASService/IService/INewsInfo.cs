using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEASModel.DBModel;
namespace MEASService.IService
{
    public interface INewsInfo
    {
        List<NewsInfo> GetNewsRecords(int pageIndex, int pageSize, out int pageTotalCount);

        NewsInfo GetNewsInfoModel(int newsId);

        int Add(NewsInfo dbModel);

        bool Delete(int id);

        int Edit(NewsInfo dbModel, string[] param);
    }
}
