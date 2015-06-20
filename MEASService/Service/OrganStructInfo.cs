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
    }
}
