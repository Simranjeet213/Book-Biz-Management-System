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

    public static class ClientDA
    {
        private static string filePath = Application.StartupPath + @"\Clients.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Clients cc)
        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(cc.Name + "," + cc.Street + "," + cc.City + "," + cc.PostalCode + "," + cc.PhoneNumber + "," + cc.FaxNumber + "," + cc.CreditLimit);
            sWriter.Close();
            MessageBox.Show("Client Data has been saved.");

        }

        public static void ListClients(ListView listViewClient)
        {

            StreamReader sReader = new StreamReader(filePath);
            listViewClient.Items.Clear();


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



                listViewClient.Items.Add(item);
                line = sReader.ReadLine(); // Attention : read the next line
            }
            sReader.Close();
        }

        public static List<Clients> ListClients()
        {
            List<Clients> listC = new List<Clients>();

            StreamReader sReader = new StreamReader(filePath);


            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                Clients cc = new Clients();
                cc.Name = fields[0];
                cc.Street = fields[1];
                cc.City = fields[2];
                cc.PostalCode = fields[3];
                cc.PhoneNumber = fields[4];
                cc.FaxNumber = fields[5];
                cc.CreditLimit = fields[6];


                listC.Add(cc);
                line = sReader.ReadLine();
            }
            sReader.Close(); //Close the file
            return listC;
        }

        public static Clients Search(string ccName)
        {
            Clients cc = new Clients();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (ccName == fields[0])
                {
                    cc.Name = fields[0];
                    cc.Street = fields[1];
                    cc.City = fields[2];
                    cc.PostalCode = fields[3];
                    cc.PhoneNumber = fields[4];
                    cc.FaxNumber = fields[5];
                    cc.CreditLimit = fields[6];

                    sReader.Close();
                    return cc;
                }
                line = sReader.ReadLine(); // Attention : read the next line 
            }
            sReader.Close();//Fixing the Problem by closing the file
            return null;
        }



    }
}
