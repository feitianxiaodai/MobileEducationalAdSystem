using MEASWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASWeb.Convetor
{
    /// <summary>
    /// 新闻列表展示转换类
    /// </summary>
    public static class newsListShowConvertor
    {
        public static List<Models.NewsListViewModel> ConvertToNewsListViewModel(List<MEASModel.DBModel.NewsInfo> newsList)
        {
            List<NewsListViewModel> newsViewList = new List<NewsListViewModel>();
            if (newsList != null && newsList.Count > 0)
            {
                newsViewList = newsList.Select(s => new NewsListViewModel
                {
                    Source = s.source,
                    Author = s.author,
                    Id = s.Id,
                    NewType = GetNewType(s.newType),
                    PublishTime = s.publishTime,
                    Title = s.title
                }).ToList();
            }
            return newsViewList;
        }

        public static string GetNewType(int type)
        {
            string newType = string.Empty;
            switch (type)
            {
                case 0:
                    {
                        newType = "科大要闻";
                        break;
                    }
                case 1:
                    {
                        newType = "校园传真";
                        break;
                    }
                case 2:
                    {
                        newType = "媒体科大";
                        break;
                    }
                case 3:
                    {
                        newType = "校园公告";
                        break;
                    }
                case 4:
                    {
                        newType = "校内通知";
                        break;
                    }
                case 5:
                    {
                        newType = "学术动态";
                        break;
                    }
                default:
                    {
                        newType = "新闻资讯";
                        break;
                    }
            }
            return newType;
        }
    }
}