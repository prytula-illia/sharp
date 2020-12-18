using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryingWpfMvvm.Model;

namespace TryingWpfMvvm.ViewModel
{
    class WeaponViewModel : BaseViewModel
    {
        private Weapon weapon;

        public WeaponViewModel(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public string Name 
        {
            get
            {
                return weapon.Name;
            }
            set
            {
                weapon.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public decimal Price 
        { 
            get
            {
                return weapon.Price;
            }
            set
            {
                if(value <= 0)
                {
                    weapon.Price = 1;
                }
                else
                weapon.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }
}
