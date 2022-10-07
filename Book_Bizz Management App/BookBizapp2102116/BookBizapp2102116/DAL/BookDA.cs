using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBizapp2102116.BLL;
using System.Windows.Forms;
using System.IO;

namespace BookBizapp2102116.DAL
{
    
    public class BookDA
    {
        private static string filePath = Application.StartupPath + @"\Books.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Book bb)
        {

            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(bb.ISBN + "," + bb.Title + "," + bb.UnitPrice + "," + bb.YearPublished + "," + bb.QOH + "," + bb.AuthorId + "," + bb.FirstName + "," + bb.LastName + "," + bb.Email);
            sWriter.Close();
            MessageBox.Show("Book Data has been saved.");

        }

        public static void ListBook(ListView listViewBook)
        {

            StreamReader sReader = new StreamReader(filePath);
            listViewBook.Items.Clear();


            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);
                item.SubItems.Add(fields[6]);
                item.SubItems.Add(fields[7]);
                item.SubItems.Add(fields[8]);

                listViewBook.Items.Add(item);
                line = sReader.ReadLine(); // Attention : read the next line
            }
            sReader.Close();
        }

        public static List<Book> ListBook()
        {
            List<Book> listB = new List<Book>();

            StreamReader sReader = new StreamReader(filePath);


            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                Book bb = new Book();
                bb.ISBN = Convert.ToInt32(fields[0]);
                bb.Title = fields[1];
                bb.UnitPrice = Convert.ToInt32(fields[2]);
                bb.YearPublished = Convert.ToInt32(fields[3]);
                bb.QOH = Convert.ToInt32(fields[4]);
                bb.AuthorId = Convert.ToInt32(fields[5]);
                bb.FirstName = fields[6];
                bb.LastName = fields[7];
                bb.Email = fields[8];
                listB.Add(bb);
                line = sReader.ReadLine();
            }
            sReader.Close(); //Close the file
            return listB;
        }

        public static Book Search(string bbId)
        {
            Book bb = new Book();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (bbId == fields[0])
                {
                    bb.ISBN = Convert.ToInt32(fields[0]);
                    bb.Title = fields[1];
                    bb.UnitPrice = Convert.ToInt32(fields[2]);
                    bb.YearPublished = Convert.ToInt32(fields[3]);
                    bb.QOH = Convert.ToInt32(fields[4]);
                    bb.AuthorId = Convert.ToInt32(fields[5]);
                    bb.FirstName = fields[6];
                    bb.LastName = fields[7];
                    bb.Email = fields[8];
                    sReader.Close();
                    return bb;
                }
                line = sReader.ReadLine(); // Attention : read the next line 
            }
            sReader.Close();//Fixing the Problem by closing the file
            return null;
        }



    }
}
