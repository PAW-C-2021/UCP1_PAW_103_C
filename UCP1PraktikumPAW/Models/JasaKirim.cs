using System;
using System.Collections.Generic;

namespace UCP1PraktikumPAW.Models
{
    public partial class JasaKirim
    {
        public JasaKirim()
        {
            Garansi = new HashSet<Garansi>();
        }

        public int IdJasaKirim { get; set; }
        public string NamaJasaKirim { get; set; }
        public int? IdOrder { get; set; }
        public DateTime? TanggalDiterima { get; set; }
        public string JenisLayanan { get; set; }
        public int? HargaJasa { get; set; }

        public Order IdOrderNavigation { get; set; }
        public ICollection<Garansi> Garansi { get; set; }
    }
}
