using Dictionchy.Application.Commands;
using Dictionchy.Infrastructure;
using System.Reflection;

namespace Dictionchy
{
    internal class Pet
    {
        private DateTime lastEatTime = DateTime.Now;
        private DateTime lastCleanTime = DateTime.Now;
        private DateTime lastSleepTime = DateTime.Now;

        private int satiety = 100;
        private int cleanness = 100;
        private int sleepiness = 100;

        public string Name { get; }
        
        public int Satiety 
        { 
            get
            { 
                satiety -= (int)(DateTime.Now - lastEatTime).TotalHours * 5;
                return satiety;
            }
            set
            {
                lastEatTime = DateTime.Now;
                satiety = value < 0 ? 0 : value;
            }
        }

        public int Cleanness
        {
            get
            {
                cleanness -= (int)(DateTime.Now - lastCleanTime).TotalHours * 5;
                return cleanness;
            }
            set
            {
                lastCleanTime = DateTime.Now;
                cleanness = value < 0 ? 0 : value;
            }
        }

        public int Sleepiness
        {
            get
            {
                sleepiness -= (int)(DateTime.Now - lastSleepTime).TotalHours * 5;
                return sleepiness;
            }
            set
            {
                lastSleepTime = DateTime.Now;
                sleepiness = value < 0 ? 0 : value;
            }
        }

        public static Pet GetOrCreatePet(string name, string id)
        {
            var relativePath = @"..\Resources"; //TODO: в случае перемещения файла тут возникнет ошибка, надо бы сделать более гибким
            var folder = Path.GetFullPath(relativePath);
            var pet = ClassLoader.Load<Pet>(folder, id).Result;
            if (pet is null)
            {
                return new Pet(name);
            }
            return pet;
        }

        private Pet(string name) : this(name, 100, 100, 100) { }

        public Pet(string name, int satiety, int cleanness, int sleepiness) 
        { 
            Name = name;
            Satiety = satiety;
            Cleanness = cleanness;
            Sleepiness = sleepiness;
        }

        public override string ToString()
        {
            return $"Pet<Name: {Name}, Satiety: {Satiety}, Cleanness: {Cleanness}, Sleepiness: {Sleepiness}>";
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public void Eat() => Satiety = 100;
        
        public void Clean() => Cleanness = 100;

        public void Sleep(int hours) => Sleepiness = 100;

        public void Speak()
        {
            throw new NotImplementedException();
        }
    }
}
