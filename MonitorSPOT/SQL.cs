using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MonitorSPOT
{
    class SQL
    {
        public SQL()
        {
            //SQL-Verbindung aufbauen
            _myConnection = new SqlConnection("user id=sa; password=;server=dpn-svr-membrain\\SQLEXPRESS;" +
                                              "Trusted_Connection=yes; database=SPOT; connection timeout=30");
        }

        public SqlConnection _myConnection;

        public SqlConnection myConnection
        {
            get { return _myConnection; }
            set { _myConnection = value; }
        }

        public Dictionary<string, string> get_faq()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            SqlDataReader rdr = null;
            string FAQ = "";
            string Bez = "";

            try
            {
                _myConnection.Open();

                // SQL-Abfrage starten
                string abfrage = "select FAQ + ' - ' + Bezeichnung as Eintrag, Bezeichnung from FAQ where Aktiv = 1 order by FAQ";

                SqlCommand cmd = new SqlCommand(abfrage, myConnection);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    FAQ = Convert.ToString(rdr["Eintrag"]);
                    Bez = Convert.ToString(rdr["Bezeichnung"]);
                    result.Add(FAQ, Bez);
                }                
            }
            catch (Exception err)
            { }

            return result;
        }

        public List<string> get_data_Werk(string werk)
        {
            // SQL-Datenvariable erstellen
            SqlDataReader rdr = null;
            string anzahl_pers = "0";
            string anzahl_mess = "0";
            string anzahl_heut = "0";
            string anzahl_norm = "0";
            string servername = "";
            string zeitpunkt = "";
            List<string> result = new List<string>();
            try
            {
                _myConnection.Open();

                // SQL-Abfrage starten
                string abfrage = "select top 1 l.Aktive_Personen, l.Message_offen, l.Message_gesamt_heute, l.Server, w.Messages, l.datetime "
                                    + "from tbl_log as l inner join Werke as w on l.Server = w.Server "
                                    + "where w.ID = " + werk + " order by l.datetime desc;";

                SqlCommand cmd = new SqlCommand(abfrage, myConnection);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    anzahl_pers = Convert.ToString(rdr["Aktive_Personen"]);
                    anzahl_mess = Convert.ToString(rdr["Message_offen"]);
                    anzahl_heut = Convert.ToString(rdr["Message_gesamt_heute"]);
                    servername = Convert.ToString(rdr["Server"]);
                    anzahl_norm = Convert.ToString(rdr["Messages"]);
                    zeitpunkt = Convert.ToString(rdr["datetime"]);
                }

                rdr.Close();
                _myConnection.Close();            
            }
            catch (Exception err)
            {
                anzahl_pers = "--";
                anzahl_mess = "--";
                anzahl_heut = "--";
                anzahl_norm = "--";
                servername = "--";
                zeitpunkt = "--";
            }
            result.Add(anzahl_pers);
            result.Add(anzahl_mess);
            result.Add(anzahl_heut);
            result.Add(anzahl_norm);
            result.Add(servername);
            result.Add(zeitpunkt);
            return result;
        }

        public int get_anzahl_durchschnitt(int werk)
        {
            // SQL-Datenvariable erstellen
            SqlDataReader rdr = null;
            int anzahl = 0;
            try
            {
                _myConnection.Open();

                // SQL-Abfrage starten
                string abfrage = "select Messages from Werke where ID = " + werk + ";";
                SqlCommand cmd = new SqlCommand(abfrage, myConnection);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                anzahl = (int)rdr[0];
                rdr.Close();
                _myConnection.Close();
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.ToString());
                anzahl = 0;
            }
            return anzahl;
        }

        public string get_Backuppfad(string server)
        {
            // SQL-Datenvariable erstellen
            SqlDataReader rdr = null;
            string pfad = "";
            try
            {
                _myConnection.Open();

                // SQL-Abfrage starten
                string abfrage = "select Backuppfad from Werke where Server = '" + server + "'";

                SqlCommand cmd = new SqlCommand(abfrage, myConnection);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                pfad = (string)rdr[0];
                rdr.Close();
                _myConnection.Close();
            }
            catch (Exception err)
            { }
            return pfad;
        }

        public string get_Fotopfad(string werk)
        {
            // SQL-Datenvariable erstellen
            SqlDataReader rdr = null;
            string pfad = "";
            try
            {
                _myConnection.Open();

                // SQL-Abfrage starten
                string abfrage = "select GW_Pfad from Werke where ID = '" + werk + "'";

                SqlCommand cmd = new SqlCommand(abfrage, myConnection);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                pfad = (string)rdr[0];
                rdr.Close();
                _myConnection.Close();
            }
            catch (Exception err)
            { }
            return pfad;
        }
    }
}