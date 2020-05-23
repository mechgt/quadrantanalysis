// <copyright file="Plugin.cs" company="N/A">
// Copyright (c) 2008 All Right Reserved
// </copyright>
// <author>mechgt</author>
// <email>mechgt@gmail.com</email>
// <date>2008-12-23</date>
namespace QuadrantAnalysis
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    using QuadrantAnalysis.Settings;
    using QuadrantAnalysis.Util;
    using System.Text;
    using ZoneFiveSoftware.Common.Data.Fitness;
    using ZoneFiveSoftware.Common.Visuals.Fitness;

    /// <summary>
    /// Plugin class provides interface to the main application and logbook.
    /// </summary>
    class PluginMain : IPlugin
    {
        #region Private fields

        private static IApplication application;
        private static ILogbook logbook;

        #endregion

        #region Mechgt Licensing

        /// <summary>
        /// Plugin product Id as listed in license application
        /// </summary>
        internal static string ProductId
        {
            get
            {
                return "qa";
            }
        }

        /// <summary>
        /// Number of days in history that data will be displayed.
        /// This is the amount of data that will be displayed, not a number of days for a trial version.
        /// </summary>
        internal static int EvalDays
        {
            get { return 90; }
        }

        internal static string SupportEmail
        {
            get
            {
                return "support@mechgt.com";
            }
        }

        #endregion

        #region IPlugin Members

        /// <summary>
        /// Sets interface to SportTracks application
        /// </summary>
        public IApplication Application
        {
            set { application = value; }
        }

        /// <summary>
        /// Gets plugin GUID
        /// </summary>
        public Guid Id
        {
            // This GUID is currently being used to store/retreive settings data from logbook
            get { return GUIDs.PluginMain; }
        }

        /// <summary>
        /// Gets plugin Name
        /// </summary>
        public string Name
        {
            get { return "Quadrant Analysis"; }
        }

        /// <summary>
        /// Gets plugin Version
        /// </summary>
        public string Version
        {
            get { return GetType().Assembly.GetName().Version.ToString(3); }
        }

        public void ReadOptions(XmlDocument xmlDoc, XmlNamespaceManager nsmgr, XmlElement pluginNode)
        {
            try
            {
                // Deserialization
                GlobalSettings settings;
                XmlSerializer xs = new XmlSerializer(typeof(GlobalSettings));
                MemoryStream memoryStream = new MemoryStream(Utilities.StringToUTF8ByteArray(pluginNode.InnerText));

                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                object deserialize = xs.Deserialize(memoryStream);

                settings = (GlobalSettings)deserialize;
            }
            catch
            { }
        }

        public void WriteOptions(XmlDocument xmlDoc, XmlElement pluginNode)
        {
            // Serialization
            string xmlizedString;
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(GlobalSettings));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            xs.Serialize(xmlTextWriter, GlobalSettings.Instance);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            xmlizedString = Utilities.UTF8ByteArrayToString(memoryStream.ToArray());

            pluginNode.InnerText = xmlizedString;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Main SportTracks application
        /// </summary>
        /// <returns>Returns application interface</returns>
        public static IApplication GetApplication()
        {
            return application;
        }

        /// <summary>
        /// Currently loaded logbook
        /// </summary>
        /// <returns>Returns currently loaded logbook</returns>
        public static ILogbook GetLogbook()
        {
            logbook = GetApplication().Logbook;
            return logbook;
        }

        /// <summary>
        /// Plugin folder - plugins\data\{guid}\
        /// </summary>
        internal static string DataFolder
        {
            get
            {
                string path = Path.Combine(application.Configuration.CommonPluginsDataFolder, GUIDs.PluginMain.ToString("D"));

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        /// <summary>
        /// Plugin folder - plugins\installed\{guid}\
        /// </summary>
        internal static string PluginFolder
        {
            get
            {
                string path = Path.Combine(application.Configuration.CommonPluginsInstalledFolder, GUIDs.PluginMain.ToString("D"));

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        #endregion
    }
}
