using System;
using System.Collections.Generic;

namespace UCP1PraktikumPAW.Models
{
    public partial class Penjual
    {
        public Penjual()
        {
            Produk = new HashSet<Produk>();
        }

        public int IdPenjual { get; set; }
        public string NamaPenjual { get; set; }
        public string EmailPenjual { get; set; }
        public string AlamatPenjual { get; set; }
        public string NoHpPenjual { get; set; }

        public ICollection<Produk> Produk { get; set; }
    }
}
