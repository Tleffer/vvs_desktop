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

        //Dictionary<string, string> stations = new Dictionary<string, string>();
        List<string> listStation = new List<string>();
        List<string> listID = new List<string>();
        List<string> listCity = new List<string>();
        PyObject res;
        PyObject resd;
        PyObject resdg;
        PyObject resg;
        fav favourites;
        string favPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "favourites.xml");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                output.Text = "";
                output.Enabled = false;
                string station = "";
                //17803 = Schlierbach Kirche
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
                    if (listStation.Contains(other_field.Text))
                    {
                        station = listID[listStation.IndexOf(other_field.Text)];
                    }
                    else
                    {
                        if (listCity.Contains(other_field.Text))
                        {
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

                //Runtime.PythonDLL = @"C:\Users\PostT\AppData\Local\Programs\Python\Python310\python310.dll";
                Runtime.PythonDLL = @"python310.dll";
                PythonEngine.Initialize();
                using (Py.GIL())
                {
                    var PythonScript = Py.Import("vvscalc");
                    //5006118 Stuttgart HBF (tief)
                    //17803 Schlierbach Kirche
                    var arg1 = new PyString(station);
                    var arg2 = new PyString(line);
                    res = PythonScript.InvokeMethod("get_departure", arg1, arg2);
                    resg = PythonScript.InvokeMethod("get_departure_all", arg1);
                    resdg = PythonScript.InvokeMethod("get_delay_all", arg1);
                    resd = PythonScript.InvokeMethod("get_delay", arg1, arg2);
                    if (line != "")
                    {
                        string result = res.ToString();
                        string resultd = resd.ToString();
                        //MessageBox.Show(result);
                        //MessageBox.Show(resultd);
                        result = result.Substring(1, result.Length - 2);
                        resultd = resultd.Substring(1, resultd.Length - 2);
                        string[] results = result.Split(',');
                        string[] resultds = resultd.Split(',');
                        for (int i = 0; i < results.Length; i++)
                        {
                            results[i] = results[i].Substring(1, results[i].Length - 2);
                            if (i >= 1)
                            {
                                results[i] = results[i].Substring(1);
                            }
                        }
                        for (int i = 0; i < resultds.Length; i++)
                        {
                            resultds[i] = resultds[i].Substring(1, resultds[i].Length - 2);
                            if (i >= 1)
                            {
                                resultds[i] = resultds[i].Substring(1);
                            }
                        }
                        //MessageBox.Show("" + results[1]);
                        //MessageBox.Show("" + resultds[1]);
                        //PythonEngine.Shutdown();
                        output.Enabled = true;
                        for (int i = 0; i < results.Length; i++)
                        {
                            if (resultds[i] != "0")
                            {
                                output.Text += results[i] + " - " + resultds[i] + " Minuten zu spät" + Environment.NewLine;
                            }
                            else
                            {
                                output.Text += results[i] + Environment.NewLine;
                            }
                        }
                    }
                    else
                    {
                        string resultg = resg.ToString();
                        resultg = resultg.Substring(1, resultg.Length - 2);
                        string[] resultgs = resultg.Split(',');

                        string resultdg = resdg.ToString();
                        resultdg = resultdg.Substring(1, resultdg.Length - 2);
                        string[] resultdgs = resultdg.Split(',');

                        for (int i = 0; i < resultgs.Length; i++)
                        {
                            resultgs[i] = resultgs[i].Substring(1, resultgs[i].Length - 2);
                            if (i >= 1)
                            {
                                resultgs[i] = resultgs[i].Substring(1);
                            }
                        }
                        for (int i = 0; i < resultdgs.Length; i++)
                        {
                            resultdgs[i] = resultdgs[i].Substring(1, resultdgs[i].Length - 2);
                            if (i >= 1)
                            {
                                resultdgs[i] = resultdgs[i].Substring(1);
                            }
                        }
                        //PythonEngine.Shutdown();
                        output.Enabled = true;
                        for (int i = 0; i < resultgs.Length; i++)
                        {
                            if (resultdgs[i] != "0")
                            {
                                output.Text += resultgs[i] + " - " + resultdgs[i] + " Minuten zu spät" + Environment.NewLine;
                            }
                            else
                            {
                                output.Text += resultgs[i] + Environment.NewLine;
                            }
                        }
                    }

                }
                PythonEngine.Shutdown();
            }
            catch (Exception f)
            {
                MessageBox.Show("Error: Wahrscheinlich wird die Haltestelle nicht von dieser Linie heute angefahren");
                Console.WriteLine(f.Message);
                PythonEngine.Shutdown();
            }
        }

        private void other_CheckedChanged(object sender, EventArgs e)
        {
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

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader stream1 = new StreamReader(@"vvs_stations_compressed.csv", Encoding.UTF8);

            while (!stream1.EndOfStream)
            {
                var line = stream1.ReadLine();
                var values = line.Split(';');

                listStation.Add(values[0]);
                listID.Add(values[1]);
                listCity.Add(values[2]);

                //stations.Add(values[0], values[1]);
            }
            stream1.Close();

            try
            {
                FileStream stream = new FileStream(favPath, FileMode.Open, FileAccess.Read);
                XmlSerializer serializer = new XmlSerializer(typeof(fav));
                favourites = (fav)serializer.Deserialize(stream);
                stream.Close();
            }
            catch
            {
                favourites = new fav();
            }
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
            FormFav favform = new FormFav(favourites, listStation, listID, listCity, this);
            favform.Show();
        }

        public void updateButton()
        {
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
            FileStream stream = new FileStream(favPath, FileMode.Create, FileAccess.Write);
            XmlSerializer serializer = new XmlSerializer(typeof(fav));
            serializer.Serialize(stream, favourites);
            stream.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
