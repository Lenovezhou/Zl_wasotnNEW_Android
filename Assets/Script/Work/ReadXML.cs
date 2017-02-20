using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;
using System.Collections;

public class ReadXML
{
    public static List<Module> ReadInfo(string path, string Name)
    {
        List<Module> Info = new List<Module>();
        System.IO.StringReader stringReader = new System.IO.StringReader(path);
        stringReader.Read(); // 跳过 BOM 
        System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stringReader);
        XmlDocument myXML = new XmlDocument();
        myXML.LoadXml(stringReader.ReadToEnd());
        XmlElement Xmlroot = myXML.DocumentElement;
        UImanager._instance.teliphonenumber = Xmlroot.Attributes["Teliphonenumber"].Value;
        Debug.Log(Xmlroot[Name].ChildNodes.Count);

        foreach (XmlNode item in Xmlroot[Name].ChildNodes)
        {
            Module info = new Module();
       
            //info.Englishname = item.Attributes["englishname"].Value; 
            info.Name = item.Attributes["name"].Value;
            if (item.Attributes["ismodle"] != null)
                info.IsModle = item.Attributes["ismodle"].Value == "0" ? true : false;
            if (item.Attributes["modle"] != null)
                info.URL = item.Attributes["modle"].Value;

            info.SubList = new List<Sub>();
            foreach (XmlNode item1 in item.ChildNodes)
            {
                Sub sub = new Sub();
                sub.Name = item1.Attributes["name"].Value;
                if (item1.Attributes["ismodle"]!=null)
                    sub.IsModle = item1.Attributes["ismodle"].Value == "0" ? true : false;
                if (item1.Attributes["modle"] != null)
                    sub.URL = item1.Attributes["modle"].Value;
                //sub.ENglishname = item1.Attributes["englishname"].Value;
                info.SubList.Add(sub);
                sub.ProductList = new List<Product>();
                foreach (XmlNode item2 in item1.ChildNodes)
                {
                    Product prod = new Product();
                    prod.Name = item2.Attributes["name"].Value;
                    prod.ModleURL = item2.Attributes["modle"].Value;
                    prod.IsModle = item2.Attributes["ismodle"].Value == "0" ? true : false;
                    prod.TextureURL = item2.Attributes["texture"].Value;
                    prod.Description =item2.Attributes["description"].Value;
                    sub.ProductList.Add(prod);
                }
            }
            Info.Add(info);
        }
        return Info;
    }
}
