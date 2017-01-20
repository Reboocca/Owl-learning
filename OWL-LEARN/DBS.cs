using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;

namespace OWL_LEARN
{
    class DBS
    {
        #region fields
        private string conn;
        private MySqlConnection connect;
        #endregion

        //Connectie met de database
        private void db_connection()
        {
            try
            {
                conn = "Server=localhost;Database=owl-learn;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }

            catch (MySqlException) //Foutafhandeling
            {
                MessageBox.Show("Kan geen verbinding maken met de database", "Oh nee!");
            }
        }

        //Functie voor het valideren van de login
        private bool validate_login(string user, string password)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from users where Username=@user and Password=@pass";
            cmd.Parameters.AddWithValue("@user", user);         //Parameter with the username
            cmd.Parameters.AddWithValue("@pass", password);     // Parameter with the password
            cmd.Connection = connect;

            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                connect.Close();
                return true;
            }

            else
            {
                connect.Close();
                return false;
            }
        }

        //Controleer wie er is ingelogd (welke rol -> voor het doorverwijzen naar volgende window)
        public void try_login(string user, string password, MainWindow loginform)
        {

            if (user == "" || password == "")       //Kleine controle of er gegevens zijn ingevuld
            {
                MessageBox.Show("Vul uw gebruikersnaam en wachtwoord in", "Oeps!");
                return;
            }

            //Valideer de ingevoerde inloggegevens
            bool r = validate_login(user, password);

            if (r)      //Als de gegevens bekend zijn in de database & kloppen
            {
                string sRolID = GetRol(user).ToString();

                if (sRolID == "1")          //Als de gebruiker die inlogt een consulent is
                {
                    ConsulentForm form = new ConsulentForm(user);
                    form.Show();
                    loginform.Close();
                }

                else if (sRolID == "2")     //Als de gebruiker die inlogt een leerling is
                {
                    LeerlingForm form = new LeerlingForm(user);
                    form.Show();
                    loginform.Close();
                }

                else        //Als er geen rol gevonden kan worden of hij is onbekend dan
                {
                    MessageBox.Show("Er is een fout opgetreden in het systeem, neem contact op met de beheerders van het programma", "Whoops!");
                }

            }

            else            //Als de gegevens niet kloppen
            {
                MessageBox.Show("Uw gebruikersnaam of wachtwoord is onjuist", "Oh oh...");
            }
        }

