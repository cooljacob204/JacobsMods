using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Library;
using System.Xml;

namespace JacobsTweaks
{
    public static class Settings
    {
        public static String LoadSetting(String name)
        {
            XmlDocument settings = new XmlDocument();
            settings.Load(BasePath.Name + "Modules/JacobsTweaks/ModuleData/config.xml");

            XmlNode root = settings.FirstChild;

            return root.SelectSingleNode(name).InnerText;
        }
    }
}
