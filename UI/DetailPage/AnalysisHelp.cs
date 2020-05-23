using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuadrantAnalysis.UI.DetailPage
{
    public partial class AnalysisHelp : Form
    {
        private string conceptFile = "Concepts.rtf";

        public AnalysisHelp()
        {
            InitializeComponent();

            this.Icon = Util.Utilities.GetIcon(Resources.Images.helpball);
            LoadFile(Path.Combine(PluginMain.PluginFolder,conceptFile));
        }

        public void LoadFile(string filename)
        {
            richTextMain.LoadFile(filename);
        }
    }
}
