using PollutionMap.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace PollutionMap.SqlDataAccess
{
    public class DataBaseHelper
    {
        private static readonly string _connectionstring = DataAccess.GetConnectionString();
        private static readonly string _hartipath  = DataAccess.GetHartiPath();
        private static readonly string _masuraripath = DataAccess.GetMasurariPath();

        public static void Initialisation()
        {
            using(SqlConnection con = new SqlConnection( _connectionstring)) 
            {
            
                DeleteDataTables(con);
                InsertIntoHarti(con);
                InsertIntoMasurari(con);
            }

                UserModel userModel = new UserModel();
                {
                    userModel.Nume = "oti2022";
                    userModel.Email = "oti2022@oti.com";
                    userModel.Password = "oti1234";
                }
                AddUser(userModel);
            
        }

        public static void AddUser(UserModel userModel)
        {
            using(SqlConnection con = new SqlConnection( _connectionstring )) 
            {
                con.Open();
                string cmdText = "Insert into Utilizatori (NumeUtilizator, Parola, EmailUtilizator) values (@nume, @parola, @email)";
                using(SqlCommand cmd = new SqlCommand(cmdText, con)) 
                { 
                    cmd.Parameters.AddWithValue("@nume", userModel.Nume);
                    cmd.Parameters.AddWithValue("@parola", userModel.Password);
                    cmd.Parameters.AddWithValue("@email", userModel.Email);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public static void InsertIntoMasurari(SqlConnection con)
        {
            con.Open();
            using (StreamReader reader = new StreamReader(_masuraripath))
                {
                    while (reader.Peek() > 0)
                    {
                        int id = 0;
                        string line = reader.ReadLine();
                        string[] split = line.Split('#');
                        string cmdIdText = "Select IdHarta from Harti where NumeHarta = @nume";
                        string cmdInserareText = "Insert into Masurare (IdHarta, PozitieX, PozitieY, ValoareMasurare, DataMasurare) values (@id, @pozx, @poxy, @val, @data)";
                        using (SqlCommand cmd = new SqlCommand(cmdIdText, con))
                        {
                            cmd.Parameters.AddWithValue("@nume", split[0]);
                            using (SqlDataReader reader2 = cmd.ExecuteReader())
                            {
                                reader2.Read();
                                id = Convert.ToInt32(reader2[0]);
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand(cmdInserareText, con))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@pozx", split[1]);
                            cmd.Parameters.AddWithValue("@poxy", split[2]);
                            cmd.Parameters.AddWithValue("@val", split[3]);
                            DateTime date = DateTime.ParseExact(split[4], "dd/MM/yyyy HH:mm", null);
                            cmd.Parameters.AddWithValue("@data", date);
                            cmd.ExecuteNonQuery();
                        }

                    }
                
            }con.Close();

        }

        public static void InsertIntoHarti(SqlConnection con)
        {
            con.Open();

            using (StreamReader reader = new StreamReader(_hartipath))
            {
                while (reader.Peek() > 0)
                {
                    string line = reader.ReadLine();
                    string[] split = line.Split('#');

                    string cmdText = "Insert into Harti (NumeHarta, FisierHarta) values (@nume, @fisier)";
                    using(SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        cmd.Parameters.AddWithValue("@nume", split[0]);
                        cmd.Parameters.AddWithValue("@fisier", split[1]);
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            con.Close();
        }

        public static void DeleteDataTables(SqlConnection con)
        {
            con.Open();
            ExecuteCommand("Harti",con);
            ExecuteCommand("Masurare", con);
            ExecuteCommand("Utilizatori", con);
            con.Close();
        }

        private static void ExecuteCommand(string tableName ,SqlConnection con)
        {
            string cmdDeleteText = "Delete from " + tableName;
            string cmdReseedText = "DBCC CHECKIDENT ( " + tableName +" , RESEED ,0)";
            SqlCommand cmdDelete = new SqlCommand(cmdDeleteText,con);
            SqlCommand cmdReseed = new SqlCommand( cmdReseedText,con);
            cmdDelete.ExecuteNonQuery();
            cmdReseed.ExecuteNonQuery();
          
        }
        
        public static bool isValidName(string name)
        {
            bool result = true;
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                con.Open();
                string cmdText = "Select * from Utilizatori where NumeUtilizator = @nume";
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@nume", name);
                   using(SqlDataReader  reader = cmd.ExecuteReader()) 
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            result = false;
                        }
                    }
                }

            }
            return result;

        }
        public static UserModel FindUser(UserModel user)
        {
            UserModel model = new UserModel();
            model.Nume = user.Nume;
            model.Password = user.Password;
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                con.Open();
                string cmdText = "Select * from Utilizatori where NumeUtilizator = @nume and Parola=@parola";
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@nume", model.Nume);
                    cmd.Parameters.AddWithValue("@parola", model.Password);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            model.Email = reader[3].ToString();
                            model.Id = Convert.ToInt32(reader[0]);
                            model.UltimaUtilizare = DateTime.Now;}
                         }  
                        string InsertDate = "Update Utilizatori set UltimaUtilizare= @date where IdUtilizator = @id";
                            using (SqlCommand cmd2 = new SqlCommand(InsertDate, con)) 
                            {
                                cmd2.Parameters.AddWithValue("@date", model.UltimaUtilizare);
                                cmd2.Parameters.AddWithValue("@id", model.Id);
                                cmd2.ExecuteNonQuery();
                            }
                }

            }

            return model;
        }

        public static List<HartaModel> Imagini()
        {
            List<HartaModel> list = new List<HartaModel>();
            using(SqlConnection con = new SqlConnection(_connectionstring))
            {  con.Open();
                string cmdText = "Select *  from Harti";
                using (SqlCommand cmd = new SqlCommand(cmdText,con))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                          HartaModel harta = new HartaModel();
                            {
                                harta.Id = Convert.ToInt32(reader[0]);
                                harta.Name = reader[1].ToString();
                                harta.Fisier = reader[2].ToString();
                            }
                            list.Add(harta);
                        }
                    }
                }

            }
            return list;

        }

        public static List<MasurareModel> GetMasuratori(int selectedItem, DateTime value)
        {
           List<MasurareModel> masuratori = new List<MasurareModel>();
            using(SqlConnection con = new SqlConnection(_connectionstring)) 
            {
                con.Open();
                string cmtText = "Select * from Masurare where IdHarta = @id";
                using(SqlCommand cmd = new SqlCommand(cmtText, con))
                {
                    cmd.Parameters.AddWithValue("@id", selectedItem);
                    cmd.Parameters.AddWithValue("@data", value);
                    using(SqlDataReader reader=cmd.ExecuteReader()) 
                    {
                        while(reader.Read())
                        {
                          DateTime date = Convert.ToDateTime(reader[5]);
                            if (date.Date == value.Date)
                            {
                                MasurareModel masurare = new MasurareModel();
                                {
                                    masurare.PozitieX = Convert.ToInt32(reader[2]);
                                    masurare.PozitieY = Convert.ToInt32(reader[3]);
                                    masurare.Valoare = Convert.ToInt32(reader[4]);
                                }
                                masuratori.Add(masurare);
                            }
                        }
                    }
                }
            }
            return masuratori;
        }

        public static void AddMasurare(MasurareModel masurare)
        {
            using(SqlConnection  conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                string cmdText = "Insert into Masurare (IdHarta, PozitieX, PozitieY, ValoareMasurare, DataMasurare) values (@id, @pozx, @poxy, @val, @data)";
                using(SqlCommand cmd= new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@id", masurare.IdHarta);
                    cmd.Parameters.AddWithValue("@pozx", masurare.PozitieX);
                    cmd.Parameters.AddWithValue("@poxy", masurare.PozitieY);
                    cmd.Parameters.AddWithValue("@val", masurare.Valoare);
                    cmd.Parameters.AddWithValue("@data", masurare.Data);
                    cmd.ExecuteNonQuery();


                }
            }
        }
    }
}
