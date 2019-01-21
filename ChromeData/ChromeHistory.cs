using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeData
{
    public class ChromeHistory
    {

        HistoryItem history;
        string chromeHistoryFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
    + @"\Google\Chrome\User Data\Default\History";
        public ChromeHistory(string prn)
        {

            history = new HistoryItem();
            history.User = prn;
        }

        public void SaveLastTime()
        {
            long last_visit = 0;
            SQLiteConnection connection = new SQLiteConnection
           ("Data Source=" + chromeHistoryFile + ";Version=3;New=False;Compress=True;");

            connection.Open();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select visit_time from visits order by visit_time desc limit 1;";
            SQLiteDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                last_visit = Convert.ToInt64(dr["visit_time"]);

            }
            FileUtil.Write(last_visit);
        }


        static List<HistoryItem> allHistoryItems = new List<HistoryItem>();
        public List<HistoryItem> GetHistory(string prn)
        {
            long last_visit = FileUtil.Read();
            string chromeHistoryFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
      + @"\Google\Chrome\User Data\Default\History";

            SQLiteConnection connection = new SQLiteConnection
            ("Data Source=" + chromeHistoryFile + ";Version=3;New=False;Compress=True;");

            connection.Open();

            DataSet dataset = new DataSet();

            SQLiteDataAdapter adapter = new SQLiteDataAdapter
            ("select urls.id,urls.url,urls.title,visits.visit_time from urls join visits on visits.url = urls.id where visit_time >  " + last_visit +";", connection);
            adapter.Fill(dataset);
            if (dataset != null && dataset.Tables.Count > 0 & dataset.Tables[0] != null)
            {
                DataTable dt = dataset.Tables[0];

                allHistoryItems = new List<HistoryItem>();

                foreach (DataRow historyRow in dt.Rows)
                {
                    HistoryItem historyItem = new HistoryItem()
                    {
                        URL = Convert.ToString(historyRow["url"]),
                        Title = Convert.ToString(historyRow["title"]),

                        User = prn,
                        Id = DateTime.Now.Ticks.ToString()
                        
                    };
                    Console.WriteLine("ID " + historyItem.Id);

                    // Chrome stores time elapsed since Jan 1, 1601 (UTC format) in microseconds
                    long utcMicroSeconds = Convert.ToInt64(historyRow["visit_time"]);

                    // Windows file time UTC is in nanoseconds, so multiplying by 10
                    DateTime gmtTime = DateTime.FromFileTimeUtc(10 * utcMicroSeconds);

                    // Converting to local time
                    DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(gmtTime, TimeZoneInfo.Local);
                    historyItem.VisitedTime = localTime.ToString();
                   
                    allHistoryItems.Add(historyItem);
                }
            }

            foreach (HistoryItem historyItem in allHistoryItems)
            {
                Console.WriteLine("URL....." + historyItem.URL);
                Console.WriteLine("TIME...." + historyItem.VisitedTime);
                Console.WriteLine("TITLE..." + historyItem.Title);
                Console.WriteLine("USER ..." + historyItem.User);
            }
            return allHistoryItems;
        }
    }

}
