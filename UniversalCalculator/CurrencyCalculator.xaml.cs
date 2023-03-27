using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyCalculator : Page
	{
		public CurrencyCalculator()
		{
			this.InitializeComponent();
			this.convertFrom.DisplayMemberPath = "Text";
			this.convertFrom.SelectedValuePath = "Value";
			this.convertFrom.Items.Add(new { Text = "US - Dollar", Value = "USD" });
			this.convertFrom.Items.Add(new { Text = "EU - EURO", Value = "EU" });
			this.convertFrom.Items.Add(new { Text = "GBP - British Pound", Value = "GBP" });
			this.convertFrom.Items.Add(new { Text = "IC - Indian Rupee", Value = "IC" });


			this.convertTo.DisplayMemberPath = "Text";
			this.convertTo.SelectedValuePath = "Value";
			this.convertTo.Items.Add(new { Text = "US - Dollar", Value = "USD" });
			this.convertTo.Items.Add(new { Text = "EU - EURO", Value = "EU" });
			this.convertTo.Items.Add(new { Text = "GBP - British Pound", Value = "GBP" });
			this.convertTo.Items.Add(new { Text = "IC - Indian Rupee", Value = "IC" });
		}

		private void convert_Click(object sender, RoutedEventArgs e)
		{
			double amountToConvert;
			string convertFrom;
			string convertTo;

			amountToConvert = double.Parse(amountTextBox.Text);
			convertFrom = (string)this.convertFrom.SelectedValue;
			convertTo = (string)this.convertTo.SelectedValue;

			// Set conversion rates
			double usdRate = 1.0;
			double eurRate = 0.85189982;
			double gbpRate = 0.72872436;
			double icRate = 74.257327;

			// Convert input amount to USD
			double usdAmount = 0.0;
			switch (convertFrom)
			{
				case "USD":
					usdAmount = amountToConvert;
					break;
				case "EU":
					usdAmount = amountToConvert / eurRate;
					break;
				case "GBP":
					usdAmount = amountToConvert / gbpRate;
					break;
				case "IC":
					usdAmount = amountToConvert / icRate;
					break;
				default:
					break;
			}
			// Convert USD amount to desired currency
			double result = 0.0;

			switch (convertTo)
			{
				case "USD":
					result = usdAmount;
					break;
				case "EU":
					result = usdAmount * eurRate;
					break;
				case "GBP":
					result = usdAmount * gbpRate;
					break;
				case "IC":
					result = usdAmount * icRate;
					break;
				default:
					break;
			}


			summaryTextBox.Text = amountToConvert + " " + convertFrom + " = " + result + " " + convertTo;
        }

		private void exit_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
    }
}
