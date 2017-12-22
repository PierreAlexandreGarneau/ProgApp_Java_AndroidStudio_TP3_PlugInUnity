using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Energy Energy;
    public Text PointEnergieText;

    public Ressource1 Ressource1;
    public Text Ressource1Text;

    public Ressource2 Ressource2;
    public Text Ressource2Text;

    public Dropdown DdConstruction;
    public Construction CurrentConstruct;
    public Text ConstructionInfo;
    public Text ActifInfo;



    List<Construction> Constructions = new List<Construction>();

    void Start ()
    {
        DropDownConstruireChanged(0);
        DropDownActifChanged(0);
    }
	
	void Update ()
    {
        PointEnergieText.text = Energy.Current.ToString() + "/" + Energy.Max.ToString();
        ActifInfo.text = CurrentActif.Information();
    }

    public void NotificationsImmediates()
    {
        AndroidPlugin.ScheduleNotification(new Notification(1, "Notifications immédiates", 0));
    }

    public void NotificationsDifferees()
    {
        AndroidPlugin.ScheduleNotification(new Notification(2, "Notifications différées", 1500));
    }

    public void Annulation1()
    {
        AndroidPlugin.AnnulationNotification1(1);
    }

    public void Annulation2()
    {
        AndroidPlugin.AnnulationNotification2(2);
    }


    public void EffacerTout()
    {
        AndroidPlugin.EffacerNotification(2);
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Energy.Save();
            GameData.SetLastPauseDateTime();
            AndroidPlugin.ScheduleNotification(Energy.GetNotification());
        }
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        Energy.Load();
        Ressource1.Load();
        Ressource2.Load();
    }

    public void DropDownConstruireChanged(int index)
    {
        if (index == 0)
            CurrentConstruct = new Entrepot1();
        else if (index == 1)
            CurrentConstruct = new Entrepot2();
        else if (index == 2)
            CurrentConstruct = new Usine1();
        else
            CurrentConstruct = new Usine2();
        ConstructionInfo.text = CurrentConstruct.Information();
    }

    public void ButtonConstruire()
    {
        Constructions.Add(CurrentConstruct);
        DropDownActifChanged(0);
        InitRessource();
    }

    private void InitRessource()
    {
        DdConstruction.options = Constructions.Select((f) => new Dropdown.OptionData(f.Name())).ToList();

        var er1 = Constructions.OfType<Entrepot1>();
        Ressource1Text.text = Ressource1.Current + "/" + er1.Sum((f) => f.Capacity());

        var er2 = Constructions.OfType<Entrepot2>();
        Ressource2Text.text = Ressource2.Current + "/" + er2.Sum((f) => f.Capacity());
    }

    public Construction CurrentActif;

    public void DropDownActifChanged(int index)
    {
        if (Constructions.Any())
        {
            CurrentActif = Constructions[index];
            ActifInfo.text = CurrentActif.Information();
        }
    }
}
