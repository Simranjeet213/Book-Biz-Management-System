using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookBizapp2102116.BLL;
using System.IO;
using BookBizapp2102116.DAL;

namespace BookBizapp2102116
{
    public partial class OrderForm : Form
    {
        List<Orders> listO = new List<Orders>();
        public OrderForm()
        {
            InitializeComponent();
            buttonList.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            List<Orders> listO = OrderDA.ListOrders();
            //  if ((Validator.IsValidISBN(textBoxISBN))&& (Validator.IsValidTitle(textBoxBooktitle))&& (Validator.IsValidPrice(textBoxUnitPrice))&&(Validator.IsValidYear(textBoxYearPublished))&& (Validator.IsValidQOH(textBoxQOH))&&(Validator.IsValidID(textBoxAuthorId)) && (Validator.IsValidName(textBoxAuthorFirst)) && (Validator.IsValidName(textBoxAuthorLast)) )
            //{
           Orders o = new Orders();
            o.OrderId = Convert.ToInt32(textBoxOrderId.Text);
            o.Phone = maskedTextBoxPhone.Text;
            o.Fax = textBoxFax.Text;
            
            o.Email = textBoxEmail.Text;
            
           OrderDA.Save
              (o);




            ClearAll();

        }

        private void ClearAll()
        {
            textBoxOrderId.Clear();
            maskedTextBoxPhone.Clear();
            textBoxFax.Clear();
            textBoxEmail.Clear();

          

        }

        private void buttonList_Click(object sender, EventArgs e)
        {

            listViewOrder.Items.Clear();
            OrderDA.ListOrders(listViewOrder);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int choice = comboBox1.SelectedIndex;
            switch (choice)
            {
                case 0:

                    textBoxInputInfo.Focus();
                    break;
                default:
                    break;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int choice = comboBox1.SelectedIndex;

            switch (choice)
            {
                case -1: // The user didn't select any search option
                    MessageBox.Show("Please select the search option");
                    break;
                case 0: //The user selected the search by Customer ID
                    Orders o = OrderDA.Search(Convert.ToInt32(textBoxInputInfo.Text));
                    if (o != null)
                    {
                        textBoxOrderId.Text = o.OrderId.ToString(); ;
                        maskedTextBoxPhone.Text = o.Phone;
                        textBoxFax.Text = o.Fax;
                        textBoxEmail.Text = o.Email ;

                        


                    }

                    else
                    {
                        MessageBox.Show("Orders not Found!");
                        textBoxInputInfo.Clear();
                        textBoxInputInfo.Focus();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
