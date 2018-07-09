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
        {
            // calculate gross commission
            grossPaymentFinalValue.IsVisible = true;


            double tryParsePercentOnFirst100KGross;
            double.TryParse(percentOnFirst100KGross.Text, out tryParsePercentOnFirst100KGross);
            double percentOnFirst100KGrossValue = (100000 * (tryParsePercentOnFirst100KGross / 100));

            double tryParsePropertyPrice;
            double.TryParse(propertyPrice.Text, out tryParsePropertyPrice);
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

            grossPaymentFinalValue.Text = grossPaymentFinalValue.Text + "$" + grossPaymentCalculated.ToString();







            // calculate buyer commission
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

            buyerPaymentFinalValue.Text = buyerPaymentFinalValue.Text + "$" + buyerPaymentCalculated.ToString();


            listingPaymentFinalValue.IsVisible = true;
            listingPaymentFinalValue.Text = listingPaymentFinalValue.Text + "$" + (grossPaymentCalculated - buyerPaymentCalculated).ToString();

        }




        /* Listing commission  =  Seller Commission
         * 
         * 
         *   <StackLayout Orientation="Vertical" Margin="0,20,0,0">
            <Label Text="3.  Buyer Commission" Margin="20,0,0,10" FontAttributes="Bold">
            </Label>
            <StackLayout Orientation="Horizontal">
                <Entry Placeholder="Ex: 2%" x:Name="percentOnFirst100KBuyer" WidthRequest="100" Margin="50,0,0,0" />
                <Label Text="% on 1st 100K" Margin="0,0,0,0" VerticalTextAlignment="End" />
            </StackLayout>
            <StackLayout Orientation="Horizontal">
                <Entry Placeholder="Ex: 2%" WidthRequest="100" Margin="50,0,0,0" />
                <Label Text="% on Balance" x:Name="percentOnBalanceBuyer" Margin="0,0,0,0" VerticalTextAlignment="End" />
            </StackLayout>
            <StackLayout Orientation="Horizontal">
                <Entry Placeholder="Ex: 5,000" WidthRequest="100" Margin="50,0,0,0" />
                <Label Text="Additional Bonus" x:Name="grossAdditionalBonusBuyer" VerticalTextAlignment="End" />
            </StackLayout>
            <StackLayout Orientation="Horizontal" Margin="50,0,0,0">
                <Entry Placeholder="Ex: 1,000" WidthRequest="100" />
                <Label Text="Minus Deductions" x:Name="grossDeductionBuyer" VerticalTextAlignment="End" />
            </StackLayout>
            <StackLayout Orientation="Horizontal" Margin="0,20,0,0" HorizontalOptions="Center">
                <Button Text="Calculate" x:Name="calculateButton" Clicked="handleCalculateButtonClick" WidthRequest="100" BackgroundColor="Silver" BorderRadius="10" BorderWidth="1" BorderColor="Black" Margin="0,0,10,0" HorizontalOptions="Start" />
                <Button Text="Reset" WidthRequest="100" BackgroundColor="Silver" BorderRadius="10" BorderWidth="1" BorderColor="Black" Margin="10,0,0,0" HorizontalOptions="Start" />
            </StackLayout>
         */
        /*
         *       <StackLayout Orientation="Vertical" Margin="0,20,0,0">
            <Label Text="2.  Gross Commission" Margin="20,0,0,10" FontAttributes="Bold">
            </Label>
            <StackLayout Orientation="Horizontal">
                <Entry Placeholder="Ex: 2%" x:Name="percentOnFirst100KGross" WidthRequest="100" Margin="50,0,0,0" />
                <Label Text="% on 1st 100K" Margin="0,0,0,0" VerticalTextAlignment="End" />
            </StackLayout>
            <StackLayout Orientation="Horizontal">
                <Entry Placeholder="Ex: 2%" x:Name="percentOnBalanceGross" WidthRequest="100" Margin="50,0,0,0" />
                <Label Text="% on Balance" Margin="0,0,0,0" VerticalTextAlignment="End" />
            </StackLayout>
            <StackLayout Orientation="Horizontal">
                <Entry Placeholder="Ex: 5,000" x:Name="grossAdditionalBonus" WidthRequest="100" Margin="50,0,0,0" />
                <Label Text="Additional Bonus" VerticalTextAlignment="End" />
            </StackLayout>
            <StackLayout Orientation="Horizontal" Margin="50,0,0,0">
                <Entry Placeholder="Ex: 1,000" WidthRequest="100" />
                <Label Text="Minus Deductions" x:Name="grossDeduction" VerticalTextAlignment="End" />
            </StackLayout>
        </StackLayout>
         */
    }
}
