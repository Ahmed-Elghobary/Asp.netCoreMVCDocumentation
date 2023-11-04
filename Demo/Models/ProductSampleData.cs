namespace Demo.Models
{
    public class ProductSampleData
    {
        List<Product> products;
        public ProductSampleData()
        {
            products = new List<Product>();
            products.Add(new Product() { Id=1,Name="IphoneX", Description="X pro max patary 28%",Price=19000,Image= "iphone.jpg" });
            products.Add(new Product() { Id=2,Name="Iphone11", Description="11 pro max patary 28%",Price=22000,Image= "iphone.jpg" });
            products.Add(new Product() { Id=3,Name="Iphone12", Description="12 pro max patary 28%",Price=25000,Image= "iphone.jpg" });
            products.Add(new Product() { Id=4,Name="Iphone13", Description="13 pro max patary 28%",Price=30000,Image="iphone.jpg" });
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            return products.FirstOrDefault(x=>x.Id==id);
        }
    }
}
