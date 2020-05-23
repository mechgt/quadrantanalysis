namespace QuadrantAnalysis.Settings
{
    using System;
    using System.Xml.Serialization;
    using QuadrantAnalysis.UI;
    using QuadrantAnalysis.UI.DetailPage;
    using QuadrantAnalysis.Data;
    using System.Collections.Generic;
    using ZoneFiveSoftware.Common.Visuals;

    /// <summary>
    /// Global settings
    /// </summary>
    [XmlRootAttribute(ElementName = "QuadrantAnalysis", IsNullable = false)]
    public class GlobalSettings
    {
        private static float crankLength = 175;
        private static int cadence = 80;
        private static int power = 250;
        private static int powerBand = 10;
        private static GlobalSettings instance;
        private static List<string> treeColumns = new List<string>();

        public float CrankLength
        {
            get { return crankLength; }
            set { crankLength = value; }
        }

        public int Cadence
        {
            get { return cadence; }
            set { cadence = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int PowerBand
        {
            get { return powerBand; }
            set { powerBand = value; }
        }

        public QuadrantAnalysisDetail.ChartType ChartType
        {
            get;
            set;
        }

        public List<string> TreeColumns
        {
            get { return treeColumns; }
            set { treeColumns = value; }
        }

        internal static GlobalSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalSettings();
                }

                return instance;
            }
        }
    }
}
