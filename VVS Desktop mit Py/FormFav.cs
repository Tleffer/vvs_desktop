using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace VVS_Desktop_mit_Py
{
    public partial class FormFav : Form
    {
        string fav1_id;
        string fav2_id;
        string fav1_name;
        string fav2_name;
        Form1 origin;
        fav favourite;
        List<string> ListStation;
        List<string> ListID;
        List<string> ListCity;
        public FormFav(fav fav, List<string> Station, List<string> ID, List<string> City, Form1 ori)
        {
            InitializeComponent();
            favourite = fav;
            ListStation = Station;
            ListID = ID;
            ListCity = City;
            origin = ori;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (fav1_box.Text != fav1_name)
            {
                if (ListStation.Contains(fav1_box.Text))
                {
                    fav1_id = ListID[ListStation.IndexOf(fav1_box.Text)];
                    fav1_name = fav1_box.Text;
                } else
                {
                    if (ListCity.Contains(fav1_box.Text))
                    {
                        FormStations stations = new FormStations(ListStation, ListID, ListCity, fav1_box.Text);
                        stations.Show();
                        //goto second;
                    }
                    else
                    {
                        MessageBox.Show("Bitte geben Sie eine valide Haltestelle oder Stadt ein!");
                        return;
                    }
                }
            }
            //second:
            if (fav2_box.Text != fav2_name)
            {
                if (ListStation.Contains(fav2_box.Text))
                {
                    fav2_id = ListID[ListStation.IndexOf(fav2_box.Text)];
                    fav2_name = fav2_box.Text;
                }
                else
                {
                    if (ListCity.Contains(fav2_box.Text))
                    {
                        FormStations stations = new FormStations(ListStation, ListID, ListCity, fav2_box.Text);
                        stations.Show();
                        //goto second;
                    }
                    else
                    {
                        MessageBox.Show("Bitte geben Sie eine valide Haltestelle oder Stadt ein!");
                        return;
                    }
                }
            }
            favourite.fav1ID = fav1_id;
            favourite.fav2ID = fav2_id;
            favourite.fav1Name = fav1_name;
            favourite.fav2Name = fav2_name;

            origin.updateButton();
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFav_Load(object sender, EventArgs e)
        {
            fav1_name = favourite.fav1Name;
            fav2_name = favourite.fav2Name;
            fav1_id = favourite.fav1ID;
            fav2_id = favourite.fav2ID;

            fav1_box.Text = fav1_name;
            fav2_box.Text = fav2_name;
        }
    }
}
