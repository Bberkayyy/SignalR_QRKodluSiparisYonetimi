using SignalR_DataAccessLayer.Abstract.EntityInterfaces;
using SignalR_DataAccessLayer.Concrete;
using SignalR_DataAccessLayer.Repositories;
using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DataAccessLayer.EntityFramework;

public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
{
    public EfReservationDal(BaseContext context) : base(context)
    {
    }

    public void ReservationStatusApproved(int id)
    {
        Reservation value = GetByFilter(x => x.Id == id);
        value.Description = "Onaylandı.";
        _context.SaveChanges();
    }

    public void ReservationStatusCancelled(int id)
    {
        Reservation value = GetByFilter(x => x.Id == id);
        value.Description = "İptal Edildi.";
        _context.SaveChanges();
    }
}
