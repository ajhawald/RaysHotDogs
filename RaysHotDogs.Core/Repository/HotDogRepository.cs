using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core.Model;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>()
        {
            new HotDogGroup()
            {
                HotDogeGroupId = 1, Title = "Meat Lovers", ImagePath = "", HotDogs = new List<HotDog>
                {
                   new HotDog()
                   {
                       HotDogId = 1,
                       Name = "Regular Hot Dog",
                       ShortDescription = "The best there is on this planet",
                       Description = "Manchego smelly danish fontina. Total awesome.",
                       ImagePath = "",
                       PrepTime = 10,
                       Available = true,
                       Ingredients = new List<string>(){"Regular bun", "Weiner", "Mustard", "Saur Kraut", "Onions", "Relish"},
                       Price = 8,
                       IsFavorite = true },

                   new HotDog()
                   {
                       HotDogId = 2,
                       Name = "Meat Lovers Hot Dog",
                       ShortDescription = "The best meaty pleasure there is on this planet",
                       Description = "Tons of meat for the serious meat lover, plus the rest",
                       ImagePath = "",
                       PrepTime = 10,
                       Available = true,
                       Ingredients = new List<string>(){"Regular bun", "Weiner", "Mustard", "Saur Kraut", "Onions", "Relish"},
                       Price = 8,
                       IsFavorite = true },
                   new HotDog()
                   {
                       HotDogId = 1,
                       Name = "Double Hot Dog",
                       ShortDescription = "Two weiners!",
                       Description = "Two weiners makes this hotdog insane. Check it out!",
                       ImagePath = "",
                       PrepTime = 10,
                       Available = true,
                       Ingredients = new List<string>(){"Regular bun", "Weiner", "Mustard", "Saur Kraut", "Onions", "Relish"},
                       Price = 8,
                       IsFavorite = true }
                }






            },
            new HotDogGroup()
            {
                HotDogeGroupId = 2, Title = "Veggie Lovers", ImagePath = "", HotDogs = new List<HotDog>
                {
                   new HotDog()
                   {
                       HotDogId = 1,
                       Name = "Regular Veggie Dog",
                       ShortDescription = "The best veggie there is on this planet",
                       Description = "Manchego smelly danish fontina. Total awesome and veggie.",
                       ImagePath = "",
                       PrepTime = 10,
                       Available = true,
                       Ingredients = new List<string>(){"Regular bun", "Veggie Weiner", "Mustard", "Saur Kraut", "Onions", "Relish"},
                       Price = 8,
                       IsFavorite = true },

                   new HotDog()
                   {
                       HotDogId = 2,
                       Name = "Fish Dog",
                       ShortDescription = "The best fishy pleasure there is on this planet",
                       Description = "Tons of meat for the serious fish lover, plus the rest",
                       ImagePath = "",
                       PrepTime = 10,
                       Available = true,
                       Ingredients = new List<string>(){"Regular bun", "Fish Weiner", "Tarter Sauce", "Saur Kraut", "Onions", "Relish"},
                       Price = 8,
                       IsFavorite = true },
                   new HotDog()
                   {
                       HotDogId = 1,
                       Name = "Double Veggie Dog",
                       ShortDescription = "Two veggie weiners!",
                       Description = "Two veggie weiners makes this hotdog insane. Check it out!",
                       ImagePath = "",
                       PrepTime = 10,
                       Available = true,
                       Ingredients = new List<string>(){"Regular bun", "Fish Weiner", "Tartar Sauce", "Saur Kraut", "Onions", "Relish"},
                       Price = 8,
                       IsFavorite = true }
                }






            }
        }; 

        public List<HotDog> GetAllHotDogs()
        {
            IEnumerable<HotDog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                select hotDog;
            return hotDogs.ToList<HotDog>();
        }

        public HotDog GetHotDogById(int hotDogId)
        {
            IEnumerable<HotDog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                where hotDog.HotDogId == hotDogId
                select hotDog;
            return hotDogs.FirstOrDefault();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogGroups;
        }

        public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
        {
            var group = hotDogGroups.Where(h => h.HotDogeGroupId == hotDogGroupId).FirstOrDefault();
            if (group != null)
            {
                return group.HotDogs;
            }
            return null;
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            IEnumerable<HotDog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                where hotDog.IsFavorite = true
                select hotDog;
            return hotDogs.ToList<HotDog>();
        }


    }
}