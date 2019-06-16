using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Alert
{
    public string alertName;
    public string alertText;
    public float displayTime;

    public Alert(string alertName, string alertText, float displayTime)
    {
        this.alertName = alertName;
        this.alertText = alertText;
        this.displayTime = displayTime;
    }
}