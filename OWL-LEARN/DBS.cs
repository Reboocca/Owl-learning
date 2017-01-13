﻿using MySql.Data.MySqlClient;
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
                MessageBox.Show("Er is iets mis gegaan met het vewijderen van het lesonderwerp, probeer later nog eens.", "Whoops!");
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
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het vewijderen van de les, probeer later nog eens.", "Oh oh!");
            }
            finally
            {
                connect.Close();
            }
        }

        public void newLes(string sloID, string sLesNaam, string sUitleg, Lestoevoegen regform, string user)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into les (LesID, Uitleg, LesonderwerpID, lesNaam) VALUES (NULL, @sUitleg, @sloID, @sLesNaam);";
            cmd.Parameters.AddWithValue("@sloID", sloID);
            cmd.Parameters.AddWithValue("@sLesNaam", sLesNaam);
            cmd.Parameters.AddWithValue("@sUitleg", sUitleg);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("De les: " + sLesNaam + " is succesvol aangemaakt.", "WOOHOO!");
                LesonderwerpWijzig form = new LesonderwerpWijzig(sloID, user);
                form.Show();
                regform.Close();

            }
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan van de les ", "OOPSIE!");
            }
            finally
            {
                connect.Close();

            }
        }

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
            string NaamUser = Convert.ToString(retValue.Rows[0]["firstName"]) + " " + Convert.ToString(retValue.Rows[0]["lastName"]);
            return NaamUser;
        }

        public void newAccount(string user, string rolID, string fName, string lName, string gName, string WW, AccountToevoeg form)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into users (Username, Password, firstName, lastName, rolID) VALUES (@sUsername, @sPassword, @sfName, @slName, @srolID)";
            cmd.Parameters.AddWithValue("@sUsername", gName);
            cmd.Parameters.AddWithValue("@sPassword", WW);
            cmd.Parameters.AddWithValue("@sfName", fName);
            cmd.Parameters.AddWithValue("@slName", lName);
            cmd.Parameters.AddWithValue("@srolID", rolID);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Het account van: " + fName + " " + lName + " is succesvol aangemaakt.", "Succes!");
                UserCMS newForm = new UserCMS(user);
                newForm.Show();
                form.Close();

            }
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan van het nieuwe account, probeer het nog eens ", "Error!");
            }
            finally
            {
                connect.Close();

            }
        }

        public void safeAccount(string user, string fName, string lName, string gName, string WW, string userID, AccountWijzigen form)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE  users SET Username=@sUsername, Password=@sPassword, firstName=@sfName, lastName=@slName  WHERE userID="+userID;
            cmd.Parameters.AddWithValue("@sUsername", gName);
            cmd.Parameters.AddWithValue("@sPassword", WW);
            cmd.Parameters.AddWithValue("@sfName", fName);
            cmd.Parameters.AddWithValue("@slName", lName);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Het account van: " + fName + " " + lName + " is succesvol gewijzigd.", "Succes!");
                UserCMS newForm = new UserCMS(user);
                newForm.Show();
                form.Close();

            }
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan van het nieuwe account, probeer het nog eens ", "Error!");
            }
            finally
            {
                connect.Close();

            }
        }

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
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het vewijderen van het account, probeer later nog eens.", "Oh oh!");
            }
            finally
            {
                connect.Close();
            }
        }

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
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het wijzigen van de les gegevens, probeer later nog eens.", "Oh oh!");
            }
            finally
            {
                connect.Close();
            }
        }

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
            return retValue;
        }

        public void findIDVoorVoortgang(string sUsername, string sLesID, LesForm lsForm)
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

                    updateVoortgang(sUserID, sLesID, sUsername, lsForm);
                }
            }
            connect.Close();
        }

        public void updateVoortgang(string sUserID, string sLesID, string sUsername, LesForm lsForm)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("insert into voortgang (UserID, LesID, Voortgang) VALUES (@sUserID, @sLesID, 1)");
            cmd.Parameters.AddWithValue("@sUserID", sUserID);
            cmd.Parameters.AddWithValue("@sLesID", sLesID);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("De voortgang is opgeslagen!", "Succes!");
                LeerlingForm lf = new LeerlingForm(sUsername);
                lf.Show();
                lsForm.Close();
            }
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan de voortgang.", "Error!");
            }
            finally
            {
                connect.Close();
            }
        }

        public void DeletePlanning(string PlanningId)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM planning WHERE id= @planningid");
            cmd.Connection = connect;
            cmd.Parameters.AddWithValue("@planningid", PlanningId);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("de planning is succesvol verwijderd.", "Succes!");
            }
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het vewijderen van de planning, probeer later nog eens.", "Oh oh!");
            }
            finally
            {
                connect.Close();
            }
        }

        public void PlanningToevoegen(string LeerlingId, string LesId, DateTime SelectedDate, string GekozenLesNaam, string sUsername)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into planning (leerlingid, lesid, datum, lesnaam, usrname) VALUES (@leerlingid, @lesid, @selecteddate, @lesnaam, @usrname)";
            cmd.Parameters.AddWithValue("@leerlingid", LeerlingId);
            cmd.Parameters.AddWithValue("@lesid", LesId);
            cmd.Parameters.AddWithValue("@selecteddate", SelectedDate);
            cmd.Parameters.AddWithValue("@lesnaam", GekozenLesNaam);
            cmd.Parameters.AddWithValue("@usrname", sUsername);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("De planning is succesvol toegevoegd!", "Succes!");
            }
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan van het nieuwe account, probeer het nog eens ", "Error!");
            }
            finally
            {
                connect.Close();

            }
        }
        public DataTable FindPlanningMetUsername(string sTable, string sParameterA, string sParameterB, string sCurrentDate)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + sTable + " WHERE " + sParameterA + "='" + sParameterB +"' AND datum > '" + sCurrentDate + "' OR usrname = '" + sCurrentDate + "' AND datum ='" + sCurrentDate + "'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }
        public DataTable CheckExistancePlanning(string sParameterA, string sParameterB)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM planning WHERE usrname ='" + sParameterA + "'AND lesid ="+ sParameterB ))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }


    }
}
