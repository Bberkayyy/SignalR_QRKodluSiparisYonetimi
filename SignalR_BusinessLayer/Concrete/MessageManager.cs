using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DataAccessLayer.Abstract.EntityInterfaces;
using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Concrete;

public class MessageManager : GenericManager<Message, IMessageDal>, IMessageService
{
    public MessageManager(IMessageDal entityDal) : base(entityDal)
    {
    }
}
