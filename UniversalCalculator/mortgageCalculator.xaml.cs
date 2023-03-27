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
	public sealed partial class mortgageCalculator : Page
	{
		public mortgageCalculator()
		{
			this.InitializeComponent();
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double principalBorrow, yearlyInterest, monthlyInterest, monthlyRepayment, mathpow1, mathpow2, part1, part2;
			int years, months, totalMonths;

			//principalBorrow = double.Parse(principalBorrowTextBox.Text);
			//years = int.Parse(yearsTextBox.Text);
			//months = int.Parse(monthsTextBox.Text);
			//yearlyInterest = double.Parse(yearlyInterestTextBox.Text);
			//totalMonths = (years / 12) + months;

			//monthlyInterest = (yearlyInterest/100) / 12;
			//monthlyInterestTextBox.Text = monthlyInterest.ToString();

			//monthlyRepayment = (principalBorrow * (monthlyInterest * (Math.Pow((1 + monthlyInterest), totalMonths)))) / ((Math.Pow((1 + monthlyInterest), totalMonths)) - 1);
			//monthlyRepaymentTextBox.Text = monthlyRepayment.ToString();


			principalBorrow = double.Parse(principalBorrowTextBox.Text);
			years = int.Parse(yearsTextBox.Text);
			months = int.Parse(monthsTextBox.Text);
			yearlyInterest = double.Parse(yearlyInterestTextBox.Text);
			totalMonths = (years / 12) + months;

			monthlyInterest = (yearlyInterest / 100) / 12;
			monthlyInterestTextBox.Text = monthlyInterest.ToString();


			mathpow1 = Math.Pow((1 + monthlyInterest), totalMonths);
			mathpow2 = Math.Pow((1 + monthlyInterest), (totalMonths - 1));
			part1 = (monthlyInterest * mathpow1);
			part2 = mathpow2;

			monthlyRepayment = principalBorrow * (part1 / part2);
			monthlyRepaymentTextBox.Text = monthlyRepayment.ToString();
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
