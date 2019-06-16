[System.Serializable]
public class StatBonus
{
    public string AssociatedStatName;
    public int BonusValue;

    public StatBonus(string associatedStatName, int bonusValue)
    {
        this.AssociatedStatName = associatedStatName;
        this.BonusValue = bonusValue;
    }
}