using System;
using System.Collections.Generic;

namespace UCP1PraktikumPAW.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
            Pembayaran = new HashSet<Pembayaran>();
        }

        public int IdCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public string EmailCustomer { get; set; }
        public string AlamatCustomer { get; set; }
        public string NoHpCustomer { get; set; }

        public ICollection<Order> Order { get; set; }
        public ICollection<Pembayaran> Pembayaran { get; set; }
    }
}
