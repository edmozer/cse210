using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double GetTotalCost()
        {
            double sumProducts = 0;
            foreach (var product in _products)
            {
                sumProducts += product.GetTotalCost();
            }
            double shipping = _customer.LivesInUSA() ? 5.0 : 35.0;
            return sumProducts + shipping;
        }

        public string GetPackingLabel()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Packing Label:");

            foreach (var product in _products)
            {
                result.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
            }
            return result.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Shipping Label:");
            result.AppendLine(_customer.GetName());
            result.AppendLine(_customer.GetAddress().GetFullAddress());
            return result.ToString();
        }
    }
}
