using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookBizapp2102116
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if(textBoxUserName.Text=="MISManager" && textBoxUserPass.Text=="BrownH")
            {
                UsersForm u = new UsersForm();
                u.Show();
            }
            else if(textBoxUserName.Text=="SalesManager"&& textBoxUserPass.Text =="MooreT")
            {
                ClientsForm c = new ClientsForm();
                c.Show();
            }
            else if(textBoxUserName.Text=="InventoryController"&& textBoxUserPass.Text=="WangP")
            {
                BookForm b = new BookForm();
                b.Show();
            }
            else if(textBoxUserName.Text =="OrderClerks"&& textBoxUserPass.Text=="BrownM" || textBoxUserPass.Text=="BouchardJ")
            {
                OrderForm o = new OrderForm();
                o.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }
    }
}
