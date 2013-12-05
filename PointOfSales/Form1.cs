using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/* *
 * FAROUK OSUMAN
 * INFORMATION SYSTEM SCIENCE(EVENING)
 * APPLICATION PROGRAMMING USING C#
 * POINT OF SALES SYSTEM (ASSIGNMENT)
 * */
namespace PointOfSales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //declaring total price of items in txtdue
        decimal total =0;
        
        
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            int qty = 0;
            if (cboItems.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item!");
                cboItems.Focus();
                return;
            }
            //
            if (!string.IsNullOrEmpty(txtQty.Text))
            {
                try
                {
                    //to display total amount to pay for items added in cart
                    qty = int.Parse(txtQty.Text);
                   total=total+ decimal.Parse((2.5*qty)+"");
                    txtDue.Text=total.ToString();    
               }
                catch (Exception eex)
                {
                    //display error message when quantity is not entered
                    MessageBox.Show("Invalid quantity",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(eex.Message + " occurred in btnAddtoCart");
                    return;
                }

            }
            else if (string.IsNullOrEmpty(txtQty.Text))
            {
                MessageBox.Show("Please specify qty!");
                txtQty.Focus();
                return;
            }
            //calculation of items selected and quantities entered
            string item = cboItems.Text;
            decimal price = 2.5m;
            
            decimal ExtPrice = price * qty;

            string[] cartline = {
                                     item, 
                                     price.ToString("F2"),
                                     qty.ToString(),
                                     ExtPrice.ToString("F2")
                                 };

            dgvCart.Rows.Add(cartline);
            //function call
            ClearEntry();

            
        }
        //furnction to clear selection and quantity entered
        private void ClearEntry()
        {
            cboItems.SelectedIndex = -1;
            txtQty.Text = "";
        }

        private void txtDue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int qty = int.Parse(txtQty.Text);
                string item = cboItems.Text;
                decimal price = 2.5m;
                decimal ExtPrice = price * qty;
            }

            catch (Exception xx)
            {
                MessageBox.Show("invalid entry");
            }
        }
     
    

        

        private void btnFinish_Click(object sender, EventArgs e)
        {

            //amount entered by user for payment of price due
            decimal paid = decimal.Parse((txtPaid.Text) + "");
            if (paid >= total)
            {
                //change to been given to customer after payment
                decimal change = paid - total;
                txtChange.Text = change.ToString();
                MessageBox.Show("Thanks for the transaction. Printing Receipt....");
            }
            else
            {
                // if payment is lower than the amount due for items purchase
                MessageBox.Show("Amount paid is below the due amount");
            }
           
        }
    
           
        }
    }

