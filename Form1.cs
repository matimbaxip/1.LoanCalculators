using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1.LoanCalculators
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMortgage_Click(object sender, EventArgs e)
        {
            // Create some local variables
            double loanAmount = 0.0;             
            double downPayment = 0.0;
            double interestRate = 0.0;
            double monthlyPayment = 0.0;
            int termsinMonths = 0;

            // Do some validation 
            if (!String.IsNullOrEmpty(txtLoanAmount.Text))
                loanAmount = Convert.ToDouble(txtLoanAmount.Text);

            if (!String.IsNullOrEmpty(txtDownPayment.Text))
                downPayment = Convert.ToDouble(txtDownPayment.Text);

            if (!String.IsNullOrEmpty(txtInterestRate.Text))
                interestRate = Convert.ToDouble(txtInterestRate.Text);

            if (!String.IsNullOrEmpty(txtTerms.Text))
                termsinMonths = Convert.ToInt32(txtTerms.Text);

            // Mortgage Payment calculation logic 
            // Formula: Payment = (Loan Amount - Down Payment) * (1 + Interest Rate / 12)^(Terms * 12)             int termsinMonths = terms * 12; 
            monthlyPayment = (loanAmount - downPayment) * (Math.Pow((1 + interestRate / 12),
                termsinMonths) * interestRate) / (12 * (Math.Pow((1 + interestRate / 12),
                termsinMonths) - 1)); monthlyPayment = Math.Round(monthlyPayment, 2);

            // Display the result 
            lblMonthlyPayment.Text = monthlyPayment.ToString();



        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            // Create some local variables
            double loanAmount = 0.0;             
            double downPayment = 0.0;
            double interestRate = 0.0;
            double monthlyPayment = 0.0; 
            int terms = 0;

            // Do some validation 
            if (!String.IsNullOrEmpty(txtLoanAmount.Text)) 
                loanAmount = Convert.ToDouble(txtLoanAmount.Text);

            if (!String.IsNullOrEmpty(txtDownPayment.Text))
                downPayment = Convert.ToDouble(txtDownPayment.Text);

            if (!String.IsNullOrEmpty(txtInterestRate.Text)) 
                interestRate = Convert.ToDouble(txtInterestRate.Text);

            if (!String.IsNullOrEmpty(txtTerms.Text)) 
                terms = Convert.ToInt32(txtTerms.Text);

            // Mortgage Payment calculation logic 
            // Formula: Payment = (Loan Amount * Interest Rate) / (1-(1 + Interest Rate)^Terms

            int termsinMonths = terms * 12;
            interestRate /= 12;
            monthlyPayment = (interestRate * loanAmount) / (1 - Math.Pow(1 + interestRate, termsinMonths * -1));
            monthlyPayment = Math.Round(monthlyPayment, 2);

            // Display the result 
            lblMonthlyPayment.Text = String.Format("Monthly Payment: R {0}", monthlyPayment.ToString());









        }
    }
}
