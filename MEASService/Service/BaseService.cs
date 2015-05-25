using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEASService.Service
{
    
    public class BaseService<T>:IService.IBaseService<T> where T:class,new()
    {
        static MEASDAL.BaseDAL<T> dal = new MEASDAL.BaseDAL<T>();
        public int Add(T model)
        {
            return dal.Add(model);
        }

        public int Del(T model)
        {
            return dal.Del(model);
        }

        public int DelBy(System.Linq.Expressions.Expression<Func<T, bool>> delWhere)
        {
            return dal.DelBy(delWhere);
        }

        public int Modify(T model,params string[] proNames)
        {
            return dal.Modify(model,proNames);
        }

        public int ModifyBy(T model, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            return dal.ModifyBy(model, whereLambda, modifiedProNames);
        }

        public List<T> GetListBy(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return dal.GetListBy(whereLambda);
        }

        public List<T> GetListBy<TKey>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderLambda)
        {
            return dal.GetListBy(whereLambda, orderLambda);
        }

        public List<T> GetPagedList<TKey>(int pageIndex, int pageSize, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderBy)
        {
            return dal.GetPagedList(pageIndex, pageSize, whereLambda, orderBy);
        }


        public List<T> GetListByDesc<TKey>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TKey>> orderLambda)
        {
            return dal.GetListByDesc(whereLambda, orderLambda);
        }


        public int GetPageCount(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return dal.GetListCount(whereLambda);
        }


        public int Update(T model)
        {
            return dal.Update(model);
        }


        public int ModifyById(T model, int id, params string[] proNames)
        {
            return dal.ModifyById(model, id, proNames);
        }
    }
}
