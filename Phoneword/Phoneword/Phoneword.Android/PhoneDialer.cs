using Android.Content;
using Android.Telephony;
using Phoneword.Droid;
using System.Linq;
using Xamarin.Forms;
using Uri = Android.Uri;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Phoneword.Droid
{
    class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            var context = MainActivity.Instance;
            var intent = new Intent(Intent.ActionDial);
            intent.SetData(Uri.Parse("tel:" + number));

            if (context = null)
            {
                return false;
            }

            if (IsIntentAvailable(context, intent))
            {
                context.StartActivity(intent);
                return true;
            }

            return false;
        }

        static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;
            var list = packageManager.QueryIntentServices(intent, 0).
                        Union(packageManager.QueryIntentActivities(intent, 0));
            var manager = TelephonyManager.FromContext(context);

            if (list.Any())
            {
                return true;
            }

            return manager.PhoneType != PhoneType.None;
        }
    }
}