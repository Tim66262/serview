using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serview.Models
{
    public class Rating
    {
        //Properties
        public int RatingId { get; set; }

        public int Stars { get; set; }

        //Connections
        public int SerieID { get; set; }

        public Serie Serie { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
