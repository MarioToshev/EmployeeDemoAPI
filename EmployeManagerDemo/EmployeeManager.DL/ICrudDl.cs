namespace EmoloyeeManager.DL;

public interface ICrudDl<T>
{
    public Task<T> Insert(T obj);
    public Task<T> Update(T obj);
    public Task Delete(string email);
    public Task<List<T>> GetAll();    
    public Task<Employee?> GetByEmail(string email);
}