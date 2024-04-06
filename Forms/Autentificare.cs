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
    public partial class Autentificare : Form
    {
        public UserModel user = new UserModel();
        public Autentificare()
        {
            InitializeComponent();
        }

        private void Autentificare_Load(object sender, EventArgs e)
        {
            DataBaseHelper.Initialisation();
            numeTextBox.Text = "oti2022";
            parolaTextBox.Text = "oti1234";
;
        }

        private void singUpButton_Click(object sender, EventArgs e)
        {
            Inregistrare inregistrare = new Inregistrare();
            this.Hide();
            inregistrare.ShowDialog();
            this.Show();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            user.Nume= numeTextBox.Text;
            user.Password= parolaTextBox.Text;
            user = DataBaseHelper.FindUser(user);
            if (user.Email != null)
            {
                Vizualizare vizualizare = new Vizualizare();
                vizualizare.user = user;
                this.Hide();
                vizualizare.ShowDialog();
                this.Show();
            }
            else { MessageBox.Show("Nume de utilizator si/sau parola invalida!");
                numeTextBox.Text = "";
                parolaTextBox.Text = "";
            }

        }
    }
}
