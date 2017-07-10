using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.Linq;

namespace BusinessLogicLayer
{
    public static class DatabaseQuery
    {

        private static SQLiteConnection dbConnection = new SQLiteConnection("Data Source=C:/Users/Toni/Documents/Visual Studio 2012/Projects/KinoAplikacija/PresentationLayer/database.sqlite;Version=3;");

        public static ObservableCollection<Film> GetFilms()
        {
            string sql = "SELECT * FROM film;";
            ObservableCollection<Film> films = new ObservableCollection<Film>();
            string tempName;
            string tempOpis;
            TimeSpan tempTimeSpan;
            
            dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                tempName = (reader["naziv_filma"].ToString());
                tempOpis = (reader["opis_filma"].ToString());
                tempTimeSpan = TimeSpan.FromSeconds(Convert.ToDouble((reader["trajanje_filma"])));
                films.Add(new Film(tempName, tempOpis, tempTimeSpan));
            }

            dbConnection.Close();

            return films;
        }

        public static ObservableCollection<PrikazFilma> GetShowings()
        {
            string sql = "SELECT * FROM prikaz JOIN dvorana ON prikaz.id_dvorane=dvorana.id_dvorane JOIN film ON prikaz.id_filma=film.id_filma;";
            ObservableCollection<PrikazFilma> Showings = new ObservableCollection<PrikazFilma>();
            int idPrikaza;
            string nazivDvorane;
            DateTime vrijemePrikaza;
            string filmName;
            double cijena;

            dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                idPrikaza = Convert.ToInt32(reader["id_prikaza"]);
                filmName = reader["naziv_filma"].ToString();
                vrijemePrikaza =Convert.ToDateTime(reader["vrijeme_prikaza"].ToString());
                cijena = Convert.ToDouble(reader["cijena"]);
                nazivDvorane = reader["naziv_dvorane"].ToString();

                Showings.Add(new PrikazFilma(idPrikaza, filmName, vrijemePrikaza, cijena, nazivDvorane));
            }
            dbConnection.Close();

            return Showings;
        }

        public static void AddReservation(List<Seat> selectedSeats, int prikaz)
        {
            string sql = "INSERT INTO rezervacija ('vrijeme_rezervacije','id_prikaza','id_korisnika') VALUES ('2017-05-13 19:23:34', " + prikaz.ToString() + ", 1 );";
            int idRezervacije;

            dbConnection.Open();
            SQLiteCommand command1 = new SQLiteCommand(sql, dbConnection);
            command1.ExecuteNonQuery();
            
            idRezervacije = (int)dbConnection.LastInsertRowId;

            foreach (Seat seat in selectedSeats)
            {
                sql = "INSERT INTO sjedalo ('red_sjedala','stupac_sjedala','id_rezervacije') VALUES (" + seat.Pozicija.GetRowPosition.ToString() + ", " + seat.Pozicija.GetColumnPosition.ToString() + ", " + idRezervacije.ToString() + ");";
                SQLiteCommand command3 = new SQLiteCommand(sql, dbConnection);
                command3.ExecuteNonQuery();
            }           

            dbConnection.Close();           
            return;
        }

        public static ObservableCollection<SeatViewModel> GetReservedSeats(int idPrikaza)
        {
            string sql = "SELECT red_sjedala, stupac_sjedala FROM sjedalo JOIN rezervacija ON rezervacija.id_rezervacije=sjedalo.id_rezervacije JOIN prikaz ON prikaz.id_prikaza=rezervacija.id_prikaza WHERE prikaz.id_prikaza=" + idPrikaza + ";";
            List<int> reservedSeats = new List<int>();
            int row;
            int column;
            bool flag = false;

            dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                row = Convert.ToInt32(reader["red_sjedala"]);
                column = Convert.ToInt32(reader["stupac_sjedala"]);

                reservedSeats.Add(row * 10 + column);
            }
            dbConnection.Close();

            ObservableCollection<SeatViewModel> dbSeats = new ObservableCollection<SeatViewModel>();
            for (int i = 0; i < 100; i++)
            {
                foreach (int item in reservedSeats)
                    if (item == i) flag = true;
                if (flag == true)
                    dbSeats.Add(new SeatViewModel(new Seat(new Pozicija(i / 10, i % 10), SeatAvailability.Zauzeto)));
                else dbSeats.Add(new SeatViewModel(new Seat(new Pozicija(i / 10, i % 10), SeatAvailability.Dostupno)));
                flag = false;
            }
            return dbSeats;
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
