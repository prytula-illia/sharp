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
    class WeaponsSerializer
    {
        public static void Serialize(WeaponsModel obj, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(WeaponsModel));
            FileStream fileStream = new FileStream(fileName, FileMode.Create);

            serializer.WriteObject(fileStream, obj);

            fileStream.Close();
        }

        public static WeaponsModel Deserialize(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            DataContractSerializer serializer = new DataContractSerializer(typeof(WeaponsModel));

            WeaponsModel retval = (WeaponsModel)serializer.ReadObject(fileStream);
            fileStream.Close();
            return retval;
        }
    }
}

