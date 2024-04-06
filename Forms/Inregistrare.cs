using PollutionMap.Model;
using PollutionMap.SqlDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollutionMap.Forms
{
    public partial class Inregistrare : Form
    {
        public UserModel user = new UserModel();
        public Inregistrare()
        {
            InitializeComponent();
        }

        private void renuntaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidareEmail(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string[] parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false;
            }

            string localPart = parts[0];
            string domainPart = parts[1];
            if (string.IsNullOrWhiteSpace(localPart) || string.IsNullOrWhiteSpace(domainPart))
            {
                return false;
            }


            foreach (char c in localPart)
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '-')
                {
                    return false;
                }
            }


            if (domainPart.Length < 2 || !domainPart.Contains(".") || domainPart.Split('.').Length != 2 || domainPart.EndsWith(".") || domainPart.StartsWith("."))
            {
                return false;
            }

            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (numeTextBox.Text.Length > 4)
            {
                if (parolaTextBox.Text.Length >= 6)
                {
                    if (parolaTextBox.Text == confirmTextBox.Text)
                    {
                        if (ValidareEmail(emailTextBox.Text))
                        {
                            if (DataBaseHelper.isValidName(numeTextBox.Text))
                            {

                                user.Email = emailTextBox.Text;
                                user.Nume = numeTextBox.Text;
                                user.Password= parolaTextBox.Text;
                                DataBaseHelper.AddUser(user);
                            }
                            else MessageBox.Show("Exista deja un utilizator cu acest nume");
                        }
                        else MessageBox.Show("Email-ul nu este valid!");
                    }
                    else MessageBox.Show("Campul parola si confirmare parola nu coincid");
                }
                else MessageBox.Show("Parola trebuie sa aiba mai mult de 6 caractere");
            }
            else MessageBox.Show("Numele trebuie sa aiba mai mult de 4 caractere");
        }
    }
}
