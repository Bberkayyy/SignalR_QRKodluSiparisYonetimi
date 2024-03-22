using SignalR_DataAccessLayer.Abstract.EntityInterfaces;
using SignalR_DataAccessLayer.Concrete;
using SignalR_DataAccessLayer.Repositories;
using SignalR_EntityLayer.Entities;

namespace SignalR_DataAccessLayer.EntityFramework;

public class EfFooterInfoDal : GenericRepository<FooterInfo>, IFooterInfoDal
{
    public EfFooterInfoDal(BaseContext context) : base(context)
    {
    }
}
