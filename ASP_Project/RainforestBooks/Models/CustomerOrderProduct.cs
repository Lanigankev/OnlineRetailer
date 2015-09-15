using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RainforestBooks.Models
{   [DataContract]
    public class CustomerOrderProduct
    {
          [DataMember]
        public Customer ThisCustomer { get; set; }
          [DataMember]
        public Order ThisOrder { get; set; }
          [DataMember]
        public List<OrderProduct> TheseOrderProducts { get; set; }

    }
}