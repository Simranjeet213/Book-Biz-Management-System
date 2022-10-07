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
using BookBizapp2102116.Validation;
using System.IO;
using BookBizapp2102116.DAL;

namespace BookBizapp2102116
{
    public partial class BookForm : Form
    {

        List<Book> listB = new List<Book>();
        public BookForm()
        {
            InitializeComponent();
            buttonListBook.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            List<Book> listB = BookDA.ListBook();
           // if ((ValidatorBook.IsValidISBN(textBoxISBN)) && (ValidatorBook.IsValidTitle(textBoxBooktitle)) && (ValidatorBook.IsValidPrice(textBoxUnitPrice.Text)) && (ValidatorBook.IsValidYear(textBoxYearPublished.Text)) && (ValidatorBook.IsValidQOH(textBoxQOH.Text)) && (ValidatorBook.IsValidID(textBoxAuthorId)) && (ValidatorBook.IsValidName(textBoxAuthorFirst)) && (ValidatorBook.IsValidName(textBoxAuthorLast)))
           // {


                Book bBook = new Book();
                bBook.ISBN = Convert.ToInt32(textBoxISBN.Text);
                bBook.Title = textBoxBooktitle.Text;
                bBook.UnitPrice = Convert.ToInt32(textBoxUnitPrice.Text);
                bBook.YearPublished = Convert.ToInt32(textBoxYearPublished.Text);
                bBook.QOH = Convert.ToInt32(textBoxQOH.Text);
                bBook.AuthorId = Convert.ToInt32(textBoxAuthorId.Text);
                bBook.FirstName = textBoxAuthorFirst.Text;
                bBook.LastName = textBoxAuthorLast.Text;
                bBook.Email = textBoxEmail.Text;
                BookDA.Save(bBook);

                ClearAll();
           // }
        }
        private void ClearAll()
        {
            textBoxISBN.Clear();
            textBoxBooktitle.Clear();
            textBoxUnitPrice.Clear();
            textBoxYearPublished.Clear();
            textBoxQOH.Clear();
            textBoxAuthorId.Clear();
            textBoxAuthorFirst.Clear();
            textBoxAuthorLast.Clear();
            textBoxEmail.Clear();
            textBoxISBN.Focus();

        }

        private void comboBoxBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = comboBoxBook.SelectedIndex;
            switch (choice)
            {
                case 0:

                    textBoxInputBook.Focus();
                    break;
                default:
                    break;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            int choice = comboBoxBook.SelectedIndex;
            switch (choice)
            {
                case -1: // The user didn't select any search option
                    MessageBox.Show("Please select the search option");
                    break;
                case 0: //The user selected the search by Customer ID
                    Book bb = BookDA.Search(textBoxInputBook.Text);
                    if (bb != null)
                    {
                        textBoxISBN.Text = (bb.ISBN).ToString();
                        textBoxBooktitle.Text = bb.Title;
                        textBoxUnitPrice.Text = (bb.UnitPrice).ToString();
                        textBoxYearPublished.Text = (bb.YearPublished).ToString();
                        textBoxQOH.Text = (bb.QOH).ToString();
                        textBoxAuthorId.Text = (bb.AuthorId).ToString();
                        textBoxAuthorFirst.Text = bb.FirstName;
                        textBoxAuthorLast.Text = bb.LastName;
                        textBoxEmail.Text = bb.Email;

                    }

                    else
                    {
                        MessageBox.Show("Book not Found!");
                        textBoxInputBook.Clear();
                        textBoxInputBook.Focus();
                    }
                    break;
                default:
                    break;
            }
        }

        private void buttonListBook_Click(object sender, EventArgs e)
        {
            listViewBook.Items.Clear();
            BookDA.ListBook(listViewBook);
        }
    }
}
