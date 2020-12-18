using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TryingWpfMvvm.Serialization;

namespace TryingWpfMvvm.Model
{
    [DataContract]
    class Order
    {
        [DataMember]
        public Weapon Weapon { get; set; }
        [DataMember]
        private int _weaponCount;
        [DataMember]
        public int WeaponCount 
        {
            get
            {
                return _weaponCount;
            }
            
            set
            {
                if (value <= 0)
                {
                    _weaponCount = 1;
                }
                else
                {
                    _weaponCount = value;
                }
            }
        }
        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public decimal Total { get; set; }

        public Order()
        {
            Weapon = new Weapon();
            WeaponCount = 1;
            OrderDate = DateTime.MinValue;
        }
    }
}
