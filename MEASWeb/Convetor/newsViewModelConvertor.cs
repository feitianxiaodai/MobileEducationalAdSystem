using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MEASModel.DBModel;
namespace MEASWeb.Convetor
{
    public static class newsViewModelConvertor
    {
        public static Models.NewsViewModel ConvertToNewViewModel(NewsInfo dbModel)
        {
            var viewModel = new Models.NewsViewModel();
            viewModel.Id = dbModel.Id;
            viewModel.ImageUrl = dbModel.imageUrl;
            viewModel.newBodyHtml = dbModel.newBodyHtml;
            viewModel.PublishTime = dbModel.publishTime;
            viewModel.Source = dbModel.source;
            viewModel.Title = dbModel.title;
            viewModel.Author = dbModel.author;
            viewModel.NewType = dbModel.newType;
            return viewModel;
        }

        public static NewsInfo ConvertToDbModel(Models.NewsViewModel viewModel)
        {
            var dbModel = new NewsInfo();
            dbModel.Id = viewModel.Id;
            dbModel.imageUrl = viewModel.ImageUrl;
            dbModel.newBodyHtml = viewModel.newBodyHtml;
            dbModel.publishTime = viewModel.PublishTime;
            dbModel.source = viewModel.Source;
            dbModel.title = viewModel.Title;
            dbModel.author = viewModel.Author;
            dbModel.newType = viewModel.NewType;
            return dbModel;
        }
    }
}