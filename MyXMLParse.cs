using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

using System.Xml;

namespace DotNetTools
{
    class MyXMLParse
    {

        public static void BookXPathParse()
        {
            XmlDocument xml = new XmlDocument();

            xml.Load(@"C:\Users\Rinjin Lama\source\repos\DotNetTools\DotNetTools\book.xml");

            XmlNamespaceManager nManager = new XmlNamespaceManager(xml.NameTable);
            nManager.AddNamespace("fc", "www.fourthcoffee.com");
            nManager.AddNamespace("aw", "http://www.adventure-works.com");

            string child4=xml.SelectSingleNode("//fc:Child3", nManager).InnerText;

            string attr = xml.SelectSingleNode("//aw:DifferentChild", nManager).Attributes["mycontent"].Value;

            Console.WriteLine(attr);

        }


        public static void BookXDocumentParse() {

            XDocument xml = XDocument.Load(@"C:\Users\Rinjin Lama\source\repos\DotNetTools\DotNetTools\book.xml");

            XNamespace nFC = "www.fourthcoffee.com";
            XNamespace nAW = "http://www.adventure-works.com";

            IEnumerable<XElement> xElements= xml.Descendants(nAW + "DifferentChild");

            foreach (XElement element in xElements) {
                Console.WriteLine(element.Attribute("mycontent").Value) ;
            
            }
        
        }




    }
}
