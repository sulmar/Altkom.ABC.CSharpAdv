using Altkom.ABC.CSharpAdv.WPFClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.WPFClient.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {

        }

        public CustomersViewModel CustomersViewModel => new CustomersViewModel(new VehiclesService());
    }
}
