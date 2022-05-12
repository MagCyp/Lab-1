using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Lab_1
{
    public class Config
    {
        public bool IsNullProp()
        {
            return string.IsNullOrEmpty(Pira_Ob)
               && string.IsNullOrEmpty(Pira_SBich)
               && string.IsNullOrEmpty(Pira_SPovn)
              && string.IsNullOrEmpty(Cilindr_Ob)
              && string.IsNullOrEmpty(Cilindr_SBich)
              && string.IsNullOrEmpty(Cilindr_SPovn)
              && string.IsNullOrEmpty(Conus_Ob)
              && string.IsNullOrEmpty(Conus_SBich)
              && string.IsNullOrEmpty(Conus_SPovn);
        }
        public static Config GetConfig()
        {
            Config config = null;
            string filename = Global.Config;
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Config));
                    config = (Config)xml.Deserialize(fs);
                    fs.Close();
                }
            }
            else config = new Config();

            return config;
        }
        public void Save()
        {
            string filename = Global.Config;
            if (File.Exists(filename)) File.Delete(filename);
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Config));
                xml.Serialize(fs, this);
                fs.Close();
            }
        }

        public void Clear()
        {
            Pira_Ob = string.Empty;
            Pira_SBich = string.Empty;
            Pira_SPovn = string.Empty;
            Conus_Ob = string.Empty;
            Conus_SBich = string.Empty;
            Conus_SPovn = string.Empty;
            Cilindr_Ob = string.Empty;
            Cilindr_SBich = string.Empty;
            Cilindr_SPovn = string.Empty;
        }
        public string Pira_Ob { get; set; }

        public string Pira_SBich { get; set; }

        public string Pira_SPovn { get; set; }

        public string Conus_Ob { get; set; }

        public string Conus_SBich { get; set; }

        public string Conus_SPovn { get; set; }

        public string Cilindr_Ob { get; set; }

        public string Cilindr_SBich { get; set; }

        public string Cilindr_SPovn { get; set; }
    }
}
