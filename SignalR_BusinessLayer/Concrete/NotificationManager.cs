using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DataAccessLayer.Abstract.EntityInterfaces;
using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Concrete;

public class NotificationManager : GenericManager<Notification, INotificationDal>, INotificationService
{
    public NotificationManager(INotificationDal entityDal) : base(entityDal)
    {
    }

    public void TNotificationStatusToFalse(int id)
    {
        _entityDal.NotificationStatusToFalse(id);
    }

    public void TNotificationStatusToTrue(int id)
    {
        _entityDal.NotificationStatusToTrue(id);
    }

    public IList<Notification> TGetAllNotificationByStatusFalse()
    {
        return _entityDal.GetAllNotificationByStatusFalse();
    }

    public int TGetNotificationCountByStatusFalse()
    {
        return _entityDal.GetNotificationCountByStatusFalse();
    }
}
