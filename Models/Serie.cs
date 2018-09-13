using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serview.Models
{
    public class Serie
    {
        //Properties
        public int SerieId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        //Connections
        public ICollection<Rating> Ratings { get; set; }
    }
}
