
    public class LottoTip
    {
        public string TippersName { get; set; }
    public List<int> Tipps { get; set; }

    public int CorrectTips { get; set; }

    public LottoTip() { }
    public LottoTip(string tippersName, List<int> tipps) {
        TippersName = tippersName;
        Tipps = tipps;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{TippersName} tippjei: ");
        foreach (int i in Tipps)
        {
            sb.Append($"{i}, ");
        }

        return sb.ToString();
    }
}
