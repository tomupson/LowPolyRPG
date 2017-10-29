using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStat
{
    [HideInInspector] public List<StatBonus> BaseStatBonuses;
    public int BaseValue;
    public string StatName;
    public string StatDescription;
    private int FinalValue;

    public int GetFinalStatValue()
    {
        this.FinalValue = 0;
        this.FinalValue += BaseValue;
        this.BaseStatBonuses.ForEach(x =>
        {
            this.FinalValue += x.BonusValue;
        });

        return this.FinalValue;
    }
}