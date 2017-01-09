using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.HelperFunction
{
    public class DayList : List<SelectListItem>
    {
        public DayList()
        {
            Add(new SelectListItem
            {
                Text="Mandag",
                Value="Mandag"
            });
            Add(new SelectListItem
            {
                Text = "Tirsdag",
                Value = "Tirsdag"
            });
            Add(new SelectListItem
            {
                Text = "Onsdag",
                Value = "Onsdag"
            });
            Add(new SelectListItem
            {
                Text = "Torsdag",
                Value = "Torsdag"
            });
            Add(new SelectListItem
            {
                Text = "Fredag",
                Value = "Fredag"
            });
        }
    }
}