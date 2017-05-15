using System;

using Android.App;
using Android.Content;
using Android.Widget;
using Java.Util;
using Android.Content.PM;

namespace ToDoList.Droid
{
    class Utils
    {
        public static void ScheduleNotification(Context context, String content)
        {
            //Toast.MakeText(context, "ScheduleNotification()", ToastLength.Long).Show();
            EnableBootReceiver(context);
            ScheduleAlarmManager(context, content);
        }

        public static void ScheduleAlarmManager(Context context, string content)
        {
            if (IsAlarmSet(context, content))
            {
                Toast.MakeText(context, "Alarm is already set", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(context, "ScheduleAlarmManager()", ToastLength.Long).Show();
                AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);

                Calendar calendar = Calendar.GetInstance(Java.Util.TimeZone.Default);
                calendar.Set(CalendarField.HourOfDay, 12);
                calendar.Set(CalendarField.Minute, 1);

                alarmManager.SetInexactRepeating(AlarmType.RtcWakeup, calendar.TimeInMillis,
                    60 * 1000, GetPendigIntent(context, content)); // AlarmManager.IntervalDay
            }
        }

        private static PendingIntent GetPendigIntent(Context context, string content)
        {
            Intent alarmRecieverIntent = new Intent(context, typeof(AlarmReciever));
            alarmRecieverIntent.PutExtra(AlarmReciever.CONTENT, content);

            PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, 0,
                alarmRecieverIntent, PendingIntentFlags.UpdateCurrent);

            return pendingIntent;
        }

        private static void EnableBootReceiver(Context context)
        {
            var packageManager = context.PackageManager;
            var componentName = new ComponentName(context, Java.Lang.Class.FromType(typeof(BootReceiver))); // "AlarmSchedule.Droid.SampleBootReceiver"
            packageManager.SetComponentEnabledSetting(componentName, ComponentEnabledState.Enabled,
                ComponentEnableOption.DontKillApp);
        }

        private static Boolean IsAlarmSet(Context context, String content)
        {
            Intent alarmRecieverIntent = new Intent(context, typeof(AlarmReciever));
            alarmRecieverIntent.PutExtra(AlarmReciever.CONTENT, content);
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, 0,
                alarmRecieverIntent, PendingIntentFlags.NoCreate);

            return pendingIntent != null;
        }
    }
}