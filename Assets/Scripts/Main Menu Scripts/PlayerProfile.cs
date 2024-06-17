using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerProfile
{
    private const string GOLD_KEY = "GOLD_KEY";

    public static int Gold
    {
        get
        {
            return PlayerPrefs.GetInt(GOLD_KEY, 9999);
        }
        set
        {
            PlayerPrefs.SetInt(GOLD_KEY, value);
        }
    }
}
