using Dictionchy.Infrastructure;
using Telegram.Bot.Types;

namespace Dictionchy.Domain
{
    internal class Pet
    {
        private static IDatabaseProvider<Pet> _provider = new FileDB<Pet>(); //TODO: добавить зависимость в DI-контейнер
        public long OwnerId { get; }
        public string Name { get; }


        public DateTime LastEatTime { get; set; }
        public DateTime LastCleanTime { get; set; }
        public DateTime LastSleepTime { get; set; }

        public int Satiety => CalculateState(LastEatTime);
        public int Cleanness => CalculateState(LastCleanTime);
        public int Sleepiness => CalculateState(LastSleepTime);

        // ВРЕМЕННЫЙ МЕТОД, ПОТОМ ПЕРЕНЕСТИ
        public static string GetPath()
        {
            var relativePath = @"..\Resources";
            Directory.CreateDirectory(relativePath);
            return Path.GetFullPath(relativePath);
        }

        public static Pet? GetPetByUserId(long userId) => _provider.Get(GetPath(), userId.ToString()).Result;

        public static Pet CreatePet(string name, long userId)
        {
            var pet = new Pet(name, userId);
            pet.DumpToFile();
            return pet;
        }

        private void DumpToFile() => _provider.Save(this, GetPath(), OwnerId.ToString());

        private int CalculateState(DateTime lastStateChangeTime)
        {
            var state = 100 - (int)(DateTime.Now - lastStateChangeTime).TotalSeconds;
            return state > 0 ? state : 0;
        }

        public Pet(string name, long ownerId)
        {
            Name = name;
            OwnerId = ownerId;
        }

        public override string ToString()
        {
            return $"Pet<Name: {Name}, Satiety: {Satiety}, Cleanness: {Cleanness}, Sleepiness: {Sleepiness}>";
        }

        public string GetStateString()
        {
            return $"Состояние {Name}:\n\nСытость: {Satiety}/100\nЧистота: {Cleanness}/100\nБодрость: {Sleepiness}/100";
        }

        public void Eat()
        {
            LastEatTime = DateTime.Now;
            DumpToFile();
        }
        
        public void Clean()
        {
            LastCleanTime = DateTime.Now;
            DumpToFile();
        }

        public void Sleep(int hours)
        {
            LastSleepTime = DateTime.Now;
            DumpToFile();
        }

        public void Speak()
        {
            throw new NotImplementedException();
        }
    }
}
