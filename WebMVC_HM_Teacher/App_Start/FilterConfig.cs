﻿using System.Web;
using System.Web.Mvc;

namespace WebMVC_HM_Teacher
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
