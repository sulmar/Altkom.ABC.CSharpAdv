﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.WPFClient.IServices
{
    public interface IVehiclesService
    {
        IEnumerable<dynamic> Get();
        void Update(IEnumerable<dynamic> vehicles);
    }
}
