using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.Linq;

namespace DataLinkLayer
{
    public class Test
    {
        private List<string> _filmovi;

        private SQLiteConnection dbConnection;

        private static Test _instanceTest;

        public Test()
        {            
            _filmovi = new List<string>();
            dbConnection = new SQLiteConnection("Data Source=C:/Users/Toni/Documents/Visual Studio 2012/Projects/KinoAplikacija/PresentationLayer/database.sqlite;Version=3;");
        }

        public static Test TestInstance
        {
            get
            {
                if (_instanceTest == null)
                {
                    _instanceTest = new Test();
                }
                return _instanceTest;
            }
        }


        public void AddReservation(int row, int column, int prikaz)
        {
            string sql = "INSERT INTO rezervacija ('vrijeme_rezervacije','id_prikaza','id_korisnika') VALUES ('2017-05-13 19:23:34', " + prikaz.ToString() + ", 1 );";
            int idRezervacije;

            dbConnection.Open();
            SQLiteCommand command1 = new SQLiteCommand(sql, dbConnection);
            command1.ExecuteNonQuery();
            
            idRezervacije = (int)dbConnection.LastInsertRowId;
            
            sql = "INSERT INTO sjedalo ('red_sjedala','stupac_sjedala','id_rezervacije') VALUES (" + row.ToString() + ", " + column.ToString() + ", " + idRezervacije.ToString() + ");";
            SQLiteCommand command3 = new SQLiteCommand(sql, dbConnection);
            command3.ExecuteNonQuery();

            dbConnection.Close();           
            return;
        }

        

        public List<int> GetTakenSeats(int idPrikaza)
        {
            string sql = "SELECT red_sjedala, stupac_sjedala FROM sjedalo JOIN rezervacija ON rezervacija.id_rezervacije=sjedalo.id_rezervacije JOIN prikaz ON prikaz.id_prikaza=rezervacija.id_prikaza WHERE prikaz.id_prikaza=" + idPrikaza + ";";
            var films = new List<int>();
            int temp;
            string temp1;
            string temp2;

            dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                temp1 = reader["red_sjedala"].ToString();
                temp2 = reader["stupac_sjedala"].ToString();
                temp = int.Parse(temp1) * 10 + int.Parse(temp2);
                films.Add(temp);
            }
            dbConnection.Close();

            return films;
        }


        #region NOT IMPLEMENTED
        /*
        public List<string> GetFilms
        {
            get { return _filmovi; }
        }*/


        /*
        public List<string> GetFilmByID()
        {
            string sql = "SELECT * FROM film WHERE id_filma = 1;";
            var films = new List<string>();

            dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                films.Add(reader["naziv_filma"].ToString());
            dbConnection.Close();

            return films;
        }*/
        /*
        public List<int> GetTakenSeatsOfReservation(int rezervacija)
        {
            string sql = "SELECT * FROM sjedalo WHERE id_rezervacije = " + rezervacija + ";";
            var films = new List<int>();
            int temp;
            string temp1;
            string temp2;

            dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                temp1 = reader["red_sjedala"].ToString();
                temp2 = reader["stupac_sjedala"].ToString();
                temp = int.Parse(temp1) * 10 + int.Parse(temp2);
                films.Add(temp);
            }
            dbConnection.Close();

            return films;
        }*/
        
        #endregion
    }
}
