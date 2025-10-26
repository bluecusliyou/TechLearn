using System.Xml;

namespace MyXML
{
    public class XmlConfigHelper
    {
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string xmlFilePath,string key)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode valueNode = xmlDoc.SelectSingleNode($"/Config/Item[@Key='{key}']");
            if (valueNode != null)
            {
                return valueNode.InnerText;
            }
            return null;
        }

        /// <summary>
        /// 设置值，没有新增
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetValue(string xmlFilePath, string key, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode valueNode = xmlDoc.SelectSingleNode($"/Config/Item[@Key='{key}']");
            if (valueNode != null)
            {
                valueNode.InnerText = value;
            }
            else
            {
                XmlElement newElement = xmlDoc.CreateElement("Item");
                newElement.SetAttribute("Key", key);
                newElement.InnerText = value;
                xmlDoc.SelectSingleNode("/Config").AppendChild(newElement);
            }

            xmlDoc.Save(xmlFilePath);
        }

        /// <summary>
        /// 判断是否有key
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool HasKey(string xmlFilePath, string key)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            XmlNode valueNode = xmlDoc.SelectSingleNode($"/Config/Item[@Key='{key}']");
            return valueNode != null;
        }

        /// <summary>
        /// 删除key
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <param name="key"></param>
        public static void DeleteKey(string xmlFilePath, string key)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode valueNode = xmlDoc.SelectSingleNode($"/Config/Item[@Key='{key}']");
            if (valueNode != null)
            {
                xmlDoc.SelectSingleNode("/Config").RemoveChild(valueNode);
            }

            xmlDoc.Save(xmlFilePath);
        }
    }
}
