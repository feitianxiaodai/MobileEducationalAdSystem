using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEASModel.DBModel;
using MEASDAL;
namespace MEASService.Service
{
    public class NewsInfo
    {
        private UnitOfWork _unitOfWork = null;
        public NewsInfo()
        {
            _unitOfWork = new UnitOfWork();
        }
        /// <summary>
        /// 获得所有的新闻标题和内容
        /// </summary>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="pageTotalCount">总条数</param>
        /// <returns></returns>
        public List<MEASModel.DBModel.NewsInfo> GetNewsRecords(int pageIndex, int pageSize, out int pageTotalCount)
        {
            pageTotalCount = _unitOfWork.NewsRepository.Query().Count();
            var newsRecords = _unitOfWork.NewsRepository.Query().OrderBy(s => s.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            if (newsRecords != null && newsRecords.Count > 0)
            {
                return newsRecords;
            }
            return null;
        }

        public List<MEASModel.DBModel.NewsInfo> GetNewsRecords(int pageIndex, int pageSize,int newType, out int pageTotalCount)
        {
            pageTotalCount = _unitOfWork.NewsRepository.Query().Where(s=>s.newType==newType).Count();
            var newsRecords = _unitOfWork.NewsRepository.Query().Where(s=>s.newType==newType).OrderBy(s => s.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            if (newsRecords != null && newsRecords.Count > 0)
            {
                return newsRecords;
            }
            return null;
        }

        /// <summary>
        /// 根据ID获得新闻内容
        /// </summary>
        /// <param name="newsId">ID</param>
        /// <returns></returns>
        public MEASModel.DBModel.NewsInfo GetNewsInfoModel(int newsId)
        {
            var newModel = _unitOfWork.NewsRepository.Query().FirstOrDefault(s => s.Id == newsId);
            return newModel;
        }


        public int Add(MEASModel.DBModel.NewsInfo dbModel)
        {
            _unitOfWork.NewsRepository.Insert(dbModel);
            return _unitOfWork.Commit();
        }

        public bool Delete(int id)
        {
            var dbEntity = _unitOfWork.NewsRepository.Query().FirstOrDefault(s => s.Id == id);
            _unitOfWork.NewsRepository.Delete(dbEntity);
            return _unitOfWork.Commit() > 0;
        }
        public int Edit(MEASModel.DBModel.NewsInfo dbModel, string[] param)
        {
            var dbEntity = _unitOfWork.NewsRepository.Query().FirstOrDefault(s => s.Id == dbModel.Id);
            dbEntity.author = dbModel.author;
            dbEntity.Id = dbModel.Id;
            dbEntity.imageUrl = dbModel.imageUrl;
            dbEntity.newBodyHtml = dbModel.newBodyHtml;
            dbEntity.newType = dbModel.newType;
            dbModel.publishTime = dbModel.publishTime;
            dbModel.source = dbModel.source;
            dbModel.title = dbModel.title;
            return _unitOfWork.Commit();
        }


       
    }
}
