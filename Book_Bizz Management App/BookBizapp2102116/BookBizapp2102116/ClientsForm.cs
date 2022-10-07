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
    public partial class ClientsForm : Form
    {

        List<Clients> listC = new List<Clients>();
        public ClientsForm()
        {
            InitializeComponent();
            buttonList.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            List<Clients> listC = ClientDA.ListClients();
            //  if ((Validator.IsValidISBN(textBoxISBN))&& (Validator.IsValidTitle(textBoxBooktitle))&& (Validator.IsValidPrice(textBoxUnitPrice))&&(Validator.IsValidYear(textBoxYearPublished))&& (Validator.IsValidQOH(textBoxQOH))&&(Validator.IsValidID(textBoxAuthorId)) && (Validator.IsValidName(textBoxAuthorFirst)) && (Validator.IsValidName(textBoxAuthorLast)) )
            //{

            Clients cClient = new Clients();
            cClient.Name = textBoxName.Text;
            cClient.Street = textBoxStreet.Text;
            cClient.City = textBoxCity.Text;
            cClient.PostalCode = textBoxPostalCode.Text;
            cClient.PhoneNumber = maskedTextBoxPhoneNumber.Text;
            cClient.FaxNumber = textBoxFaxNumber.Text;
            cClient.CreditLimit = textBoxCreditLimit.Text;
            
            ClientDA.Save
              (cClient);


            ClearAll();

        }
        private void ClearAll()
        {
            textBoxName.Clear();
            textBoxStreet.Clear();
            textBoxCity.Clear();
            textBoxPostalCode.Clear();
           maskedTextBoxPhoneNumber.Clear();
            textBoxFaxNumber.Clear();
            textBoxCreditLimit.Clear();


        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            listViewClients.Items.Clear();
            ClientDA.ListClients(listViewClients);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int choice = comboBoxClients.SelectedIndex;
            switch (choice)
            {
                case -1: // The user didn't select any search option
                    MessageBox.Show("Please select the search option");
                    break;
                case 0: //The user selected the search by Customer ID
                    Clients cc = ClientDA.Search(textBoxInputInfo.Text);
                    if (cc != null)
                    {
                        textBoxName.Text = cc.Name;
                        textBoxStreet.Text = cc.Street;
                        textBoxCity.Text = cc.City;
                        textBoxPostalCode.Text = cc.PostalCode;
                        maskedTextBoxPhoneNumber.Text = cc.PhoneNumber;
                        textBoxFaxNumber.Text = cc.FaxNumber;

                        textBoxCreditLimit.Text = cc.CreditLimit;
                        

                    }

                    else
                    {
                        MessageBox.Show("Client not Found!");
                        textBoxInputInfo.Clear();
                        textBoxInputInfo.Focus();
                    }
                    break;
                default:
                    break;
            }
        }

        private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {

            int choice = comboBoxClients.SelectedIndex;
            switch (choice)
            {
                case 0:

                    textBoxInputInfo.Focus();
                    break;
                default:
                    break;
            }
        }


    }
}
