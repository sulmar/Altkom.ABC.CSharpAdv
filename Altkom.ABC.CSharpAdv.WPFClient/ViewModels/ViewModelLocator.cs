using Altkom.ABC.CSharpAdv.WPFClient.IServices;
using Altkom.ABC.CSharpAdv.WPFClient.Services;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.WPFClient.ViewModels
{
    public class ViewModelLocator
    {

        private IContainer container;

        public ViewModelLocator()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<CustomersViewModel>();
            builder.RegisterType<VehiclesService>().As<IVehiclesService>();
            this.container = builder.Build();
        }

        // public CustomersViewModel CustomersViewModel => new CustomersViewModel(new VehiclesService());

        public CustomersViewModel CustomersViewModel => container.Resolve<CustomersViewModel>();
    }
}
