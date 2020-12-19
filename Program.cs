using System;
using System.Xml.Linq;

namespace DotNetTools
{
    class Program
    {
        static void Main(string[] args)
        {

            //createXML();
            createXMLWithNameSpace();
            Console.ReadLine();

        }

        static void createXMLWithNameSpace() {

            XNamespace nAW = "http://www.adventure-works.com";
            XNamespace nFC = "www.fourthcoffee.com";

            XDocument xml = new XDocument(
                new XElement(nAW + "Root",
                     new XAttribute( XNamespace.Xmlns +"aw", "http://www.adventure-works.com"),
                     new XAttribute(XNamespace.Xmlns + "fc", "www.fourthcoffee.com"),
                        new XElement( nFC+"Child",
                            new XElement(nAW + "DifferentChild", "other content")
                        ),
                        new XElement(nAW + "Child2", "c2 content"),
                        new XElement(nFC + "Child3", "c3 content")
                    )
                );

            Console.WriteLine(xml);
            xml.Save(@".\DotNetTools\DotNetTools\book.xml");

        }



        static void createXML() {

            XDocument xml = new XDocument(
                new XComment("This is a comment"),
                new XProcessingInstruction("xml-stylesheet", "href='mystyle.css' title='Compact' type='text/css'"),
                new XElement("Pubs",
                                new XElement("Book",
                                    new XElement("Title", "Artifacts of Roman Civilization"),
                                    new XElement("Author", "Moreno, Jordao")
                                ),
                                new XElement("Book",
                                    new XElement("Title", "Midieval Tools and Implements"),
                                    new XElement("Author", "Gazit, Inbar")
                                )
                ));

            Console.WriteLine(xml);

            xml.Save(@".\DotNetTools\DotNetTools\book.xml");
        
        }

    

    }
}
