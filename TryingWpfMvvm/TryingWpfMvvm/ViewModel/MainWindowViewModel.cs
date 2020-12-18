using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TryingWpfMvvm.Commands;
using TryingWpfMvvm.Model;
using TryingWpfMvvm.Serialization;

namespace TryingWpfMvvm.ViewModel
{
    class MainWindowViewModel : BaseViewModel

    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }

        public MainWindowViewModel()
        {

            Orders = new ObservableCollection<OrderViewModel>();

            if (OrdersModel.Load().Orders != null)
            {
                foreach (var o in OrdersModel.Load().Orders)
                {
                    Orders.Add(new OrderViewModel(o));
                }
            }
        }

        ~MainWindowViewModel()
        {
            List<Order> o = new List<Order>();

            foreach (var or in Orders)
            {
                o.Add(new Order() 
                      {
                        Weapon = new Weapon() { Name = or.Weapon.Name, Price = or.Weapon.Price },
                        OrderDate = or.OrderDate,
                        WeaponCount = or.WeaponCount,
                        Total = or.Total
                      });
            }

            new OrdersModel()
            { Orders = o }.Save();


            
        }

        public ICommand MakeNewOrder
        {
            get
            {
                return new Command((obj) =>
                {
                    var NewOrderWindow = new NewOrderWindow() { DataContext = new NewOrderWindowViewModel() };

                    if (NewOrderWindow.ShowDialog() == false)
                    {
                        if(NewOrderWindow.DataContext != null)
                        {
                            NewOrderWindowViewModel nw = (NewOrderWindowViewModel)(NewOrderWindow.DataContext);
                            if (nw.CanReadOrder && nw.Order != null && nw.Order.Weapon.Name != new Weapon().Name)
                            {
                                Orders.Add(nw.Order);
                            }
                        }
                    }
                }
                    
                );
            }
        }
    }
}
