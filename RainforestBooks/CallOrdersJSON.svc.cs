using RainforestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace RainforestBooks
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CallOrdersJSON
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public List<CustomerOrderProduct> GetCustomerOrders()
        {
            List<CustomerOrderProduct> customerOrders = new List<CustomerOrderProduct>();

            using (var db = new Context())
            {
                customerOrders = (from c in db.Customers
                                 join o in db.Orders
                                 on c.CustomerId equals o.CustomerId
                                 select new CustomerOrderProduct { ThisCustomer = c, ThisOrder = o, TheseOrderProducts=null}).ToList();
                
                foreach(CustomerOrderProduct item in customerOrders)
                {
                    List<OrderProduct> orderInventory = (from op in db.OrderProducts
                                                         where op.OrderId == item.ThisOrder.OrderId
                                                         select op).ToList();
                    item.TheseOrderProducts = orderInventory;
                }
                
            }
            return customerOrders;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
