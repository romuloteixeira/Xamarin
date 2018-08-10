using Foundation;
using UIKit;

namespace Phoneword
{
    class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            var retorno = UIApplication
                .SharedApplication
                .OpenUrl(
                    new NSUrl("tel:" + number)
                );

            return retorno;
        }
    }
}
