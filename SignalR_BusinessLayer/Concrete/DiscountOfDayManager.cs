﻿using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DataAccessLayer.Abstract.EntityInterfaces;
using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Concrete;

public class DiscountOfDayManager : GenericManager<DiscountOfDay, IDiscountOfDayDal>, IDiscountOfDayService
{
    public DiscountOfDayManager(IDiscountOfDayDal entityDal) : base(entityDal)
    {
    }

    public void TChangeStatusToFalse(int id)
    {
        _entityDal.ChangeStatusToFalse(id);
    }

    public void TChangeStatusToTrue(int id)
    {
        _entityDal.ChangeStatusToTrue(id);
    }

    public IList<DiscountOfDay> TGetListByStatusTrue()
    {
        return _entityDal.GetListByStatusTrue();
    }
}
