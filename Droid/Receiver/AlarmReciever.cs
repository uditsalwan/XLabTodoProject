
using Android.App;
using Android.Content;
using Android.Widget;
using Java.Util;
using Java.Lang;

namespace ToDoList.Droid
{
    [BroadcastReceiver]
    public class AlarmReciever : BroadcastReceiver
    {
        internal static string CONTENT = "content";

        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "AlarmReciever Received intent!", ToastLength.Long).Show();

            int groupId = (int)((new Date().Time / 1000L) % Integer.MaxValue);
            ShowNotification(context, intent, groupId, 1);
        }

        private void ShowNotification(Context context, Intent intent, int groupId, int itemId)
        {
            var content = intent.GetStringExtra(CONTENT);
            Notification.Builder builder = new Notification.Builder(context);
            builder.SetContentTitle("Scheduled Notification");
            builder.SetContentText(content + groupId + "." + itemId);
            builder.SetSmallIcon(Resource.Drawable.icon);

            var notification = builder.Build();

            NotificationManager notificationManager = NotificationManager.FromContext(context);

            notificationManager.Notify(groupId + itemId, notification);
        }
    }
}