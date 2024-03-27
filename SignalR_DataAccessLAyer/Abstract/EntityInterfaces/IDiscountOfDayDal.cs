using SignalR_EntityLayer.Entities;

namespace SignalR_DataAccessLayer.Abstract.EntityInterfaces;

public interface IDiscountOfDayDal : IGenericDal<DiscountOfDay>
{
    void ChangeStatusToTrue(int id);
    void ChangeStatusToFalse(int id);
    IList<DiscountOfDay> GetListByStatusTrue();
}
