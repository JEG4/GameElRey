namespace GameElRey
{
    public class Equipment
    {
        public Equipment(string type, Statistic stats)// should be large array like worker and army
        {
            EquipmentType = type;
            EquipmentStats = stats;
            //"SWORD"


        }

        public string EquipmentType { get; set; }
        public Statistic EquipmentStats { get; }
    }
}