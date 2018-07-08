using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlueCom
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //  <Button Text="Calculate" x:Name="calculateButton" Clicked="handleCalculateButtonClick
        //You may have to change the Name depending on how you name that handler in xaml

        public void handleCalculateButtonClick(object sender, EventArgs args)
        {//percentOnFirst100K
            //grossPaymentFinalValue
            grossPaymentFinalValue.IsVisible = true;
            grossPaymentFinalValue.Text = grossPaymentFinalValue.Text + percentOnFirst100K.Text;

        }
    }
}
