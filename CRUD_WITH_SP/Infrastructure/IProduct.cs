using CRUD_WITH_SP.Models;
using System.Collections.Generic;

namespace CRUD_WITH_SP.Infrastructure
{

    public interface IProduct
    {
        IEnumerable<Product> GetAll();
        Product GetById(int productId);
        void Insert(Product product);

        void Update(Product product);
        void Delete(int productId);


    }

}
 