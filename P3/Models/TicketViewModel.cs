using Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P3.Models
{
    public class TicketViewModel
    {
        public SelectList SectionsSelectList { get; set; }

        public Section SelectedSection { get; set; }

        public int QuantityToBuy { get; set; }

        public TicketViewModel(List<Section> sectionsList)
        {
            SectionsSelectList = new SelectList(sectionsList, "Id", "Name");
        }
        
    }
}