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

public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
{
    public EfNotificationDal(BaseContext context) : base(context)
    {
    }

    public IList<Notification> GetAllNotificationByStatusFalse()
    {
        return GetAll(x => x.Status == false);
    }

    public int GetNotificationCountByStatusFalse()
    {
        return _context.Notifications.Where(x => x.Status == false).Count();
    }

    public void NotificationStatusToFalse(int id)
    {
        var value = GetByFilter(x => x.Id == id);
        value.Status = false;
        _context.SaveChanges();
    }

    public void NotificationStatusToTrue(int id)
    {
        var value = GetByFilter(x => x.Id == id);
        value.Status = true;
        _context.SaveChanges();
    }
}
