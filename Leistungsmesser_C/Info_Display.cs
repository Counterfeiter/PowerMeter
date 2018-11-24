using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Leistungsmesser_C
{
    partial class Info_Display : Form
    {
        public Info_Display()
        {
            InitializeComponent();

        }

        #region Assemblyattributaccessoren

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void AboutBox1_Load(object sender, EventArgs e)
        {
            textBoxDescription.Text = "Valid for my (Sebastian Förster) own designed ATXMega32A4U Software and computer software \"Power Meter\"\r\n\r\n" +
                                        "1. Copying and publishing for personal use is explicitely allowed,\r\n" +
                                        "   in case my copyright is kept und no parts of the software have been modified.\r\n" +
                                        "2. The lucrative selling of construction kits/ finishes modules of my software is forbidden.\r\n" +
                                        "3. It`s strictly not allowed to use my software in a commercial way without my agreement\r\n" +
                                        "   Apart from the arrangement, demo and exhibited vehicles are belonging to car hifi traders.\r\n" +
                                        "I'm not liable for any damages caused by my software or my construction kits/ finishes modules.\r\n\r\n" +
                                        "Gültig für die von mir (Sebastian Förster) erstellte ATXMega32A4U Controller Software und die PC Software \"Power Meter\"\r\n\r\n" +
                                        "1. Das Kopieren und Verbreiten für den Privatgebrauch ist ausdrücklich erlaubt,\r\n" +
                                        "   sofern mein Copyright gewahrt wird und keine Softwarebestandteile modifiziert wurden.\r\n" +
                                        "2. Das gewinnbringende Verkaufen von Bausätzen/Fertigmodulen mit der von mir erstellten Software ist untersagt.\r\n" +
                                        "3. Ohne meine Zustimmung ist es ausdrücklich verboten die genannte Software kommerziell einzusetzen.\r\n" +
                                        "   Ausgenommen von dieser Regelung sind Demo und Vorführ-Fahrzeuge von Car Hifi Händlern.\r\n" + 
                                        "Ich hafte nicht für Schäden die durch meine Software oder durch meine Bausätzen/Fertigmodule entstehen.\r\n";

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelVersion_Click(object sender, EventArgs e)
        {

        }

    }
}
