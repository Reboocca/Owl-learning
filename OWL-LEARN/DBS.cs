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
        private string conn;
        private MySqlConnection connect;

        private void db_connection()
        {
            try
            {
                conn = "Server=localhost;Database=owl-learn;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Kan geen verbinding maken met de database", "Oh nee!");
            }
        }

        private bool validate_login(string user, string password)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from users where Username=@user and Password=@pass";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", password);
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

        public void try_login(string user, string password, MainWindow loginform)
        {

            if (user == "" || password == "")
            {
                MessageBox.Show("Vul uw gebruikersnaam en wachtwoord in", "Oeps!");
                return;
            }
            bool r = validate_login(user, password);
            if (r)
            {
                string sRolID = GetRol(user).ToString();
                if (sRolID == "1")
                {
                    ConsulentForm form = new ConsulentForm(user);
                    form.Show();
                    loginform.Close();
                }

                else if (sRolID == "2")
                {
                    LeerlingForm form = new LeerlingForm(user);
                    form.Show();
                    loginform.Close();
                }

                else
                {
                    MessageBox.Show("Er is een fout opgetreden in het systeem, neem contact op met de beheerders van het programma", "Whoops!");
                }

            }
            else
            {
                MessageBox.Show("Uw gebruikersnaam of wachtwoord is onjuist", "Oh oh...");
            }
        }

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
            string RolID = Convert.ToString(retValue.Rows[0]["rolID"]);
            return RolID;
        }
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
            return retValue;
        }

        public DataTable getLO(string vakID)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from lesonderwerp where VakID=" + vakID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable getLes(string lesOnderwerpID)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from Les where LesOnderwerpID=" + lesOnderwerpID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable getVragen(string lesID)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from vragen where LesID=" + lesID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public void DeleteVraag(string vID)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM vragen WHERE VraagID=" + vID);
            bool r = DeleteAntwoorden(vID);

            try
            {
                db_connection();
                cmd.Connection = connect;
                cmd.ExecuteNonQuery();
                if (r)
                {
                    MessageBox.Show("De vraag is succesvol verwijderd.", "Succes!");
                }
                else
                {
                    MessageBox.Show("Er is iets mis gegaan met het verwijderen van de antwoorden die bij de vraag horen, contacteer een beheerder", "Ohjee.");
                }
                
            }
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het verwijderen van de vraag, probeer later nog eens.", "Oh oh!");
            }
            finally
            {
                connect.Close();
            }
        }

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
            catch
            {
                return false;
            }
            finally
            {
                connect.Close();
            }
        }

        public DataTable getLOcms(string VakNaam)
        {
            string VakID = "0";
            switch (VakNaam)
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
            return retValue;
        }

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

                switch (VakID)
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
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het vewijderen van het lesonderwerp, probeer later nog eens.", "Whoops!");
            }
            finally
            {
                connect.Close();
            }
        }

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
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het vewijderen van het lesonderwerp, probeer later nog eens.", "Oh oh!");
            }
            finally
            {
                connect.Close();
            }
        }

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
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het wijzigen van het lesonderwerp, probeer later nog eens.", "Oh oh!");
            }
            finally
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

        public DataTable getAccounts(string rol)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from users where rolID=" + rol))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
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

        public DataTable getGegevens(string userID)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from users where userID=" + userID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable getLOnaam(string loID)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from lesonderwerp where lesonderwerpID=" + loID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable getLesInfo(string lID)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from les where lesID=" + lID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable GetUitleg(string sLesID)
        {
            DataTable retValue = new DataTable();
            db_connection();

            using (MySqlCommand cmd = new MySqlCommand("Select Uitleg from les where LesID=" + sLesID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable GetVraag(string sLesID)
        {
            DataTable retValue = new DataTable();
            db_connection();

            using (MySqlCommand cmd = new MySqlCommand("Select * from vragen where LesID=" + sLesID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable GetAntwoorden(string sVraagID)
        {
            DataTable retValue = new DataTable();
            db_connection();

            using (MySqlCommand cmd = new MySqlCommand("Select * from antwoorden where VraagID=" + sVraagID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
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

        public DataTable GetToetsVraag(string sLesonderwerpID)
        {
            DataTable retValue = new DataTable();
            db_connection();

            using (MySqlCommand cmd = new MySqlCommand("Select * from vragen where LesonderwerpID=" + sLesonderwerpID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable GetToetsVraagByID(string sVraagID)
        {
            DataTable retValue = new DataTable();
            db_connection();

            using (MySqlCommand cmd = new MySqlCommand("Select * from vragen where VraagID=" + sVraagID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
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
        public void PlanningToevoegen(string LeerlingId, string LesId, DateTime SelectedDate, string GekozenLesNaam)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into planning (leerlingid, lesid, datum, lesnaam) VALUES (@leerlingid, @lesid, @selecteddate, @lesnaam)";
            cmd.Parameters.AddWithValue("@leerlingid", LeerlingId);
            cmd.Parameters.AddWithValue("@lesid", LesId);
            cmd.Parameters.AddWithValue("@selecteddate", SelectedDate);
            cmd.Parameters.AddWithValue("@lesnaam", GekozenLesNaam);
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
        public DataTable getLeerlingen()
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from users where RolID = 2"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }
        public DataTable GetPlanningen(string sGekozenLeerlingId)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from planning WHERE leerlingid =" + sGekozenLeerlingId + ""))
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
