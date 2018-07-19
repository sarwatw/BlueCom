using System;
using System.Collections.Generic;
using System.Globalization;
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
            var propertyPrice = new DoneEntry();
            propertyPrice.Keyboard = Keyboard.Numeric; // optional, but this approach is especially useful for Numeric keyboard
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            grossPaymentFinalValue.IsVisible = false;
            buyerPaymentFinalValue.IsVisible = false;
            listingPaymentFinalValue.IsVisible = false;


        }

        private long getPropertyPrice()
        {
            string propertyPriceWithoutCommas = propertyPrice.Text;
            if (propertyPriceWithoutCommas != null)
            {
                propertyPriceWithoutCommas = propertyPriceWithoutCommas.Replace(",", "");
            }

            long tryParsePropertyPrice;
            long.TryParse(propertyPriceWithoutCommas, out tryParsePropertyPrice);

            return tryParsePropertyPrice;
        }

        private void doCalculation()
        {
            // Calculate Gross Commission
            grossPaymentFinalValue.IsVisible = true;


            double tryParsePercentOnFirst100KGross;
            double.TryParse(percentOnFirst100KGross.Text, out tryParsePercentOnFirst100KGross);
            double percentOnFirst100KGrossValue = (100000 * (tryParsePercentOnFirst100KGross / 100));

            long tryParsePropertyPrice = getPropertyPrice();
            double tryParsePercentOnBalanceGrossValue;
            double.TryParse(percentOnBalanceGross.Text, out tryParsePercentOnBalanceGrossValue);
            double percentOnBalanceGrossValue = (tryParsePropertyPrice - 100000) * (tryParsePercentOnBalanceGrossValue / 100);

            double tryParseGrossAdditionalBonus = 0;
            double.TryParse(grossAdditionalBonus.Text, out tryParseGrossAdditionalBonus);
            double tryParseGrossDeduction = 0;
            double.TryParse(grossDeduction.Text, out tryParseGrossDeduction);

            double grossPaymentCalculated = percentOnFirst100KGrossValue +
                                            percentOnBalanceGrossValue +
                                            tryParseGrossAdditionalBonus -
                                            tryParseGrossDeduction;

            if (this.gstSwitch.IsToggled)
            {
                double valueToAdd = (grossPaymentCalculated * (0.05));
                grossPaymentCalculated = grossPaymentCalculated + valueToAdd;
            }

            grossPaymentFinalValue.Text = "Gross Commission " + "$" + grossPaymentCalculated.ToString("N0");;


            // Calculate Buyer Commission
            buyerPaymentFinalValue.IsVisible = true;


            double tryParsePercentOnFirst100KBuyer;
            double.TryParse(percentOnFirst100KBuyer.Text, out tryParsePercentOnFirst100KBuyer);
            double percentOnFirst100KBuyerValue = (100000 * (tryParsePercentOnFirst100KBuyer / 100));

            double tryParsePercentOnBalanceBuyerValue;
            double.TryParse(percentOnBalanceBuyer.Text, out tryParsePercentOnBalanceBuyerValue);
            double percentOnBalanceBuyerValue = (tryParsePropertyPrice - 100000) * (tryParsePercentOnBalanceBuyerValue / 100);

            double tryParseBuyerAdditionalBonus = 0;
            double.TryParse(additionalBonusBuyer.Text, out tryParseBuyerAdditionalBonus);
            double tryParseBuyerDeduction = 0;
            double.TryParse(deductionBuyer.Text, out tryParseBuyerDeduction);

            double buyerPaymentCalculated = percentOnFirst100KBuyerValue +
                                            percentOnBalanceBuyerValue +
                                            tryParseBuyerAdditionalBonus -
                                            tryParseBuyerDeduction;

            if (this.gstSwitch.IsToggled)
            {
                double valueToAdd = (buyerPaymentCalculated * (0.05));
                buyerPaymentCalculated = buyerPaymentCalculated + valueToAdd;

            }
            buyerPaymentFinalValue.Text = "Buyer Commission " + "$" + buyerPaymentCalculated.ToString("N0");

            // Calculate Seller Commission
            listingPaymentFinalValue.IsVisible = true;
            double listingPaymentCalculated = grossPaymentCalculated - buyerPaymentCalculated;
            listingPaymentFinalValue.Text = "Listing Commission " + "$" + (listingPaymentCalculated).ToString("N0");
        }


        public void handleCalculateButtonClick(object sender, EventArgs args)
        {
            doCalculation();

        }

        public void handleResetButtonClick(object sender, EventArgs args)
        {
            propertyPrice.Text = null;
            percentOnFirst100KGross.Text = null;
            percentOnBalanceGross.Text = null;
            grossAdditionalBonus.Text = null;
            grossDeduction.Text = null;
            percentOnFirst100KBuyer.Text = null;
            percentOnBalanceBuyer.Text = null;
            additionalBonusBuyer.Text = null;
            deductionBuyer.Text = null;
        }

        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            doCalculation();
            if (propertyPrice.Text == null || propertyPrice.Text.Length == 0)
            {
                grossPaymentFinalValue.IsVisible = false;
                buyerPaymentFinalValue.IsVisible = false;
                listingPaymentFinalValue.IsVisible = false;
            }
        }

        void Entry_Completed(object sender, EventArgs e)
        {
            long tryParsePropertyPrice = getPropertyPrice();
           // long.TryParse(propertyPrice.Text, out tryParsePropertyPrice);
            propertyPrice.Text = tryParsePropertyPrice.ToString("N0");
           
        }





    }
}
