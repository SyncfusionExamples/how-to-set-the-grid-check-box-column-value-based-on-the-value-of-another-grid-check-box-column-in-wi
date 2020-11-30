using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBox_Changed
{
    public class OrderInfo
    {
        int orderID;
        string customerId;
        string country;
        string customerName;
        string shippingCity;
        bool isClosed;
        bool isClosed1;
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        public string CustomerID
        {
            get { return customerId; }
            set { customerId = value; }
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public string ShipCity
        {
            get { return shippingCity; }
            set { shippingCity = value; }
        }
        public bool IsClosed
        {
            get { return isClosed; }
            set { isClosed = value; }
        }
        public bool IsClosed1
        {
            get { return isClosed1; }
            set { isClosed1 = value; }
        }
        public OrderInfo(int orderId, string customerName, string country, string customerId, string shipCity, bool isClosed, bool isClosed1)
        {
            this.OrderID = orderId;
            this.CustomerName = customerName;
            this.Country = country;
            this.CustomerID = customerId;
            this.ShipCity = shipCity;
            this.IsClosed = isClosed;
            this.IsClosed1 = isClosed1;
        }
    }
}
