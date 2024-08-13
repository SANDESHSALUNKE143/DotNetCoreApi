namespace MyWebApp;

public class RepostitoryFactory:IRepositoryFactory
{
    
    public IRepository<T> CreateRepository<T>() where T : class
    {
        if (typeof(T) == typeof(ProductModel) )
        {
            return (IRepository<T>)new ProductRepository();
        }
        
        throw new InvalidOperationException($"Repository of {typeof(T)} not supported");
    }
}