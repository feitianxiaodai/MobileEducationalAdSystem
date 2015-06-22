using MEASDAL;
using MEASModel.POCOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MEASService.Service
{
    public class OrganStructInfo
    {
        private UnitOfWork _unitOfWork = null;
        public OrganStructInfo()
        {
            _unitOfWork = new UnitOfWork();
        }

        #region 1.0 获得部门内容
        public List<OrganStructViewModel> GetAllOrganStructList(Expression<Func<MEASModel.DBModel.OrganStruct, bool>> whereLambda)
        {
            List<OrganStructViewModel> organStructList = new List<OrganStructViewModel>();
            var organStruct = _unitOfWork.OrganStructRepository.Query().Where(whereLambda).ToList();
            if (organStruct != null && organStruct.Count > 0)
            {
                organStructList = organStruct.Select(s => new OrganStructViewModel
                {
                    CreateTime = s.CreateTime,
                    Id = s.Id,
                    Name = s.Name,
                    ParentId = s.parentId,
                    Status = s.Status
                }).ToList();
            }
            return organStructList;
        }
        #endregion

        #region 2.0 获得TreeNode节点
        public TreeNode GetTreeNode(List<OrganStructViewModel> organStruct)
        {
            TreeNode node = new TreeNode();
            if (organStruct != null && organStruct.Count > 0)
            {
                foreach (var item in organStruct)
                {
                    if (item.ParentId.Equals(0))
                    {
                        node.rows.Add(new { id = item.Id, Name = item.Name, Status = item.Status, CreateTime = item.CreateTime });
                    }
                    else
                    {
                        node.rows.Add(new { id = item.Id, Name = item.Name, Status = item.Status, CreateTime = item.CreateTime, _parentId = item.ParentId });
                    }
                }
                node.total = node.rows.Count;
            }
            return node;
        }
        #endregion

        #region 3.0 新增
        public bool Add(OrganStructViewModel viewModel)
        {
            MEASModel.DBModel.OrganStruct entity = new MEASModel.DBModel.OrganStruct();
            if(viewModel!=null)
            {
                entity.Status = viewModel.Status;
                entity.Name = viewModel.Name;
                entity.parentId = viewModel.ParentId;
                entity.CreateTime = DateTime.Now;
            }
            _unitOfWork.OrganStructRepository.Insert(entity);
            _unitOfWork.Commit();
            return true;
        }
        #endregion
    }
}
