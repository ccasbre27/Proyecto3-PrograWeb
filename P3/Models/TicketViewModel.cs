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
            List<int> disabledItems = new List<int>();

            for (int i = 0, tam = sectionsList.Count; i < tam; i++)
            {
                // se verifica si se tiene que deshabilitar alguna opción
                if (sectionsList[i].QuantitySeatsAvailable == 0)
                {
                    // se agrega a la lista de opciones a deshabilitar la posición del elemento
                    // se le agrega 1 ya que en el dropdown se inicia a contar en 1
                    disabledItems.Add(i + 1);
                }
                
            }
            
            SectionsSelectList = new SelectList(sectionsList, "Id", "Name", "1", disabledValues: disabledItems);
        }

    }
}