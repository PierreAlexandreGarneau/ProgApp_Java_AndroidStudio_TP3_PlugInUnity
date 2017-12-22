using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private const string CurrentEnergy = "CurrentEnergy";
    private const string CurrentRessource1 = "CurrentRessource1";
    private const string CurrentRessource2 = "CurrentRessource2";
    private const string LastPauseDateTime = "LastPauseDateTime";

    public static int DefaultMaxEnergy = 100;
    public static float DefaultEnergyIncreasePerSec = 0.5f;
    public static int DefaultCurrentRessource = 0;

    public static DateTime? GetLastPauseDateTime()
    {
        if (PlayerPrefs.HasKey(LastPauseDateTime))
            return DateTime.Parse(PlayerPrefs.GetString(LastPauseDateTime));
        else
            return null;
    }

    public static int GetMaxEnergy()
    {
        return DefaultMaxEnergy;
    }

    public static float GetEnergyIncreasePerSec()
    {
        return DefaultEnergyIncreasePerSec;
    }

    public static int GetCurrentEnergy()
    {
        return GetCurrentRessource(CurrentEnergy);
    }

    public static int GetCurrentRessource1()
    {
        return GetCurrentRessource(CurrentRessource1);
    }

    public static int GetCurrentRessource2()
    {
        return GetCurrentRessource(CurrentRessource2);
    }

    private static int GetCurrentRessource(string ressourceKey)
    {
        if (PlayerPrefs.HasKey(ressourceKey))
            return PlayerPrefs.GetInt(ressourceKey);
        else
            return DefaultCurrentRessource;
    }

    public static void SetCurrentEnergy(int current)
    {
        PlayerPrefs.SetInt(CurrentEnergy, current);
    }

    public static void SetLastPauseDateTime()
    {
        PlayerPrefs.SetString(LastPauseDateTime, DateTime.UtcNow.ToString());
    }
}
