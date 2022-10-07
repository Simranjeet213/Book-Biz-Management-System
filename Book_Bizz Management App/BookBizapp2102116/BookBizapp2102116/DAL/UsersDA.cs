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
   

    public static class UserDA
    {
        private static string filePath = Application.StartupPath + @"\Users.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(User us)
        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(us.UserId + "," + us.UserFirstName + "," + us.UserLastName + "," + us.EmpId+","+us.EmpFirstName+","+us.EmpLastName);
            sWriter.Close();
            MessageBox.Show("User Data has been saved.");

        }

        public static void ListUsers(ListView listViewUser)
        {

            StreamReader sReader = new StreamReader(filePath);
            listViewUser.Items.Clear();


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
                listViewUser.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        public static List<User> ListUsers()
        {
            List<User> listU = new List<User>();

            StreamReader sReader = new StreamReader(filePath);


            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                User us = new User();
                us.UserId = Convert.ToInt32(fields[0]);
                us.UserFirstName = fields[1];
                us.UserLastName = fields[2];
                us.EmpId = Convert.ToInt32(fields[3]);
                us.EmpFirstName = fields[4];
                us.EmpLastName = fields[5];
                listU.Add(us);
                line = sReader.ReadLine();
            }
            sReader.Close();
            return listU;
        }

        public static User Search(int usId)
        {
            User us = new User();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (usId == Convert.ToInt32(fields[0]))
                {
                    us.UserId = Convert.ToInt32(fields[0]);
                    us.UserFirstName = fields[1];
                    us.UserLastName = fields[2];
                    us.EmpId = Convert.ToInt32(fields[3]);
                    us.EmpFirstName = fields[4];
                    us.EmpLastName = fields[5];
                    sReader.Close();
                    return us;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
    }
}
