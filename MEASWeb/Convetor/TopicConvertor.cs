using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MEASModel.DBModel;
namespace MEASWeb.Convetor
{
    public static class TopicConvertor
    {
        public static Models.TopicViewModel ConvertToTopicViewModel(Topic dbModel)
        {
            Models.TopicViewModel viewModel = new Models.TopicViewModel();
            viewModel.ID = dbModel.Id;
            viewModel.TopicMethod = dbModel.TopicMethod;
            viewModel.TopicName = dbModel.TopicName;
            return viewModel;
        }

        public static Topic ConvertToTopicDbModel(Models.TopicViewModel viewModel)
        {
            Topic dbModel = new Topic
            {
                Id = viewModel.ID,
                TopicName = viewModel.TopicName,
                TopicMethod = viewModel.TopicMethod
            };
            return dbModel;
        }
    }
}