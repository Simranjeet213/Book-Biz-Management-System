using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookBizapp2102116.BLL;

namespace BookBizapp2102116.Validation
{
   
    public static class ValidatorBook
    {
        public static bool IsValidID(string input)
        {

            int tempID;
            if ((input.Length != 5) || (Int32.TryParse(input, out tempID)))
            {
                MessageBox.Show("Invalid AuthorID, it must be a 5 digit number");
                return false;
            }
            return true;

        }
        public static bool IsValidID(TextBox text)
        {
            int tempID;
            if ((text.TextLength != 5) || !((Int32.TryParse(text.Text, out tempID))))
            {
                MessageBox.Show("Invalid AuthorID, it must be a 5 digit number");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;

        }
        public static bool IsValidName(TextBox text)
        {
            for (int i = 0; i < text.TextLength; i++)
            {
                if (char.IsDigit(text.Text, i) || (char.IsWhiteSpace(text.Text, i)))
                {
                    MessageBox.Show("Invalid Name,Please enter another name.", "INVALID NAME");
                    text.Clear();
                    text.Focus();
                    return false;
                }

            }
            return true;

        }
        public static bool IsUniqueID(List<Book> listB, string id)
        {
            foreach (Book b in listB)
            {
                if (b.Title == id)
                {
                    MessageBox.Show("Duplicate ID, please enter a unique one.");
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidISBN(TextBox text)
        {
            int tempID;
            if ((text.TextLength != 6) || !((Int32.TryParse(text.Text, out tempID))))
            {
                MessageBox.Show("Invalid ISBN, it must be a 6 digit number");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;

        }

        public static bool IsValidTitle(TextBox text)
        {
            for (int i = 0; i < text.TextLength; i++)
            {
                if (char.IsDigit(text.Text, i) || (char.IsWhiteSpace(text.Text, i)))
                {
                    MessageBox.Show("Invalid Title,Please enter another title.", "INVALID TITLE");
                    text.Clear();
                    text.Focus();
                    return false;
                }

            }
            return true;

        }
        public static bool IsValidQOH(string input)
        {

            int tempID;
            if (Int32.TryParse(input, out tempID))
            {
                MessageBox.Show("Invalid QOH, it must be a number");
                return false;
            }
            return true;

        }

        public static bool IsValidPrice(string input)
        {

            int tempID;
            if (Int32.TryParse(input, out tempID))
            {
                MessageBox.Show("Invalid Unit Price, it must be a number");
                return false;
            }
            return true;

        }
        public static bool IsValidYear(string input)
        {

            int tempID;
            if ((input.Length != 4) || (Int32.TryParse(input, out tempID)))
            {
                MessageBox.Show("Invalid Year, it must be a 4 digit number");
                return false;
            }
            return true;

        }

    }
}
