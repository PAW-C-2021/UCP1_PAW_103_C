using System;
using System.Collections.Generic;

namespace UCP1PraktikumPAW.Models
{
    public partial class Produk
    {
        public Produk()
        {
            Order = new HashSet<Order>();
        }

        public int IdProduk { get; set; }
        public int? IdPenjual { get; set; }
        public int? HargaProduk { get; set; }
        public int? StokBarang { get; set; }
        public string NamaProduk { get; set; }

        public Penjual IdPenjualNavigation { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
