using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TryingWpfMvvm.Serialization;
using TryingWpfMvvm.ViewModel;

namespace TryingWpfMvvm.Model
{
    [DataContract]
    class OrdersModel
    {
        public static string filename = "Orders.dat";

        [DataMember]
        public IEnumerable<Order> Orders { get; set; }

        public OrdersModel()
        {
            Orders = null;
        }


        public void Save()
        {
            OrdersSerializer.Serialize(this, filename);
        }

        public static OrdersModel Load()
        {
            if (File.Exists(filename))
            {
                return OrdersSerializer.Deserialize(filename);
            }
            else
            {
                return new OrdersModel();
            }
        }
    }
}
