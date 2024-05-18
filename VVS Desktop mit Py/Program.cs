using System;
using System.Threading.Tasks;
//using Python.Included;
using Python.Runtime;
using Python.Deployment;

namespace VVS_Desktop_mit_Py
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            /*await Installer.SetupPython();
            Installer.TryInstallPip();
            Installer.PipInstallModule("vvspy");
            //dynamic vvscalc = Py.Import("vvspy");
            Installer.PipInstallModule("pythonnet");
            Runtime.PythonDLL = "" + Installer.Source;
            PythonEngine.Initialize();
            //dynamic pythonnet = Py.Import("pythonnet");
            //Console.WriteLine("Spacy version: " + spacy.__version__);*/
            Application.Run(new Form1());
        }
    }
}