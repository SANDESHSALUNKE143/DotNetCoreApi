namespace MyWebApp;

public class ProductRepository:IRepository<ProductModel>
{
    public ProductModel GetById(int id)
    {
        return new ProductModel
        {
            Id = 1,
            Name = "Soap",
            Price = "10.12"
        };

    }

    public void InsertRecord(ProductModel entity)
    {
        throw new NotImplementedException();

    }

    public void DeleteRecord(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProductModel> GetAll()
    {
        throw new NotImplementedException();
    }
}