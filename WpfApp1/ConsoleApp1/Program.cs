﻿using System;
using System.IO;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CreateXml();
        }
        public static void CreateXml()
        {
            var doc = new XmlDocument();

            using (FileStream stream = File.OpenRead("books.xml"))
            {
                doc.Load(stream);
            }


            //create a new 'book' element
            XmlElement newBook = doc.CreateElement("book");
            //set some attributes
            newBook.SetAttribute("genre", "Mystery");
            newBook.SetAttribute("publicationdate", "2001");
            newBook.SetAttribute("ISBN", "123456789");
            //create a new 'title' element
            XmlElement newTitle = doc.CreateElement("title");
            newTitle.InnerText = "Case of the Missing Cookie";
            newBook.AppendChild(newTitle);
            //create new author element
            XmlElement newAuthor = doc.CreateElement("author");
            newBook.AppendChild(newAuthor);
            //create new name element
            XmlElement newName = doc.CreateElement("name");
            newName.InnerText = "Cookie Monster";
            newAuthor.AppendChild(newName);
            //create new price element
            XmlElement newPrice = doc.CreateElement("price");
            newPrice.InnerText = "9.95";
            newBook.AppendChild(newPrice);

            //add to the current document
            doc.DocumentElement.AppendChild(newBook);

            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineChars = Environment.NewLine
            };
            //write out the doc to disk
            using (StreamWriter streamWriter = File.CreateText("newbook.xml"))
            using (XmlWriter writer = XmlWriter.Create(streamWriter, settings))
            {
                doc.WriteContentTo(writer);
            }

            XmlNodeList nodeLst = doc.GetElementsByTagName("title");
            foreach (XmlNode node in nodeLst)
            {
                Console.WriteLine(node.OuterXml);
            }
        }
    }
}
