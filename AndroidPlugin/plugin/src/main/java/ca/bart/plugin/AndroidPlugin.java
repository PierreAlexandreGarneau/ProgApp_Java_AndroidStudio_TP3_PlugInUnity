package ca.bart.plugin;

import android.app.AlarmManager;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;

import android.content.Intent;
import android.os.SystemClock;
import android.util.Log;

import com.unity3d.player.UnityPlayer;

public class AndroidPlugin {


    public static void ScheduleNotification(long delay, String message, int id) {

        Intent intent = new Intent(UnityPlayer.currentActivity, AlarmReceiver.class);
        intent.putExtra("ID", id);
        intent.putExtra("MESSAGE", message);

        PendingIntent pendingIntent = PendingIntent.getBroadcast(UnityPlayer.currentActivity, id, intent, PendingIntent.FLAG_ONE_SHOT | PendingIntent.FLAG_UPDATE_CURRENT);

        AlarmManager alarmManager = (AlarmManager) UnityPlayer.currentActivity.getSystemService(Context.ALARM_SERVICE);
        alarmManager.setExact(AlarmManager.ELAPSED_REALTIME,SystemClock.elapsedRealtime() + delay, pendingIntent);
    }
    public static void AnnulationNotification1(int id) {

        Intent intent = new Intent(UnityPlayer.currentActivity, AlarmReceiver.class);
        intent.putExtra("ID", id);

        PendingIntent pendingIntent = PendingIntent.getBroadcast(UnityPlayer.currentActivity, id, intent,PendingIntent.FLAG_ONE_SHOT | PendingIntent.FLAG_UPDATE_CURRENT);
        AlarmManager alarmManager = (AlarmManager) UnityPlayer.currentActivity.getSystemService(Context.ALARM_SERVICE);
        alarmManager.cancel(pendingIntent);

        NotificationManager notificationManager = (NotificationManager) UnityPlayer.currentActivity.getSystemService(Context.NOTIFICATION_SERVICE);
        notificationManager.cancel(id);
    }

    public static void AnnulationNotification2(int id) {

        Intent intent = new Intent(UnityPlayer.currentActivity, AlarmReceiver.class);
        intent.putExtra("ID", id);

        PendingIntent pendingIntent = PendingIntent.getBroadcast(UnityPlayer.currentActivity, id, intent,PendingIntent.FLAG_ONE_SHOT | PendingIntent.FLAG_UPDATE_CURRENT);
        AlarmManager alarmManager = (AlarmManager) UnityPlayer.currentActivity.getSystemService(Context.ALARM_SERVICE);
        alarmManager.cancel(pendingIntent);

        NotificationManager notificationManager = (NotificationManager) UnityPlayer.currentActivity.getSystemService(Context.NOTIFICATION_SERVICE);
        notificationManager.cancel(id);
    }
    public static void EffacerNotification(int id) {

        Intent intent = new Intent(UnityPlayer.currentActivity, AlarmReceiver.class);

        PendingIntent pendingIntent = PendingIntent.getBroadcast(UnityPlayer.currentActivity,id, intent,PendingIntent.FLAG_ONE_SHOT | PendingIntent.FLAG_UPDATE_CURRENT);
        AlarmManager alarmManager = (AlarmManager) UnityPlayer.currentActivity.getSystemService(Context.ALARM_SERVICE);
        alarmManager.cancel(pendingIntent);

        NotificationManager EffacerNotification = (NotificationManager) UnityPlayer.currentActivity.getSystemService(Context.NOTIFICATION_SERVICE);
        EffacerNotification.cancel(id);
        EffacerNotification.cancelAll();
    }
    public static int GetExtraID() {
        return UnityPlayer.currentActivity.getIntent().getIntExtra("ID", -1);
    }

    public static void Back() {
        UnityPlayer.currentActivity.onBackPressed();
    }
}
