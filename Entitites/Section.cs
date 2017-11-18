using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites
{
    [JsonObject]
    public class Section
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public decimal Price { get; set; }

        [JsonProperty]
        public int QuantityTotalSeats { get; set; }

        [JsonProperty]
        public int QuantityCourtesySeats { get; set; }

        [JsonProperty]
        public int QuantitySeatsSold { get; set; }

        [JsonProperty]
        public int QuantitySeatsAvailable
        {
            get
            {
                return QuantityTotalSeats - QuantitySeatsSold;
            }
        }



        public Section()
        {

        }

        public Section(int id, string name, decimal price, int totalSeats, int courtesySeats)
        {
            Id = id;
            Name = name;
            Price = price;
            QuantityTotalSeats = totalSeats;
            QuantityCourtesySeats = courtesySeats;
        }

    }
}
