using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DataAccessLayer.Abstract.EntityInterfaces;

public interface INotificationDal : IGenericDal<Notification>
{
    int GetNotificationCountByStatusFalse();
    IList<Notification> GetAllNotificationByStatusFalse();
    void NotificationStatusToTrue(int id);
    void NotificationStatusToFalse(int id);
}
