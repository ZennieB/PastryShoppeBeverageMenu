using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;

namespace DataLibrary.BusinessLogic
{
    public class BeverageProcessor
    {

        public static int CreateBeverage(int beverageId, string name, double cost, string size, string description, string createdby, bool specialdrink)
        {
            BeverageModel data = new BeverageModel
            {
                DrinkId = beverageId,
                Name = name,
                Cost = cost,
                CreatedBy = createdby,
                Description = description,
                Size = size,
                SpecialDrink = specialdrink
            };

            return XmlDataAccess.SaveData(data);
            
        }

        public static int UpdateBeverage(int beverageId, string name, double cost, string size, string description, string createdby, bool specialdrink)
        {
            BeverageModel data = new BeverageModel
            {
                DrinkId = beverageId,
                Name = name,
                Cost = cost,
                CreatedBy = createdby,
                Description = description,
                Size = size,
                SpecialDrink = specialdrink
            };

            return XmlDataAccess.UpdateData(data);

        }

        public static int DeleteBeverage(int drinkId)
        {
            return XmlDataAccess.DeleteData(drinkId);

        }

        public static List<BeverageModel> LoadBeverages()
        {
            return XmlDataAccess.GetData();
        }
    }
}
