using UnityEngine;

public static class AndroidPlugin {

    public static void ScheduleNotification(Notification notification)
    {
        if (notification != null)
        { 
            using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("ca.bart.plugin.AndroidPlugin"))
            {
                androidJavaClass.CallStatic("ScheduleNotification", notification.DelayInMilisec, notification.Message, notification.Id);
            }
        }
    }


    public static void AnnulationNotification1(int id)
    {
        using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("ca.bart.plugin.AndroidPlugin"))
        {
            androidJavaClass.CallStatic("AnnulationNotification1", id);
        }
        
    }

    public static void AnnulationNotification2(int id)
    {
        using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("ca.bart.plugin.AndroidPlugin"))
        {
            androidJavaClass.CallStatic("AnnulationNotification2", id);
        }

    }

    public static void EffacerNotification(int id)
    {
        using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("ca.bart.plugin.AndroidPlugin"))
        {
            androidJavaClass.CallStatic("EffacerNotification", id);
        }

    }
}

public class Notification
{
    public int Id;
    public string Message;
    public long DelayInMilisec;

    public Notification(int id, string message, int delayInMilisec)
    {
        this.Id = id;
        this.Message = message;
        this.DelayInMilisec = delayInMilisec;
    }
}
