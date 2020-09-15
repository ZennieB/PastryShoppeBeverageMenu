using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Collections.Generic;

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

            int isSpecial = data.SpecialDrink ? 1 : 0;
            string sql = @"insert into dbo.Beverages (DrinkId, Name, Cost, Size, Description, CreatedBy, SpecialDrink)
                            values (@DrinkId, @Name, @Cost, @Size, @Description, @CreatedBy, " + $"{isSpecial}" + ");";
            return SqlDataAccess.SaveData(sql, data);
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

            int isSpecial = data.SpecialDrink ? 1 : 0;
            string sql = @"update dbo.Beverages 
                           set Name = @Name, Cost = @Cost, Size = @Size, Description = @Description, CreatedBy = @CreatedBy, SpecialDrink = 1 
                           where DrinkId = @DrinkId;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteBeverage(int drinkId)
        {
            string sql = "DELETE FROM dbo.Beverages WHERE DrinkId = @drinkId";

            return SqlDataAccess.SaveData(sql, new { drinkId = drinkId});

        }

        public static List<BeverageModel> LoadBeverages()
        {
            string sql = "select Id, DrinkId, Name, Cost, Size, Description, CreatedBy, SpecialDrink from dbo.Beverages;";

            return SqlDataAccess.LoadData<BeverageModel>(sql);
        }
    }
}
