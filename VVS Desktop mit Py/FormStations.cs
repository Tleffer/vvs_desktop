using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VVS_Desktop_mit_Py
{
    public partial class FormStations : Form
    {
        List<string> ListStation;
        List<string> ListID;
        List<string> ListCity;
        string input;
        public FormStations(List<string> Station, List<string> ID, List<string> City, string inp)
        {
            InitializeComponent();
            ListStation = Station;
            ListID = ID;
            ListCity = City;
            input = inp;
        }

        private void FormStations_Load(object sender, EventArgs e)
        {
            stations_text.Text = "";
            for (int i = 0; i < ListStation.Count; i++)
            {
                if (ListCity[i] == input)
                {
                    stations_text.Text += ListStation[i] + Environment.NewLine;
                }
            }
        }
    }
}
