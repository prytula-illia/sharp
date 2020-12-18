using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TryingWpfMvvm.Model
{
    [DataContract]
    class Weapon
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        private decimal _price;
        [DataMember]
        public decimal Price 
        { 
            get
            {
                return _price;
            }
            set
            {
                if (value <= 0)
                {
                    _price = 1;
                }
                else
                    _price = value;
            }
        }

        public Weapon()
        {
           Name = "No name";
           Price = 1;
        }
    }
}
