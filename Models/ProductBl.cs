using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace ITIMVCDAY1Grop5.Models
{
    public class ProductBl
    {
        List<Product> _Product;
        public ProductBl()
        {
            _Product = new List<Product>()
            {
               new Product{ Id= 1,Name= "Yousef" ,Address =" Ciro" ,ImageUrl= "01.jpg"},
               new Product{ Id= 2,Name= "Ahmed" ,Address =" Menoif" ,ImageUrl= "02.jpg"},
               new Product{ Id= 3,Name= "Ali" ,Address =" Geza" ,ImageUrl= "05.jpg"},
               new Product{ Id= 4,Name= "Mohamed" ,Address =" Alix" ,ImageUrl= "06.jpg"},
            };

        }

        public List<Product> AllProduct()
        {
            return _Product;    
        }

        public Product ProductPYId(int Id)
        {
            return _Product.FirstOrDefault(P=>P.Id==Id)!;
        }

    }
}
