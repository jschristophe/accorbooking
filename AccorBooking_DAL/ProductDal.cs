
using AccorBooking.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.Sql;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace AccorBooking.DAL
{
    public class ProductDAL
    {
        private static AccorBookingContext context;
        static ProductDAL()
        {
            context = new AccorBookingContext(); // ServiceProviderServiceExtensions.GetService<AccorBookingContext>();
        }

        public static List<Product> GetProducts()
        {

            
            var listProduct = AzureCacheManager.Get<List<Product>>("listProduct");

            if(listProduct == null)
            {                
                var lst = context.Product; // .Include(p => p.ProductDocument).Include(p => p.ProductModel).Include(p => p.ProductSubcategory).Include(p => p.UnitMeasure).Include(p => p.UnitMeasure1);
                listProduct = lst.ToList();
                AzureCacheManager.Set("listProduct", listProduct);
            }
            return listProduct;
        }

        public static void ProcessOrder(int orderId)
        {

        }
    }
}