using Altkom.ABC.CSharpAdv.WPFClient.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.WPFClient.Services
{
    public class VehiclesService : IVehiclesService
    {
        public IEnumerable<dynamic> Get()
        {
            string jsonString = "[{\"Model\":\"Toyota\",\"Color\":\"Red\",\"ProductionYear\":2015,\"RegistrationDate\":\"2015-05-30T00:00:00\"}, {\"Model\":\"Mazda\",\"Color\":\"Blue\",\"ProductionYear\":2017,\"RegistrationDate\":\"2017-12-01T00:00:00\"}]";

            return JsonConvert.DeserializeObject<IEnumerable<dynamic>>(jsonString);
        }

        public void Update(IEnumerable<dynamic> vehicles)
        {
            string json = JsonConvert.SerializeObject(vehicles);
            

        }
    }
}
