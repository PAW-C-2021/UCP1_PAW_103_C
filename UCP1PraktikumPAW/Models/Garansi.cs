using System;
using System.Collections.Generic;

namespace UCP1PraktikumPAW.Models
{
    public partial class Garansi
    {
        public int IdGaransi { get; set; }
        public int? IdJasaKirim { get; set; }
        public string Kerusakan { get; set; }
        public string JenisGaransi { get; set; }

        public JasaKirim IdJasaKirimNavigation { get; set; }
    }
}
