using PollutionMap.Model;
using PollutionMap.SqlDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PollutionMap.Forms
{
    public partial class Vizualizare : Form
    {
        public UserModel user = new UserModel();
        string HartiFolderPath;
        int selectedItem;
        List<HartaModel> imagini = null;
        Image original = null;
        List<MasurareModel> masuratori;

        public Vizualizare()
        {
            InitializeComponent();
        }

        private void Vizualizare_Load(object sender, EventArgs e)
        {
            dateTimePicker.CustomFormat = "dd/MM/yyyy";
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            HartiFolderPath = projectDirectory + @"\Resurse\Harti\";

            hartaPictureBox.Image = Image.FromFile(HartiFolderPath + "default_harta.png");
            original = hartaPictureBox.Image;
            
            utilizatorLabel.Text = "Utilizator: " + user.Nume;
            hartiComboBox.Text = "Selecteaza o harta";
            filtruComboBox.Text = "Selecteaza un filtru";

            imagini = DataBaseHelper.Imagini();

            foreach (HartaModel imaginiItem in imagini)
            {
                hartiComboBox.Items.Add(imaginiItem.Name);
            }


            filtruComboBox.Items.Add("Niciun filtru");
            filtruComboBox.Items.Add("Valoare<20");
            filtruComboBox.Items.Add("20<=Valoare<=40");
            filtruComboBox.Items.Add("Valoare>40");




        }

        private void hartiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = hartiComboBox.SelectedItem.ToString().Trim();

            HartaModel element = imagini.Find(el => el.Name.Trim() == selected);

            original = Image.FromFile(HartiFolderPath + element.Fisier);
            hartaPictureBox.Image = Image.FromFile(HartiFolderPath + element.Fisier);
            selectedItem = element.Id;

        }

        private void filtrareButton_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(hartaPictureBox.Width, hartaPictureBox.Width);    

            Graphics graphics = Graphics.FromImage(bmp);
            graphics.DrawImage(original,0,0,bmp.Width,bmp.Height);  
            Pen pen = new Pen(Color.White);

           masuratori = DataBaseHelper.GetMasuratori(selectedItem, dateTimePicker.Value);

            if (filtruComboBox.SelectedItem != null)
            {
                if (filtruComboBox.SelectedItem.ToString() == "Niciun filtru")
                {
                    foreach (MasurareModel masurare in masuratori)
                    {
                        if (masurare.Valoare < 20)
                        {
                            pen.Color = Color.Green;
                        }
                        if (masurare.Valoare >= 20 && masurare.Valoare <= 40)
                        {
                            pen.Color = Color.Yellow;
                        }
                        if (masurare.Valoare > 40)
                        {
                            pen.Color = Color.Red;
                        }
                        graphics.DrawEllipse(pen, masurare.PozitieX - 20, masurare.PozitieY - 20, 40, 40);
                        FontFamily fontFamily = new FontFamily("Arial");
                        Font font = new Font(fontFamily, 12);
                        Brush brush = new SolidBrush(pen.Color);
                        graphics.DrawString(masurare.Valoare.ToString(), font, brush, masurare.PozitieX - 12, masurare.PozitieY - 12);
                    }
                    hartaPictureBox.Image = bmp;
                }
                else if (filtruComboBox.SelectedItem.ToString() == "Valoare<20")
                {
                    foreach (MasurareModel masurare in masuratori)
                    {
                        if (masurare.Valoare < 20)
                        {
                            pen.Color = Color.Green; graphics.DrawEllipse(pen, masurare.PozitieX - 20, masurare.PozitieY - 20, 40, 40);
                            FontFamily fontFamily = new FontFamily("Arial");
                            Font font = new Font(fontFamily, 12);
                            Brush brush = new SolidBrush(pen.Color);
                            graphics.DrawString(masurare.Valoare.ToString(), font, brush, masurare.PozitieX - 12, masurare.PozitieY - 12);
                        }
                        hartaPictureBox.Image = bmp;
                    }
                }
                else if (filtruComboBox.SelectedItem.ToString() == "20<=Valoare<=40")
                {
                    foreach (MasurareModel masurare in masuratori)
                    {
                        if (masurare.Valoare <= 40 && masurare.Valoare >= 20)
                        {
                            pen.Color = Color.Yellow; graphics.DrawEllipse(pen, masurare.PozitieX - 20, masurare.PozitieY - 20, 40, 40);
                            FontFamily fontFamily = new FontFamily("Arial");
                            Font font = new Font(fontFamily, 12);
                            Brush brush = new SolidBrush(pen.Color);
                            graphics.DrawString(masurare.Valoare.ToString(), font, brush, masurare.PozitieX - 12, masurare.PozitieY - 12);
                        }
                        hartaPictureBox.Image = bmp;
                    }
                }
                else if (filtruComboBox.SelectedItem.ToString() == "Valoare>40")
                {
                    foreach (MasurareModel masurare in masuratori)
                    {
                        if (masurare.Valoare > 40)
                        {
                            pen.Color = Color.Red; graphics.DrawEllipse(pen, masurare.PozitieX - 20, masurare.PozitieY - 20, 40, 40);
                            FontFamily fontFamily = new FontFamily("Arial");
                            Font font = new Font(fontFamily, 12);
                            Brush brush = new SolidBrush(pen.Color);
                            graphics.DrawString(masurare.Valoare.ToString(), font, brush, masurare.PozitieX - 12, masurare.PozitieY - 12);
                        }
                        hartaPictureBox.Image = bmp;
                    }
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(hartaPictureBox.Image);
            Graphics graphics = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.White);
           

            foreach (MasurareModel masurare in masuratori)
            {
                if (masurare.Valoare < 20)
                {
                    pen.Color = Color.Green;
                }
                if (masurare.Valoare >= 20 && masurare.Valoare <= 40)
                {
                    pen.Color = Color.Yellow;
                }
                if (masurare.Valoare > 40)
                {
                    pen.Color = Color.Red;
                }
                graphics.DrawEllipse(pen, masurare.PozitieX - 20, masurare.PozitieY - 20, 40, 40);
                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(fontFamily, 12);
                Brush brush = new SolidBrush(pen.Color);
                graphics.DrawString(masurare.Valoare.ToString(), font, brush, masurare.PozitieX - 12, masurare.PozitieY - 12);
            }
            hartaPictureBox.Image = bmp;
        }



        private void hartaPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point clickedPoint = hartaPictureBox.PointToClient(Cursor.Position);

            var elem = masuratori.Find(el => el.PozitieX == clickedPoint.X && el.PozitieY == clickedPoint.Y);


            if (elem != null) { MessageBox.Show("Exista deja o masuratoare in aceasta locatie!"); }
            else
            {
               
                AdaugareMasurare adaugareMasurare = new AdaugareMasurare();
                adaugareMasurare.ShowDialog();
                int valueMasurare = adaugareMasurare.val;
                DateTime date = dateTimePicker.Value;
                    
                MasurareModel masurare = new MasurareModel();
                {
                    masurare.PozitieX = clickedPoint.X;
                    masurare.PozitieY = clickedPoint.Y;
                    masurare.Valoare = valueMasurare;
                    masurare.IdHarta = selectedItem;
                    masurare.Data = date;
                }

                DataBaseHelper.AddMasurare(masurare);
                filtrareButton.PerformClick();
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex==1)
            {
                Bitmap bmp = new Bitmap(hartaPictureBox.Image);
                Graphics graphics = Graphics.FromImage(bmp);
                Pen pen = new Pen(Color.White);


                foreach (MasurareModel masurare in masuratori)
                {
                    if (masurare.Valoare < 20)
                    {
                        pen.Color = Color.Green;
                    }
                    if (masurare.Valoare >= 20 && masurare.Valoare <= 40)
                    {
                        pen.Color = Color.Yellow;
                    }
                    if (masurare.Valoare > 40)
                    {
                        pen.Color = Color.Red;
                    }
                    graphics.DrawEllipse(pen, masurare.PozitieX - 20, masurare.PozitieY - 20, 40, 40);
                    FontFamily fontFamily = new FontFamily("Arial");
                    Font font = new Font(fontFamily, 12);
                    Brush brush = new SolidBrush(pen.Color);
                    graphics.DrawString(masurare.Valoare.ToString(), font, brush, masurare.PozitieX - 12, masurare.PozitieY - 12);
                }
                traseuPictureBox.Image = bmp;
            }
        }

        private void traseuPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point clickedPoint = traseuPictureBox.PointToClient(Cursor.Position);

            MasurareModel elem = new MasurareModel();
            

            foreach(MasurareModel model in masuratori)
            {
                double distance = Math.Sqrt((clickedPoint.X - model.PozitieX) * (clickedPoint.X - model.PozitieX) + (clickedPoint.Y - model.PozitieY) * (clickedPoint.Y - model.PozitieY));
                if (distance <= 20)
                {
                    elem = model;
                }
            }

            if(elem != null && elem.Valoare >=40) {
                
                  var orderedMasuratori = masuratori.OrderByDescending(el => el.Valoare).ToList();
                Bitmap bmp = new Bitmap(traseuPictureBox.Image);
                Graphics graphics = Graphics.FromImage(bmp);
                Pen pen = new Pen(Color.Red);
                int v= orderedMasuratori[0].Valoare;
                graphics.DrawLine(pen, clickedPoint.X, clickedPoint.Y, orderedMasuratori[0].PozitieX, orderedMasuratori[0].PozitieY);
                traseuPictureBox.Image=bmp;


            }
            else   MessageBox.Show("Selectați un punct de pe hartă corespunzător unei măsurări existente în baza de date!");

        }
    }
}
