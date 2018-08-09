using System;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
	{
        string translateNumber;

        public MainPage()
		{
			InitializeComponent();
		}

        void OnTranslate(object sender, EventArgs e)
        {
            translateNumber = PhonewordTranslator.ToNumber(phoneNumberText);

            if (!string.IsNullOrWhiteSpace(translateNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translateNumber;
            }
            else
            {

            }
        }
    }
}
