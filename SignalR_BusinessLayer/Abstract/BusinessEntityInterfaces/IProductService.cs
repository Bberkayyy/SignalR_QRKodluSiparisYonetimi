﻿using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;

public interface IProductService : IGenericService<Product>
{
    IList<Product> TGetAllProductsWithCategories();
    Product TGetProductWithCategory(int id);
    IList<Product> TGetLast9ProductWithCategories();
}
