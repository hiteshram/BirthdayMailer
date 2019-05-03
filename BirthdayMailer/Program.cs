using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace BirthdayMailer
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Provider= Microsoft.ACE.OLEDB.12.0;" + "Data Source=C:\\Users\\Hitesh\\source\\repos\\BirthdayMailer\\Sample1.xlsx" + ";Extended Properties='Excel 8.0;HDR=Yes'";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Birthday");
            Dictionary<string, string> detailsList= new Dictionary<string, string>();
            foreach (DataRowView m in ds.Tables[0].DefaultView)
            {
                DateTime bday = Convert.ToDateTime(m.Row.ItemArray[2].ToString());
                if((bday.Day==DateTime.Now.Day)&&(bday.Month==DateTime.Now.Month))
                {
                    detailsList.Add(m.Row.ItemArray[0].ToString(), m.Row.ItemArray[1].ToString());
                }
            }
            Mailer email = new Mailer();
            email.SendEmail(detailsList);
        }
    }
}
