namespace MyWebApp;

public interface IRepositoryFactory
{
    IRepository<T> CreateRepository<T>() where T :class;
}