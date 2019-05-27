using System;
using System.Collections.Generic;
using System.IO;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using AccorBooking.Entity;
using AccorBooking.DAL;

namespace AccorBooking.Business
{
    public class ProductBusiness
    {
        //public static List<Product> GetProducts()
        //{
        //    var result = ProductDAL.GetProducts();
        //    return result;
        //}

        public static List<Product> GetProducts(int pageNumber, int numberObjectPage)
        {
            var result = ProductDAL.GetProducts(pageNumber, numberObjectPage);
            return result;
        }
        

        public static void ProcessOrder(int orderId)
        {

        }
    }
}