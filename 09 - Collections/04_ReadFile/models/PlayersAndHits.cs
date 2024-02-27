
public class PlayersAndHits
{
    public string TippersName { get; set; }

    public int CorrectTips { get; set; }

    public PlayersAndHits() { }
    public PlayersAndHits(string tippersName,int correctTips)
    {
        TippersName = tippersName;
        CorrectTips = correctTips;


    }

    public override string ToString()
    {
        return $"{TippersName}, találatok száma: {CorrectTips}";
    }
}
