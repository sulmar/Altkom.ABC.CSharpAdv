using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public class Setting
    {
        public bool Option1 { get; set; }

        public string Option2  { get; set; }

        public int Option3 { get; set; }

        public int Option4 { get; set; }

        public object this[string propertyName]
        {
            get { return this.Get(propertyName); }
            set { this.Set(propertyName, value); }
        }


    }
}
