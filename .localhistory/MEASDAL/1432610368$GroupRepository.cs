﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEASModel.DBModel;
using System.Data.Entity;
namespace MEASDAL
{
    public class GroupeRepository:RepositoryBase<GroupInfo>
    {
        public GroupeRepository(DbContext context)
            : base(context)
        {

        }
    }
}
