
using Android.App;
using Android.Content;
using Android.Widget;

namespace ToDoList.Droid
{
    [BroadcastReceiver(Enabled = false, Exported = true)]
    [IntentFilter(new[] { Android.Content.Intent.ActionBootCompleted })]
    public class BootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "BootReceiver", ToastLength.Long).Show();
            if (intent != null && Intent.ActionBootCompleted.Equals(intent.Action))
            {
                Toast.MakeText(context, "BootReceiver : Boot completed", ToastLength.Long).Show();
                // Set the alarm here again.
                Utils.ScheduleAlarmManager(context, "Content body from BootReceiver");
            }
        }
    }
}