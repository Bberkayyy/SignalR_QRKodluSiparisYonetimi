﻿using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;

public interface IDiscountOfDayService : IGenericService<DiscountOfDay>
{
    void TChangeStatusToTrue(int id);
    void TChangeStatusToFalse(int id); 
    IList<DiscountOfDay> TGetListByStatusTrue();
}
