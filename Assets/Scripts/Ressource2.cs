using System;
using UnityEngine;

public class Ressource2 : MonoBehaviour
{

    public int Current;
    public int Max;
    public float Delta;
    public float IncreasePerSec;

    public const string MaxEnergy = "MaxEnergy";
    public const string CurrentEnergy = "CurrentEnergy";

    void Start()
    {
        Load();
    }

    void Update()
    {
        Delta += Time.deltaTime;

        if (Delta >= IncreasePerSec && Current < Max)
        {
            Current += 1;
            Delta = 0;
        }
    }

    private void InitMax()
    {
        Max = GameData.GetMaxEnergy();
    }

    private void InitIncreasePerSec()
    {
        IncreasePerSec = GameData.GetEnergyIncreasePerSec();
    }

    private void InitCurrent()
    {
        Current = GameData.GetCurrentEnergy();

        var lastPause = GameData.GetLastPauseDateTime();
        if (lastPause.HasValue)
        {
            var timeSpand = DateTime.UtcNow - lastPause.Value;
            var AddToCurrent = (float)timeSpand.TotalSeconds / IncreasePerSec;
            Current = Current + (int)AddToCurrent;
            Delta = AddToCurrent - (int)AddToCurrent;
            if (Current > Max)
                Current = Max;
        }

    }

    public Notification GetNotification()
    {
        if (Current < Max)
            return new Notification(5997348, "Points d'energie plein", (int)(1000 * (Max - Current) * IncreasePerSec));
        else
            return null;
    }

    public void Load()
    {
        InitMax();
        InitIncreasePerSec();
        InitCurrent();
    }

    public void Save()
    {
        GameData.SetCurrentEnergy(Current);
    }
}
