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
    
    public static class OrderDA
    {
        private static string filePath = Application.StartupPath + @"\Orders.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Orders o)
        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(o.OrderId + "," + o.Phone + "," + o.Fax + "," + o.Email);
            sWriter.Close();
            MessageBox.Show("User Data has been saved.");

        }

        public static void ListOrders(ListView listViewOrder)
        {

            StreamReader sReader = new StreamReader(filePath);
            listViewOrder.Items.Clear();


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
                listViewOrder.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        public static List<Orders> ListOrders()
        {
            List<Orders> listO = new List<Orders>();

            StreamReader sReader = new StreamReader(filePath);


            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                Orders o = new Orders();
                o.OrderId = Convert.ToInt32(fields[0]);
                o.Phone = fields[1];
                o.Fax = fields[2];
                o.Email = fields[3];
               
                listO.Add(o);
                line = sReader.ReadLine();
            }
            sReader.Close();
            return listO;
        }

        public static Orders Search(int orId)
        {
            Orders o = new Orders();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (orId == Convert.ToInt32(fields[0]))
                {
                   o.OrderId = Convert.ToInt32(fields[0]);
                   o.Phone = fields[1];
                   o.Fax = fields[2];
                   
                    o.Email = fields[3];
                   
                    sReader.Close();
                    return o;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
    }
}
