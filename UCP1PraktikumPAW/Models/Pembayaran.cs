using System;
using System.Collections.Generic;

namespace UCP1PraktikumPAW.Models
{
    public partial class Pembayaran
    {
        public int IdPembayaran { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdOrder { get; set; }
        public int? TotalHarga { get; set; }
        public string ViaPembayaran { get; set; }

        public Customer IdCustomerNavigation { get; set; }
        public Order IdOrderNavigation { get; set; }
    }
}
