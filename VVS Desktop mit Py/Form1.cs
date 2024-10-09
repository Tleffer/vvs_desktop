using Python.Runtime;
using System.Buffers;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Unicode;
using System.Xml;
using System.Xml.Serialization;
namespace VVS_Desktop_mit_Py
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Hauptsteuerung des Programms
        /// </summary>

        //Initialisierrung der Variablen
        //PyObject sind Objekte bzw Variablen die aus Pythen übertragen werden
        List<string> listStation = new List<string>();
        List<string> listID = new List<string>();
        List<string> listCity = new List<string>();
        PyObject res;
        PyObject res_delay;
        PyObject res_delay_all;
        PyObject res_all;
        fav favourites;
        //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) ist der Path zu Appdata, an dem die favoriten gespeichert werden
        string favPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"VVS\favourites.xml");

        public Form1()
        {
            InitializeComponent();
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "VVS");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        private void button_result_Click(object sender, EventArgs e)
        {

            //alles in try catch, falls der PC keine Internetverbindung hat
            try
            {
                output.Text = "";
                output.Enabled = false;
                string station = "";
                if (fav2.Checked)
                {
                    station = favourites.fav2ID;
                }
                //4211 = Kirchheim ZOB
                else if (fav1.Checked)
                {
                    station = favourites.fav1ID;
                }
                else if (other.Checked)
                {
                    //erst wird nach stationsnamen geschaut
                    if (listStation.Contains(other_field.Text))
                    {
                        station = listID[listStation.IndexOf(other_field.Text)];
                    }
                    else
                    {
                        //wenn keine station gefunden wird nach der stadt
                        if (listCity.Contains(other_field.Text))
                        {
                            //Ein Fenster mit allen möglichen Optionen der Stationen wird geöffnet
                            FormStations stations = new FormStations(listStation, listID, listCity, other_field.Text);
                            stations.Show();
                        }
                        else
                        {
                            MessageBox.Show("Bitte geben Sie eine valide Haltestelle oder Stadt ein!");
                        }
                        return;
                    }
                }


                string line = Linie.Text;
                //Variablen werden gesetzt
                Environment.SetEnvironmentVariable("PYTHONHOME", @"python");
                Runtime.PythonDLL = @"python\python38.dll";


                PythonEngine.Initialize();
                using (Py.GIL())
                {
                    //hier werden Variablen für die Python Fuktion gesetzt: arg1 und arg2
                    var PythonScript = Py.Import("vvscalc");
                    var arg1 = new PyString(station);
                    var arg2 = new PyString(line);
                    //Python Funktionen werden ausgeführt
                    res = PythonScript.InvokeMethod("get_departure", arg1, arg2);
                    res_all = PythonScript.InvokeMethod("get_departure_all", arg1);
                    res_delay_all = PythonScript.InvokeMethod("get_delay_all", arg1);
                    res_delay = PythonScript.InvokeMethod("get_delay", arg1, arg2);
                    //Der folgende Code wird nur ausgeführt, wenn EINE Linie oder EIN zug eingeben wird
                    if (line != "")
                    {
                        //Die Python Funktion gibt einen PyObject aus, welcher zu einem String konvertiert wird
                        //Dieser String wird formatiert und geteilt, sodass er zu einem Array wird
                        string result = res.ToString();
                        string result_delay = res_delay.ToString();
                        result = result.Substring(1, result.Length - 2);
                        result_delay = result_delay.Substring(1, result_delay.Length - 2);
                        string[] result_array = result.Split(',');
                        string[] result_delay_array = result_delay.Split(',');
                        //Die einzelnen Einträge werden formatiert
                        for (int i = 0; i < result_array.Length; i++)
                        {
                            result_array[i] = result_array[i].Substring(1, result_array[i].Length - 2);
                            if (i >= 1)
                            {
                                result_array[i] = result_array[i].Substring(1);
                            }
                        }
                        for (int i = 0; i < result_delay_array.Length; i++)
                        {
                            result_delay_array[i] = result_delay_array[i].Substring(1, result_delay_array[i].Length - 2);
                            if (i >= 1)
                            {
                                result_delay_array[i] = result_delay_array[i].Substring(1);
                            }
                        }
                        output.Enabled = true;
                        //Hier wird die Verspätung hinzugefügt
                        for (int i = 0; i < result_array.Length; i++)
                        {
                            if (result_delay_array[i] != "0")
                            {
                                output.Text += result_array[i] + " - " + result_delay_array[i] + " Minuten zu spät" + Environment.NewLine;
                            }
                            else
                            {
                                output.Text += result_array[i] + Environment.NewLine;
                            }
                        }
                    }
                    else
                    {
                        //Dieser Code wird nur ausgeführt, wenn KEINE Linie under KEIN Zug angegeben wurde
                        //Funktioniert sonst aber relativ Ähnlich zu dem obrigen
                        string result_all = res_all.ToString();
                        result_all = result_all.Substring(1, result_all.Length - 2);
                        string[] result_all_array = result_all.Split(',');

                        string result_delay_all = res_delay_all.ToString();
                        result_delay_all = result_delay_all.Substring(1, result_delay_all.Length - 2);
                        string[] result_delay_all_array = result_delay_all.Split(',');

                        for (int i = 0; i < result_all_array.Length; i++)
                        {
                            result_all_array[i] = result_all_array[i].Substring(1, result_all_array[i].Length - 2);
                            if (i >= 1)
                            {
                                result_all_array[i] = result_all_array[i].Substring(1);
                            }
                        }
                        for (int i = 0; i < result_delay_all_array.Length; i++)
                        {
                            result_delay_all_array[i] = result_delay_all_array[i].Substring(1, result_delay_all_array[i].Length - 2);
                            if (i >= 1)
                            {
                                result_delay_all_array[i] = result_delay_all_array[i].Substring(1);
                            }
                        }
                        output.Enabled = true;
                        for (int i = 0; i < result_all_array.Length; i++)
                        {
                            if (result_delay_all_array[i] != "0")
                            {
                                output.Text += result_all_array[i] + " - " + result_delay_all_array[i] + " Minuten zu spät" + Environment.NewLine;
                            }
                            else
                            {
                                output.Text += result_all_array[i] + Environment.NewLine;
                            }
                        }
                    }

                }
                PythonEngine.Shutdown();
            }
            catch (Exception f)
            {
                //Error Ausgabe
                MessageBox.Show("Error: Wahrscheinlich wird die Haltestelle nicht von dieser Linie heute angefahren | Error: " + f.Message);
                Console.WriteLine(f.Message);
                PythonEngine.Shutdown();
            }
        }

        private void other_CheckedChanged(object sender, EventArgs e)
        {
            //Die Eingabe für eine Andere Linie wird entsperrt oder gesperrt
            if (other.Checked)
            {
                other_field.ReadOnly = false;
                other_field.Enabled = true;
            }
            else
            {
                other_field.ReadOnly = true;
                other_field.Enabled = false;
                other_field.Text = "";
            }
        }

        //Wird beim erstmaligen Laden ausgeführt
        private void Form1_Load(object sender, EventArgs e)
        {
            //Die Tabelle (.csv Datei) mit den Stationsnamen wird in Listen geladen
            StreamReader stream1 = new StreamReader(@"vvs_stations_compressed.csv", Encoding.UTF8);

            while (!stream1.EndOfStream)
            {
                var line = stream1.ReadLine();
                var values = line.Split(';');

                listStation.Add(values[0]);
                listID.Add(values[1]);
                listCity.Add(values[2]);
            }
            stream1.Close();

            try
            {
                //Es wird Versucht die Favoriten aus der XML Datei zu laden
                FileStream stream = new FileStream(favPath, FileMode.Open, FileAccess.Read);
                XmlSerializer serializer = new XmlSerializer(typeof(fav));
                favourites = (fav)serializer.Deserialize(stream);
                stream.Close();
            }
            catch
            {
                favourites = new fav();
            }
            //Die Textboxen der Favoriten werden formatiert
            if (favourites.fav1Name == "")
            {
                fav1.Text = "Favorit 1";
            }
            else
            {
                fav1.Text = favourites.fav1Name;
            }
            if (favourites.fav2Name == "")
            {
                fav2.Text = "Favorit 2";
            }
            else
            {
                fav2.Text = favourites.fav2Name;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Das Fenster zum Speichern der Favoriten wird geöffnet
            FormFav favform = new FormFav(favourites, listStation, listID, listCity, this);
            favform.Show();
        }

        public void updateButton()
        {
            //Nach dem Stzen der Favoriten werden die Buttons geupdatet
            if (favourites.fav1Name == "")
            {
                fav1.Text = "Favorit 1";
            }
            else
            {
                fav1.Text = favourites.fav1Name;
            }
            if (favourites.fav2Name == "")
            {
                fav2.Text = "Favorit 2";
            }
            else
            {
                fav2.Text = favourites.fav2Name;
            }
        }

        private void general_serialize_Tick(object sender, EventArgs e)
        {
            //Die Favoriten werden gespeichert
            FileStream stream = new FileStream(favPath, FileMode.Create, FileAccess.Write);
            XmlSerializer serializer = new XmlSerializer(typeof(fav));
            serializer.Serialize(stream, favourites);
            stream.Close();

        }
    }
}
