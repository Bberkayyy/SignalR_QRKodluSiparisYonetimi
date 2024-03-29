﻿using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;

public interface IReservationService : IGenericService<Reservation>
{
    void TReservationStatusApproved(int id);
    void TReservationStatusCancelled(int id);
}
