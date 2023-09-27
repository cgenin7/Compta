using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ComptaCommun
{
    public class LocalSettings
    {
        #region public static methods 

        static public void LoadLocalSettings()
        {
            TextReader configFile = null;
            DatabaseName = DateTime.Now.Year.ToString();

            try
            {
                configFile = File.OpenText(ClassTools.GetConfigDir() + CONFIG_FILE_NAME);
            }
            catch (Exception)
            {
                configFile = null;
            }

            if (configFile != null)
            {
                try
                {
                    string data = configFile.ReadLine();

                    if (data != null)
                    {
                        string[] infos = data.Split('=');

                        if (infos.Length == 2)
                        {
                            if (infos[0] == DATABASE_NAME)
                            {
                                DatabaseName = infos[1];
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
                configFile.Close();
            }
        }

        static public void SaveLocalSettings()
        {
            TextWriter configFile = null;
            string configDir = ClassTools.GetConfigDir();

            try
            {
                if (!Directory.Exists(configDir))
                    Directory.CreateDirectory(configDir);
                configFile = File.CreateText(configDir + CONFIG_FILE_NAME);
            }
            catch (Exception)
            {
                configFile = null;
            }
            if (configFile != null)
            {
                configFile.WriteLine(DATABASE_NAME + "=" + DatabaseName);
                configFile.Close();
            }
        }

        #endregion
        
        #region public static members

        static public string UIDirectory
        {
            get
            {
                return m_UIDirectory;
            }
            set
            {
                m_UIDirectory = value;
            }
        }
        
        public static string DatabaseName { get; set; }

        public static int BudgetYear 
        {
            get 
            {
                int budgetYear;
                if (DatabaseName.Length >= 4)
                    if (int.TryParse(DatabaseName.Substring(0, 4), out budgetYear))
                        return budgetYear;
                return DateTime.Now.Year;
            }
        }

        public static string DatabaseBackupPath
        {
            get { return ClassTools.GetConfigDir() + DatabaseName + "Backup.mdb"; }
        }

        public static string DatabasePath 
        {
            get { return ClassTools.GetConfigDir() + DatabaseName + ".mdb"; }
            set { DatabasePath = value; }
        }

        public static string PlacementsPath
        {
            get { return ClassTools.GetConfigDir() + "Placements.mdb"; }
        }
        #endregion

        #region private members

        private static string m_UIDirectory;
        
        private const string CONFIG_FILE_NAME = "LocalSettings.txt";
        private const string DATABASE_NAME = "DatabaseName";
        private const string VERSION = "Version";

        #endregion
    }
}
