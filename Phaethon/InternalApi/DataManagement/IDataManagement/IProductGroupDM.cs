﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;

namespace InternalApi.DataManagement.IDataManagement
{
    interface IProductGroupDM
    {
        bool Create(ProductGroup productGroup);
        List<ProductGroup> GetProductGroups();
    }
}
