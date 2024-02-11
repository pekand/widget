using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Timer
{
    public class Settings
    {
        public string version = null;

        public bool paused = false;

        public long tick = 0;
        public long delta = 0;

        public int left = 0;
        public int top = 0;
        public int width = 230;
        public int height = 100;

        public int windowState = 0;

        public string type = "sec";

        public string settingsFileDirectory = null;
        public string settingsFilePath = null;

        public Settings(int id)
        {
            settingsFileDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Timer");
            settingsFilePath = Path.Combine(settingsFileDirectory, "settings."+id.ToString()+".xml");
        }

        public void Save() 
        {
            if (!Directory.Exists(settingsFileDirectory)) {
                Directory.CreateDirectory(settingsFileDirectory);
            }

            XmlDocument doc = new XmlDocument();

            XmlElement root = doc.CreateElement("root");
            root.SetAttribute("version", "1.0.0");
            doc.AppendChild(root);

            XmlElement tick = doc.CreateElement("tick");
            root.AppendChild(tick);
            tick.InnerText = this.tick.ToString();

            XmlElement delta = doc.CreateElement("delta");
            root.AppendChild(delta);
            delta.InnerText = this.delta.ToString();

            XmlElement paused = doc.CreateElement("paused");
            root.AppendChild(paused);
            paused.InnerText = this.paused ? "1" : "0";

            XmlElement type = doc.CreateElement("type");
            root.AppendChild(type);
            type.InnerText = this.type;

            XmlElement window = doc.CreateElement("window");
            root.AppendChild(window);

            XmlElement left = doc.CreateElement("left");
            window.AppendChild(left);
            left.InnerText = this.left.ToString();

            XmlElement top = doc.CreateElement("top");
            window.AppendChild(top);
            top.InnerText = this.top.ToString();

            XmlElement width = doc.CreateElement("width");
            window.AppendChild(width);
            width.InnerText = this.width.ToString();

            XmlElement height = doc.CreateElement("height");
            window.AppendChild(height);
            height.InnerText = this.height.ToString();


            doc.Save(settingsFilePath);
        }

        public void Load()
        {
            if (!File.Exists(settingsFilePath)) {
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(settingsFilePath);

            XmlElement root = doc.DocumentElement;


            if (root.Attributes != null)
            {
                foreach (XmlAttribute attribute in root.Attributes)
                {
                    if (attribute.Name == "version") {
                        this.version = attribute.Value;
                    }
                }
            }

            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == "tick")
                {
                    this.tick = long.Parse(node.InnerText);
                }

                if (node.Name == "delta")
                {
                    this.delta = long.Parse(node.InnerText);
                }

                if (node.Name == "paused")
                {
                    this.paused = (node.InnerText == "1");
                }

                if (node.Name == "type")
                {
                    this.type = node.InnerText;
                }

                if (node.Name == "window")
                {
                    foreach (XmlNode windowNode in node.ChildNodes)
                    {
                        if (windowNode.Name == "left")
                        {
                            this.left = int.Parse(windowNode.InnerText);
                        }

                        if (windowNode.Name == "top")
                        {
                            this.top = int.Parse(windowNode.InnerText);
                        }

                        if (windowNode.Name == "width")
                        {
                            this.width = int.Parse(windowNode.InnerText);
                        }

                        if (windowNode.Name == "height")
                        {
                            this.height = int.Parse(windowNode.InnerText);
                        }

                    }
                }
            }
        }
    }
}
