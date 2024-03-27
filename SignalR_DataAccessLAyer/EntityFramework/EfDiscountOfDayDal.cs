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

public class EfDiscountOfDayDal : GenericRepository<DiscountOfDay>, IDiscountOfDayDal
{
    public EfDiscountOfDayDal(BaseContext context) : base(context)
    {
    }

    public void ChangeStatusToFalse(int id)
    {
        DiscountOfDay value = GetByFilter(x => x.Id == id);
        value.Status = false;
        _context.SaveChanges();
    }

    public void ChangeStatusToTrue(int id)
    {
        DiscountOfDay value = GetByFilter(x => x.Id == id);
        value.Status = true;
        _context.SaveChanges();
    }

    public IList<DiscountOfDay> GetListByStatusTrue()
    {
        IList<DiscountOfDay> values = GetAll(x => x.Status == true);
        return values;
    }
}
