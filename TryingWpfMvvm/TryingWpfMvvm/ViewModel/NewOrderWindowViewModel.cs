using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TryingWpfMvvm.Commands;
using TryingWpfMvvm.Model;

namespace TryingWpfMvvm.ViewModel
{
    class NewOrderWindowViewModel : BaseViewModel
    {
        private string userControlVisible = "Weapons";

        public string UserControlVisible
        {
            get
            {
                return userControlVisible;
            }
            set
            {
                userControlVisible = value;
                OnPropertyChanged(nameof(UserControlVisible));
            }
        }

        public ObservableCollection<WeaponViewModel> Weapons { get; set; }

        public OrderViewModel Order { get; set; }

        public bool CanReadOrder { get; private set; }

        public ICommand MakeOrder
        {
            get
            {
                return new Command((obj) =>
                {
                    CanReadOrder = true;
                    
                    Order.Total = Order.Weapon.Price * Order.WeaponCount;
                    Order.OrderDate = DateTime.UtcNow;
                    
                    ((NewOrderWindow)obj).Close();
                });
            }
        }

        public ICommand SetVisibility
        {
            get
            {
                return new Command((args) =>
                {
                    UserControlVisible = args.ToString();
                }

                );
            }
        }

        public NewOrderWindowViewModel()
        {
            Weapons = new ObservableCollection<WeaponViewModel>();

            if (WeaponsModel.Load().Weapons != null)
            {
                foreach (var w in WeaponsModel.Load().Weapons)
                {
                    Weapons.Add(new WeaponViewModel(w));
                }
            }
            else
            {
                Weapons.Add(new WeaponViewModel(new Weapon() { Name = "Glock", Price = 2000 }));
                Weapons.Add(new WeaponViewModel(new Weapon() { Name = "AK47", Price = 5000 }));
                Weapons.Add(new WeaponViewModel(new Weapon() { Name = "M4A1", Price = 6000 }));
                Weapons.Add(new WeaponViewModel(new Weapon() { Name = "MP5", Price = 3500 }));
                Weapons.Add(new WeaponViewModel(new Weapon() { Name = "Colt 1911", Price = 6000 }));
                Weapons.Add(new WeaponViewModel(new Weapon() { Name = "PM", Price = 2000 }));
                Weapons.Add(new WeaponViewModel(new Weapon() { Name = "Thompson M1", Price = 6000 }));
                Weapons.Add(new WeaponViewModel(new Weapon() { Name = "Karabiner Kurz 98k", Price = 12000 }));
                Weapons.Add(new WeaponViewModel(new Weapon() { Name = "UZI", Price = 4570 }));
            }
            Order = new OrderViewModel(new Order());
            Order.Weapon = Weapons.First();
        }

        ~NewOrderWindowViewModel()
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach (var w in Weapons)
            {
                weapons.Add(new Weapon() { Name = w.Name, Price = w.Price });
            }

            new WeaponsModel()
            { Weapons = weapons }.Save();

        }
    }
}
