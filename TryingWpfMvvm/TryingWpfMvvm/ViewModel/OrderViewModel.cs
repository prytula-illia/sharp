using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryingWpfMvvm.Model;

namespace TryingWpfMvvm.ViewModel
{
    class OrderViewModel : BaseViewModel
    {
        private Order order;
        public OrderViewModel(Order order)
        {
            this.order = order;
            Weapon = new WeaponViewModel(order.Weapon);
        }

        
        public WeaponViewModel Weapon { get; set; }

        public int WeaponCount 
        { 

            get
            {
                return order.WeaponCount;
            }
            set
            {
                if (value <= 0)
                {
                    order.WeaponCount = 1;
                }
                else
                {
                    order.WeaponCount = value;
                }
                OnPropertyChanged(nameof(WeaponCount));
            }
        }

        public DateTime OrderDate 
        { 
            get
            {
                return order.OrderDate;
            }
            set
            {
                order.OrderDate = value;
                OnPropertyChanged(nameof(OrderDate));
            }
        }


        public decimal Total 
        { 
            get
            {
                return order.Total;
            }
            set
            {
                order.Total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

    }
}
