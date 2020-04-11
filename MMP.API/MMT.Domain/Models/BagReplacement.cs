using System;

namespace MMT.Domain.Models
{
    public class BagReplacement
    {
        public long Id { get; set; }
        public int CellNo { get; set; }
        public string DamageCode { get; set; }
        public DateTime DateReplaced { get; set; }
        public string BagLocation { get; set; }
    }
}