        //Functie voor het meegeven van de rol
        public string GetRol(string sUser)
        {
            DataTable retValue = new DataTable();
            db_connection();

            using (MySqlCommand cmd = new MySqlCommand("Select * from users where Username='" + sUser + "'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }

            //Return RolID
            string RolID = Convert.ToString(retValue.Rows[0]["rolID"]);
            return RolID;
        }

        //Functie voor het meegeven van alle vakgegevens
        public DataTable GetVakken()
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from vak"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }

            //Return result
            return retValue;
        }

        //Algemene functie voor het opzoeken van verschillende gegevens in de database
        public DataTable Search(string sTable, string sParameterA, string sParameterB)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + sTable + " WHERE " + sParameterA + "=" + sParameterB))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }

            //Return result
            return retValue;
        }

        //Fucntie voor het verwijderen van een vraag
        public void DeleteVraag(string vID)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM vragen WHERE VraagID=" + vID);
            bool r = DeleteAntwoorden(vID);      //Verwijder ook de antwoorden die gebonden zijn aan de vraag

            try
            {
                db_connection();
                cmd.Connection = connect;
                cmd.ExecuteNonQuery();

                if (r)      //Wanneer de antwoorden & de vraag succesvol zijn verwijderd
                {
                    MessageBox.Show("De vraag is succesvol verwijderd.", "Succes!");
                }

                else        //Wanneer er iets mis is gegaan met het verwijderen
                {
                    MessageBox.Show("Er is iets mis gegaan met het verwijderen van de antwoorden die bij de vraag horen, contacteer een beheerder", "Ohjee.");
                }
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het verwijderen van de vraag, probeer later nog eens.", "Oh oh!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het verwijderen van de antwoorden
        public bool DeleteAntwoorden(string vID)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM antwoorden WHERE VraagID=" + vID);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }

            catch       //Foutafhandeling
            {
                return false;
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het ophalen van de lesonderwerpen die bij het vak horen
        public DataTable getLOcms(string VakNaam)
        {
            string VakID = "0";
            switch (VakNaam)        //Switch voor de verschillende vakken & de ID's
            {
                case "Geschiedenis":
                    VakID = "1";
                    break;

                case "Rekenen":
                    VakID = "2";
                    break;

                case "Biologie":
                    VakID = "3";
                    break;

                case "Nederlands":
                    VakID = "4";
                    break;

                case "Engels":
                    VakID = "5";
                    break;

                default:
                    break;
            }

            DataTable retValue = new DataTable();
            db_connection();

            using (MySqlCommand cmd = new MySqlCommand("Select * from LesOnderwerp where VakID=" + VakID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }

            //Return result
            return retValue;
        }

        //Functie voor het toevoegen van een nieuw lesonderwerp
        public void VoegLesOnderwerpToe(string VakID, string loOmschrijving)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO lesonderwerp(Omschrijving, VakID) VALUES('" + loOmschrijving + "', " + VakID + ")");
            cmd.Connection = connect;
            cmd.Parameters.AddWithValue("@lesonderwerp", loOmschrijving);

            try
            {
                cmd.ExecuteNonQuery();
                string sVakNaam = "";

                switch (VakID)      //Switch voor de verschillende vakken & de ID's
                {
                    case "1":
                        sVakNaam = "Geschiedenis";
                        break;
                    case "2":
                        sVakNaam = "Rekenen";
                        break;
                    case "3":
                        sVakNaam = "Biologie";
                        break;
                    case "4":
                        sVakNaam = "Nederlands";
                        break;
                    case "5":
                        sVakNaam = "Engels";
                        break;
                }

                MessageBox.Show("Het les onderwerp is toegevoegd aan " + sVakNaam + ".", "Succes!");

            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het toevoegen van het lesonderwerp, probeer later nog eens.", "Whoops!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het verwijderen van een Lesonderwerp
        public void DeleteLO(string loID)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM lesonderwerp WHERE LesonderwerpID=" + loID);
            cmd.Connection = connect;
            cmd.Parameters.AddWithValue("@LesonderwerpID", loID);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Het lesonderwerp is succesvol verwijderd.", "Succes!");
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het vewijderen van het lesonderwerp, probeer later nog eens.", "Oh oh!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het hernoemen van een lesonderwerp
        public void changeNameLO(string loID, string newName)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("UPDATE lesonderwerp SET  Omschrijving = '" + newName + "' WHERE LesonderwerpID=" + loID);
            cmd.Connection = connect;
            cmd.Parameters.AddWithValue("@LesonderwerpID", loID);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("De omschrijving van het lesonderwerp is succesvol gewijzigd.", "Succes!");
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het wijzigen van het lesonderwerp, probeer later nog eens.", "Oh oh!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het verwijderen van een Les
        public void DeleteLes(string lID)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM les WHERE lesID=" + lID);
            cmd.Connection = connect;
            cmd.Parameters.AddWithValue("@LesID", lID);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("De les is succesvol verwijderd.", "Succes!");
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het vewijderen van de les, probeer later nog eens.", "Oh oh!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het toevoegen van een les
        public void newLes(string sloID, string sLesNaam, string sUitleg, Lestoevoegen regform, string user)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into les (LesID, Uitleg, LesonderwerpID, lesNaam) VALUES (NULL, @sUitleg, @sloID, @sLesNaam);";
            cmd.Parameters.AddWithValue("@sloID", sloID);           //Parameter with LesonderwerpID
            cmd.Parameters.AddWithValue("@sLesNaam", sLesNaam);     //Parameter with Lesnaam
            cmd.Parameters.AddWithValue("@sUitleg", sUitleg);       //Parameter with Uitleg
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("De les: " + sLesNaam + " is succesvol aangemaakt.", "WOOHOO!");
                LesonderwerpWijzig form = new LesonderwerpWijzig(sloID, user);
                form.Show();
                regform.Close();
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan van de les ", "OOPSIE!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het ophalen van de user's naam
        public string getUserNaam(string username)
        {
            DataTable retValue = new DataTable();
            db_connection();

            using (MySqlCommand cmd = new MySqlCommand("Select * from users where Username='" + username + "'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            //Return Username
            string NaamUser = Convert.ToString(retValue.Rows[0]["firstName"]) + " " + Convert.ToString(retValue.Rows[0]["lastName"]);
            return NaamUser;
        }

        //Functie voor het aanmaken van een nieuw account
        public void newAccount(string user, string rolID, string fName, string lName, string gName, string WW, AccountToevoeg form)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into users (Username, Password, firstName, lastName, rolID) VALUES (@sUsername, @sPassword, @sfName, @slName, @srolID)";
            cmd.Parameters.AddWithValue("@sUsername", gName);       //Parameter with Username
            cmd.Parameters.AddWithValue("@sPassword", WW);          //Parameter with Password
            cmd.Parameters.AddWithValue("@sfName", fName);          //Parameter with Firstname
            cmd.Parameters.AddWithValue("@slName", lName);          //Parameter with Lastname
            cmd.Parameters.AddWithValue("@srolID", rolID);          //Parameter with RolID
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Het account van: " + fName + " " + lName + " is succesvol aangemaakt.", "Succes!");
                UserCMS newForm = new UserCMS(user);
                newForm.Show();
                form.Close();
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan van het nieuwe account, probeer het nog eens ", "Error!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het updaten van het account
        public void safeAccount(string user, string fName, string lName, string gName, string WW, string userID, AccountWijzigen form)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE  users SET Username=@sUsername, Password=@sPassword, firstName=@sfName, lastName=@slName  WHERE userID=" + userID;
            cmd.Parameters.AddWithValue("@sUsername", gName);       //Parameter with Username
            cmd.Parameters.AddWithValue("@sPassword", WW);          //Parameter with Password
            cmd.Parameters.AddWithValue("@sfName", fName);          //Parameter with Firstname
            cmd.Parameters.AddWithValue("@slName", lName);          //Parameter with Lastname
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Het account van: " + fName + " " + lName + " is succesvol gewijzigd.", "Succes!");
                UserCMS newForm = new UserCMS(user);
                newForm.Show();
                form.Close();
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan van het nieuwe account, probeer het nog eens ", "Error!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het verwijderen van een gebruiker
        public void DeleteUser(string userID)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE UserID=" + userID);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Het account is succesvol verwijderd.", "Succes!");
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het vewijderen van het account, probeer later nog eens.", "Oh oh!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het updaten van de les
        public void changeLesInfo(string lID, string newName, string newUitleg)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("UPDATE les SET  lesNaam = '" + newName + "', Uitleg ='" + newUitleg + "' WHERE LesID=" + lID);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("De naam en/of uitleg van de les is succesvol gewijzigd.", "Succes!");
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het wijzigen van de les gegevens, probeer later nog eens.", "Oh oh!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het controleren van het antwoord
        public DataTable GetGoedFout(string sAntwoord, string sVraagID)
        {
            DataTable retValue = new DataTable();
            db_connection();

            using (MySqlCommand cmd = new MySqlCommand("Select Juist_onjuist from antwoorden where VraagID=" + sVraagID + " AND Antwoord=" + sAntwoord))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }

            //Return result
            return retValue;
        }

        //Functie voor het ophalen van het userID voor het opslaan van de voortgang
        public void findIDVoorVoortgang(string sUsername, string sLesonderwerpID, string sLesID, LesForm lsForm)
        {
            db_connection();
            string sUserID;

            using (MySqlCommand cmd = new MySqlCommand("select UserID from users where Username='" + sUsername + "'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    sUserID = reader[0].ToString();

                    if (CheckLesVoortgang(sUserID, sLesID))
                    {
                        LeerlingForm lf = new LeerlingForm(sUsername);
                        lf.Show();
                        lsForm.Close();
                    }

                    else
                    {
                        updateVoortgang(sUserID, sLesonderwerpID, sLesID, sUsername, lsForm);
                    }
                }
            }
            connect.Close();
        }

        //Controleer of de leerling de les al ooit heeft voltooid -> onnodig om op te slaan
        public bool CheckLesVoortgang(string sUserID, string sLesID)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM voortgang WHERE UserID='" + sUserID + "' AND LesID='" + sLesID + "'");

            cmd.Connection = connect;

            MySqlDataReader check = cmd.ExecuteReader();
            if (check.Read())
            {
                connect.Close();
                return true;
            }

            else
            {
                connect.Close();
                return false;
            }

        }

        //Het opslaan van de voortgang per gebruiker & les
        public void updateVoortgang(string sUserID, string sLesonderwerpID, string sLesID, string sUsername, LesForm lsForm)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("insert into voortgang (UserID, LesID, LesonderwerpID, Voortgang) VALUES (@sUserID, @sLesID, @sLesonderwerpID, 1)");
            cmd.Parameters.AddWithValue("@sUserID", sUserID);                           //Parameter with UserID
            cmd.Parameters.AddWithValue("@sLesID", sLesID);                             //Parameter with LesID
            cmd.Parameters.AddWithValue("@sLesonderwerpID", sLesonderwerpID);           //Parameter with LesonderwerpID
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("De voortgang is opgeslagen!", "Succes!");
                LeerlingForm lf = new LeerlingForm(sUsername);
                lf.Show();
                lsForm.Close();
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan de voortgang.", "Error!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het verwijderen van de planning
        public void DeletePlanning(string sTable, string PlanningId)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM " + sTable + " WHERE id= @planningid");
            cmd.Connection = connect;
            cmd.Parameters.AddWithValue("@planningid", PlanningId);     //Parameter with PlanningID

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("de planning is succesvol verwijderd.", "Succes!");
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het vewijderen van de planning, probeer later nog eens.", "Oh oh!");
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Functie voor het toevoegen van een planning
        public void PlanningToevoegen(string LeerlingId, string LesId, DateTime SelectedDate, string GekozenLesNaam, string sUsername)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into planning (leerlingid, lesid, datum, lesnaam, usrname) VALUES (@leerlingid, @lesid, @selecteddate, @lesnaam, @usrname)";
            cmd.Parameters.AddWithValue("@leerlingid", LeerlingId);         //Parameter with LeerlingID
            cmd.Parameters.AddWithValue("@lesid", LesId);                   //Parameter with LesID
            cmd.Parameters.AddWithValue("@selecteddate", SelectedDate);     //Parameter with Selected date
            cmd.Parameters.AddWithValue("@lesnaam", GekozenLesNaam);        //Parameter with Gekozen lesnaam
            cmd.Parameters.AddWithValue("@usrname", sUsername);             //Parameter with Username
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("De planning is succesvol toegevoegd!", "Succes!");
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan van het nieuwe account, probeer het nog eens ", "Error!");
            }

            finally     //Close database connection
            {
                connect.Close();

            }
        }

        //Functie voor het vinden van de planning via de username
        public DataTable FindPlanningMetUsername(string sTable, string sParameterA, string sParameterB, string sCurrentDate)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + sTable + " WHERE " + sParameterA + "='" + sParameterB + "' AND datum <= '" + sCurrentDate + "'"))
            {
                try
                {
                    cmd.Connection = connect;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    retValue.Load(reader);
                }

                catch       //Foutafhandeling
                {
                    MessageBox.Show("IDUNNOWHATHAPPENED");
                }

                finally     //Close database connection
                {
                    connect.Close();
                }
            }

            //Return result
            return retValue;
        }

        //Functie voor het vinden van de bestaande planning
        public DataTable CheckExistancePlanning(string sTable, string sParameterA, string sParameterB, string sColumn)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + sTable + " WHERE usrname ='" + sParameterA + "'AND " + sColumn + " ='" + sParameterB + "'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }

            //Return result
            return retValue;
        }
        public void addVraag(string vraag, string lesID, string loID)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO vragen(Vraag, LesID, LesonderwerpID) VALUES('" + vraag + "', '" + lesID + "' ,'" + loID + "')");
            cmd.Connection = connect;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Het toevoegen van de vraag is voltooid", "Yes!");
            }
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het toevoegen van de vraag, probeer later nog eens.", "Whoops!");
            }
            finally
            {
                connect.Close();
            }
        }

        public string getVraagID(string Vraag, string lesID, string loID)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from vragen where vraag='" + Vraag + "' and LesID ='" + lesID + "' and LesonderwerpID = '" + loID + "'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            string vraagID = Convert.ToString(retValue.Rows[0]["VraagID"]);
            return vraagID;
        }

        public void addAntwoord(string vraag, string lesID, string loID, int juistAntwoord, string AntwoordA, string AntwoordB, string AntwoordC, string AntwoordD)
        {
            //Ophalen van het vraag ID
            string VraagID = getVraagID(vraag, lesID, loID).ToString();

            //Veranderen van de sql command
            string sql = "";
            switch (juistAntwoord)
            {
                case 1:
                    sql = "insert into antwoorden(VraagID, Antwoord, Juist_Onjuist) VALUES('" + VraagID + "', '" + AntwoordA + "', '1'), ('" + VraagID + "', '" + AntwoordB + "', '2'), ('" + VraagID + "', '" + AntwoordC + "', '2'), ('" + VraagID + "', '" + AntwoordD + "', '2');";
                    break;
                case 2:
                    sql = "insert into antwoorden(VraagID, Antwoord, Juist_Onjuist) VALUES('" + VraagID + "', '" + AntwoordA + "', '2'), ('" + VraagID + "', '" + AntwoordB + "', '1'), ('" + VraagID + "', '" + AntwoordC + "', '2'), ('" + VraagID + "', '" + AntwoordD + "', '2');";
                    break;
                case 3:
                    sql = "insert into antwoorden(VraagID, Antwoord, Juist_Onjuist) VALUES('" + VraagID + "', '" + AntwoordA + "', '2'), ('" + VraagID + "', '" + AntwoordB + "', '2'), ('" + VraagID + "', '" + AntwoordC + "', '1'), ('" + VraagID + "', '" + AntwoordD + "', '2');";
                    break;
                case 4:
                    sql = "insert into antwoorden(VraagID, Antwoord, Juist_Onjuist) VALUES('" + VraagID + "', '" + AntwoordA + "', '2'), ('" + VraagID + "', '" + AntwoordB + "', '2'), ('" + VraagID + "', '" + AntwoordC + "', '2'), ('" + VraagID + "', '" + AntwoordD + "', '1');";
                    break;
            }

            //Connectie met de database + maak het command aan
            db_connection();
            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Connection = connect;

            //Voer de query uit + Fout afhandeling
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Het toevoegen van de antwoorden is voltooid", "Hoera!");
            }
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het toevoegen van de antwoorden, probeer later nog eens.", "O jeetje!");
            }
            finally
            {
                connect.Close();
            }
        }

        public void ToetsPlanningToevoegen(string LesOnderwerpId, string LeerlingUsername, DateTime SelectedDate, string ToetsNaam, string sLeerlingId, string VakID)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into toetsplanning (lesonderwerpid, usrname, datum, toetsnaam, leerlingid, VakID) VALUES (@lesonderwerpid, @leerlingusername, @selecteddate, @toetsnaam, @leerlingid, @vakID)";
            cmd.Parameters.AddWithValue("@leerlingid", sLeerlingId);
            cmd.Parameters.AddWithValue("@leerlingusername", LeerlingUsername);
            cmd.Parameters.AddWithValue("@lesonderwerpid", LesOnderwerpId);
            cmd.Parameters.AddWithValue("@selecteddate", SelectedDate);
            cmd.Parameters.AddWithValue("@toetsnaam", ToetsNaam);
            cmd.Parameters.AddWithValue("@vakID", VakID);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("De toetsplanning is succesvol toegevoegd!", "Succes!");
            }

            catch       //Foutafhandeling
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan van de nieuwe toetsplanning, probeer het nog eens ", "Error!");
            }

            finally     //Close database connection
            {
                connect.Close();

            }
        }

        //
        public bool checkToets(string loID)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("select * from toetsplanning where lesonderwerpid=" + loID);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }

            catch       //Foutafhandeling
            {
                return false;
            }

            finally     //Close database connection
            {
                connect.Close();
            }
        }

        //Tel de lessen in een lesonderwerp
        public int CountLessen(string loID)
        {
            db_connection();

            int result = 0;

            using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM les where LesonderwerpID=" + loID))
            {
                try
                {
                    cmd.Connection = connect;
                    result = int.Parse(cmd.ExecuteScalar().ToString());
                }

                catch       //Foutafhandeling
                {
                    MessageBox.Show("Er is iets mis gegaan met het ophalen van het aantal lessen", "Oops!");
                }

                finally     //Close database connection
                {
                    connect.Close();
                }

            }

            return result;
        }

        //Tell het aantal gemaakte lessen door een leerling van een lesonderwerp
        public int CountLessenVoortgang(string sUsername, string loID)
        {
            db_connection();
            string sUserID;
            int result = 0;

            using (MySqlCommand cmd = new MySqlCommand("select UserID from users where Username='" + sUsername + "'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    sUserID = reader[0].ToString();

                    connect.Close();
                    db_connection();

                    using (MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) FROM voortgang where LesonderwerpID='" + loID + "' and UserID='" + sUserID + "'"))
                    {
                        try
                        {
                            cmd2.Connection = connect;
                            result = int.Parse(cmd2.ExecuteScalar().ToString());
                        }

                        catch       //Foutafhandeling
                        {
                            MessageBox.Show("Er is iets mis gegaan met het ophalen van het aantal lessen", "Oops!");
                        }

                        finally     //Close database connection
                        {
                            connect.Close();
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Kan niet de juiste gegevens ophalen", "Whoops!");
                }

                return result;
            }
        }

        //Tell het aantal gemaakte lessen door een leerling van een lesonderwerp
        public void SaveResultaat(string sUsername, string loID, string sResultaat)
        {
            db_connection();
            string sUserID;

            using (MySqlCommand cmd = new MySqlCommand("select UserID from users where Username='" + sUsername + "'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    sUserID = reader[0].ToString();

                    connect.Close();
                    db_connection();

                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.CommandText = "INSERT INTO `toetsresultaten`(`UserID`, `LesonderwerpID`, `Resultaat`) VALUES (@sUserID, @loID, @sResultaat)";
                    cmd2.Parameters.AddWithValue("@sUserID", sUserID);
                    cmd2.Parameters.AddWithValue("@loID", loID);
                    cmd2.Parameters.AddWithValue("@sResultaat", sResultaat);
                    cmd2.Connection = connect;

                    try
                    {
                        cmd2.ExecuteNonQuery();
                    }

                    catch       //Foutafhandeling
                    {
                        MessageBox.Show("Er is iets mis gegaan met het opslaan van jouw cijfer, roep de juf/meester om hulp!", "Ohnee!");
                    }

                    finally     //Close database connection
                    {
                        connect.Close();
                    }
                }

                else
                {
                    MessageBox.Show("Kan niet de juiste gegevens ophalen", "Whoops!");
                }

            }
        }

        public DataTable CijferlijstOphalen(string sUsername)
        {
            DataTable retValue = new DataTable();
            db_connection();
            string sUserID;

            using (MySqlCommand cmd = new MySqlCommand("select UserID from users where Username='" + sUsername + "'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    sUserID = reader[0].ToString();

                    connect.Close();



                    db_connection();

                    using (MySqlCommand cmd2 = new MySqlCommand("select distinct toetsresultaten.Resultaat, lesonderwerp.Omschrijving, vak.Omschrijving from lesonderwerp inner join toetsresultaten on lesonderwerp.LesonderwerpID = toetsresultaten.LesonderwerpID inner join vak on lesonderwerp.VakID = vak.VakID where toetsresultaten.UserID = '" + sUserID + "'"))
                    {
                        cmd2.Connection = connect;
                        MySqlDataReader reader2 = cmd2.ExecuteReader();
                        retValue.Load(reader2);
                        connect.Close();
                    }

                    //Return result
                    return retValue;
                }
                else
                {
                    MessageBox.Show("Kan geen cijfers ophalen", "Oops!");
                    return retValue;
                }
            }
        }

        public DataTable ResultaatMessage(string loID)
        {
            DataTable retValue = new DataTable();
            db_connection();


            using (MySqlCommand cmd = new MySqlCommand("select distinct lesonderwerp.Omschrijving, vak.Omschrijving from lesonderwerp inner join vak on lesonderwerp.VakID = vak.VakID where lesonderwerp.LesonderwerpID='" + loID + "'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }

            //Return result
            return retValue;
        }
    }
}