using System;
using System.Collections.Generic;

namespace UCP1PraktikumPAW.Models
{
    public partial class Order
    {
        public Order()
        {
            JasaKirim = new HashSet<JasaKirim>();
            Pembayaran = new HashSet<Pembayaran>();
        }

        public int IdOrder { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdProduk { get; set; }
        public string NamaProduk { get; set; }
        public int? TotalHarga { get; set; }
        public DateTime? TanggalOrder { get; set; }

        public Customer IdCustomerNavigation { get; set; }
        public Produk IdProdukNavigation { get; set; }
        public ICollection<JasaKirim> JasaKirim { get; set; }
        public ICollection<Pembayaran> Pembayaran { get; set; }
    }
}
