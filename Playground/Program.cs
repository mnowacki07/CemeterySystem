using CemeterySystem.DBModels;
using CemeterySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentClass example1 = new PaymentClass()
            {
                PaymentClassID = Guid.NewGuid(),
                Description = "Example 1 description",
                Name = "Example 1 name",
                Price = 12345.67M
            };

            PaymentClass example2 = new PaymentClass()
            {
                PaymentClassID = Guid.NewGuid(),
                Description = "Example 2 description",
                Name = "Example 2 name",
                Price = 5544.33M
            };

            PaymentClassService service = new PaymentClassService();

            example1 = service.create(example1);
            example2 = service.create(example2);
                        
            example1.Name += " name updated";
            example1.Description += " desc updated";            
            example1.Price = 76543.21M;
            service.update(example1);

            List<PaymentClass> listPaymentClass1 = service.getAll();

            List<PaymentClass> listPaymentClass2 = service.getBy(x => x.Price == 5544.33M);
        }
    }
}
