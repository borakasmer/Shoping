using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Shop
    {
        public int id { get; set; }
        public int itemID { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int UserID { get; set; }
    }
}
