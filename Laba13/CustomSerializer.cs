﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace Laba13
{
    class CustomSerializer
    {
        public static void Serialize(string filename, BusRoot name)
        {
            string[] format = filename.Split('.');
            switch (format[1])
            {
                case "bin":
                    {
                        BinaryFormatter binarForm = new BinaryFormatter();
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            binarForm.Serialize(fs, name);
                            Console.WriteLine($"Object {typeof(BusRoot)} serialized to {filename}");
                        }
                        break;
                    }
                case "json":
                    {
                        DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(BusRoot));
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            jsonForm.WriteObject(fs, name);
                            Console.WriteLine($"Object {typeof(BusRoot)} serialized to {filename}");

                        }
                        break;
                    }
                case "xml":
                    {
                        XmlSerializer xmlSer = new XmlSerializer(typeof(BusRoot));
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            xmlSer.Serialize(fs, name);
                            Console.WriteLine($"Object {typeof(BusRoot)} serialized to {filename}");

                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong format");
                        break;
                    }
            }
        }

        public static void Deserialize(string fname)
        {
            string[] format = fname.Split('.');
            switch (format[1])
            {
                case "bin":
                    {
                        BinaryFormatter binarForm = new BinaryFormatter();
                        using (FileStream fr = new FileStream(fname, FileMode.Open))
                        {
                            BusRoot newPl = (BusRoot)binarForm.Deserialize(fr);
                            Console.WriteLine("Deserialized from file: " + fname + "\n" + newPl.ToString());
                        }
                        break;
                    }
                case "json":
                    {
                        DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(BusRoot));
                        using (FileStream fr = new FileStream(fname, FileMode.OpenOrCreate))
                        {
                            BusRoot newPl = (BusRoot)jsonForm.ReadObject(fr);
                            Console.WriteLine("Deserialized from file: " + fname + "\n" + newPl.ToString());
                        }
                        break;
                    }
                case "xml":
                    {
                        XmlSerializer xmlSer = new XmlSerializer(typeof(BusRoot));
                        using (FileStream fr = new FileStream(fname, FileMode.OpenOrCreate))
                        {
                            BusRoot newPl = (BusRoot)xmlSer.Deserialize(fr);
                            Console.WriteLine("Deserialized from file: " + fname + "\n" + newPl.ToString());
                        }
                        break;
                    }

            }

        }
    }
}
