using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Xml.Serialization;

namespace DataLibrary.DataAccess
{
    public class XmlDataAccess
    {
        public static string DirectoryOfFile = Path.Combine(Environment.GetEnvironmentVariable("HOME_EXPANDED"), "XmlDocuments");
        public static string FullPathOfFile = Path.Combine(DirectoryOfFile, "PastryDrinks.xml");

        static List<BeverageModel> allBeverages = new List<BeverageModel>();

        public static int SaveData(BeverageModel data)
        {
            allBeverages.Add(data);
            SerializeToXML(allBeverages, FullPathOfFile);
            return 1;
        }

        public static int UpdateData(BeverageModel data)
        {
            var toUpdate = allBeverages.FirstOrDefault(x => x.DrinkId == data.DrinkId);

            if (toUpdate != null)
                DeleteData(data.DrinkId);

            return SaveData(data);
        }

        public static int DeleteData(int id)
        {
            var index = allBeverages.FindIndex(x => x.DrinkId == id);
            if (index > 0)
            {
                allBeverages.RemoveAt(index);
                SerializeToXML(allBeverages, FullPathOfFile);
                return 1;
            }
            return 0;
        }

        public static List<BeverageModel> GetData()
        {
            if (!File.Exists(FullPathOfFile))
            {
                SaveData(new BeverageModel()
                {
                    Cost = 19.99,
                    CreatedBy = "Lily",
                    Description = "Some lovely matcha to enjoy!",
                    DrinkId = 1,
                    Name = "Matcha Tea",
                    Size = "Large",
                    SpecialDrink = false
                });
            }
            allBeverages = DeserializeFromXML<BeverageModel>(FullPathOfFile);
            return allBeverages;
        }

        public static BeverageModel GetBlogPostData(int id)
        {
            return allBeverages.FirstOrDefault(x => x.DrinkId == id);
        }

        public static List<T> DeserializeFromXML<T>(string pathToDeserializeFrom)
        {
            using (StreamReader stringReader = new StreamReader(pathToDeserializeFrom))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                return (List<T>)serializer.Deserialize(stringReader);
            }
        }

        public static string SerializeToXML<T>(List<T> obj, string pathToSerialize)
        {
            if (!Directory.Exists(DirectoryOfFile))
                Directory.CreateDirectory(DirectoryOfFile);

            using (StreamWriter stringWriter = new StreamWriter(pathToSerialize))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }

    }
}
