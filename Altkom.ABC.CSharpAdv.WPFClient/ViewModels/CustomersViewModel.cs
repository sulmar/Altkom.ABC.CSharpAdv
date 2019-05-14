using Altkom.ABC.CSharpAdv.WPFClient.IServices;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Altkom.ABC.CSharpAdv.WPFClient.ViewModels
{
    public class CustomersViewModel
    {
        public IEnumerable<dynamic> Vehicles { get; set; }

        public ICommand SaveCommand { get; private set; }

        private readonly IVehiclesService vehiclesService;

        public CustomersViewModel(IVehiclesService vehiclesService)
        {
            this.vehiclesService = vehiclesService;

            SaveCommand = new RelayCommand(() => Save());

            Load();
        }

        public void Load()
        {
            Vehicles = vehiclesService.Get();
        }

        public void Save()
        {
            vehiclesService.Update(Vehicles);
        }
    }
}
