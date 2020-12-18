using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TryingWpfMvvm.Model;

namespace TryingWpfMvvm.Serialization
{
    class OrdersSerializer
    {

        public static void Serialize(OrdersModel obj, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(OrdersModel));
            FileStream fileStream = new FileStream(fileName, FileMode.Create);

            serializer.WriteObject(fileStream, obj);

            fileStream.Close();
        }

        public static OrdersModel Deserialize(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            DataContractSerializer serializer = new DataContractSerializer(typeof(OrdersModel));

            OrdersModel retval = (OrdersModel)serializer.ReadObject(fileStream);
            fileStream.Close();
            return retval;
        }
    }
}
