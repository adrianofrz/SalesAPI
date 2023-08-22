using System;
using System.Collections.Generic;

namespace SalesAPI.DbModel
{
    public partial class Department
    {
        public Department()
        {
            //Seller = new HashSet<Seller>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

       // public ICollection<Seller> Seller { get; set; }
    }
}
