namespace MyWebApp;

public interface IRepository<T>
{
    T GetById(int id);
    void InsertRecord(T entity);
    void DeleteRecord(int id);
    IEnumerable<T> GetAll();
}