using System;

namespace MMT.Service.ViewModels
{
    public class BagReplacementViewModel
    {
        public long Id { get; set; }
        public int CellNo { get; set; }
        public string DamageCode { get; set; }
        public DateTime DateReplaced { get; set; }
        public string BagLocation { get; set; }
    }
}
