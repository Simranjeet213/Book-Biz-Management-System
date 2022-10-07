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
    public partial class UsersForm : Form
    {
        List<User> listU = new List<User>();
        public UsersForm()
        {
            InitializeComponent();
            buttonList.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            List<User> listU = UserDA.ListUsers();
            //  if ((Validator.IsValidISBN(textBoxISBN))&& (Validator.IsValidTitle(textBoxBooktitle))&& (Validator.IsValidPrice(textBoxUnitPrice))&&(Validator.IsValidYear(textBoxYearPublished))&& (Validator.IsValidQOH(textBoxQOH))&&(Validator.IsValidID(textBoxAuthorId)) && (Validator.IsValidName(textBoxAuthorFirst)) && (Validator.IsValidName(textBoxAuthorLast)) )
            //{
            User uUser = new User();
            uUser.UserId = Convert.ToInt32(textBoxUserId.Text);
            uUser.UserFirstName = textBoxUserFirst.Text;
            uUser.UserLastName= textBoxUserLast.Text;
            uUser.EmpId = Convert.ToInt32(textBoxEmpId.Text);
            uUser.EmpFirstName = textBoxEmpFirst.Text;
            uUser.EmpLastName = textBoxEmpLast.Text;
            UserDA.Save
                (uUser);
            
           


            ClearAll();
        }

        private void ClearAll()
        {
            textBoxUserId.Clear();
            textBoxUserFirst.Clear();
            textBoxUserLast.Clear();
            textBoxEmpId.Clear();
           
            textBoxEmpFirst.Clear();
            textBoxEmpLast.Clear();


        }

        private void buttonList_Click(object sender, EventArgs e)
        {

            listViewUsers.Items.Clear();
            UserDA.ListUsers(listViewUsers);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int choice = comboBoxUsers.SelectedIndex;
           
                        switch (choice)
                        {
                            case -1: // The user didn't select any search option
                                MessageBox.Show("Please select the search option");
                                break;
                            case 0: //The user selected the search by Customer ID
                                User uu = UserDA.Search(Convert.ToInt32(textBoxInputInfo.Text));
                                if (uu != null)
                                {
                                    textBoxUserId.Text =  uu.UserId.ToString(); ;
                                    textBoxUserFirst.Text = uu.UserFirstName;
                                    textBoxUserLast.Text = uu.UserLastName;
                                    textBoxEmpId.Text = uu.EmpId.ToString(); ;
                                 
                                    textBoxEmpFirst.Text = uu.EmpFirstName;

                                    textBoxEmpLast.Text = uu.EmpLastName;


                                }

                                else
                                {
                                    MessageBox.Show("Users not Found!");
                                    textBoxInputInfo.Clear();
                                    textBoxInputInfo.Focus();
                                }
                                break;
                            default:
                                break;
                        }
                        

            }
        

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            int choice = comboBoxUsers.SelectedIndex;
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
