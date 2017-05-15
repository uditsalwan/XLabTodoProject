
using Android.App;
using Android.Content;
using Android.Widget;
using Java.Util;
using Java.Lang;
using System.Collections.Generic;

namespace ToDoList.Droid
{
    [BroadcastReceiver]
    public class AlarmReciever : BroadcastReceiver
    {
        internal static string CONTENT = "content";

        public async override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "AlarmReciever Received intent!", ToastLength.Long).Show();

            List<TodoItem> todayTodoItems = await App.DatabaseHandler.GetTodayTodoItemList();

            int groupId = (int)((new Date().Time / 1000L) % Integer.MaxValue);

            foreach (TodoItem item in todayTodoItems)
            {
                ShowNotification(context, intent, groupId, item);
            }
        }

        private void ShowNotification(Context context, Intent intent, int groupId, TodoItem item)
        {
            var content = intent.GetStringExtra(CONTENT);
            Notification.Builder builder = new Notification.Builder(context);
            builder.SetContentTitle(item.title);
            builder.SetContentText(item.details);
            builder.SetSmallIcon(Resource.Drawable.icon);

            var notification = builder.Build();

            NotificationManager notificationManager = NotificationManager.FromContext(context);

            notificationManager.Notify(groupId + item.ID, notification);
        }
    }
}