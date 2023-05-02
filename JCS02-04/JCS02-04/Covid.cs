namespace JCS02_04;

public class Covid
{
    public class Root
    {
        public DailyInformations[] data { get; set; }
        public DateTime Changed { get; set; }
        public string source { get; set; }
    }
    
    public class DailyInformations
    {
        public string datum { get; set; }
        public int prirustkovy_pocet_nakazenych { get; set; }
        public int kumulativni_pocet_nakazenych { get; set; }
    }
}