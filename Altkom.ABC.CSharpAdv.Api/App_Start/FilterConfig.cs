﻿using System.Web;
using System.Web.Mvc;

namespace Altkom.ABC.CSharpAdv.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
