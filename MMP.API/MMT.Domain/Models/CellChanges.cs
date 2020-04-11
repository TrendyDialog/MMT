namespace MMT.Domain.Models
{
    public class CellChanges
    {
        public long Id { get; set; }
        public string CellName { get; set; }
        public int CellColumn { get; set; }
        public string CellRow { get; set; }
    }
}
