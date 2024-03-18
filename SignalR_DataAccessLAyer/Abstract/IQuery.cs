namespace SignalR_DataAccessLayer.Abstract;

public interface IQuery<TEntity>
{
    IQueryable<TEntity> Query();
}
