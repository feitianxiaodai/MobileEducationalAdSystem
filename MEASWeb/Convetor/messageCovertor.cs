using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASWeb.Convetor
{
    public static class messageCovertor
    {
        public static List<Models.MessageListViewModel> ConvertToMessageViewModel(List<MEASModel.DBModel.MessageInfo> dbList)
        {
            List<Models.MessageListViewModel> messageViewList = new List<Models.MessageListViewModel>();
            if (dbList != null && dbList.Count > 0)
            {
                messageViewList = dbList.Select(s => new Models.MessageListViewModel
                {
                    PushTime = s.PushTime,
                    MessageTitle = s.MessageTitle,
                    MessageContent = s.MessageContent,
                    ID = s.Id
                }).ToList();
            }
            return messageViewList;
        }

        //public static MEASModel.DBModel.MessageInfo ConvertToMessageDbModel(Models.MessageListViewModel viewModel)
        //{
        //    var dbModel = new MEASModel.DBModel.MessageInfo();
        //    dbModel= 
        //}
    }
}