using SignalR_EntityLayer.Entities;

namespace SignalR_DataAccessLayer.Abstract.EntityInterfaces;

public interface IReservationDal : IGenericDal<Reservation>
{
    void ReservationStatusApproved(int id);
    void ReservationStatusCancelled(int id);
}
