using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TryingWpfMvvm.Serialization;
using System.IO;

namespace TryingWpfMvvm.Model
{
    [DataContract]
    class WeaponsModel
    {
        public static string filename = "Weapons.dat";

        [DataMember]
        public IEnumerable<Weapon> Weapons { get; set; }

        public WeaponsModel()
        {
            Weapons = null;
        }


        public void Save()
        {
            WeaponsSerializer.Serialize(this, filename);
        }

        public static WeaponsModel Load()
        {
            if (File.Exists(filename))
            {
                return WeaponsSerializer.Deserialize(filename);
            }
            else
            {
                return new WeaponsModel();
            }
        }
    }
}
