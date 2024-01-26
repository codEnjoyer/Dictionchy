using Dictionchy.Infrastructure;

namespace Dictionchy.Domain
{
    public class Pet
    {
        public int maxSatiety = 100;
        public int maxCleanness = 100;
        public int maxSleepiness = 100;

        public long OwnerId { get; }
        public string Name { get; }


        public DateTime LastEatTime { get; set; }
        public DateTime LastCleanTime { get; set; }
        public DateTime LastSleepTime { get; set; }

        public int Satiety => CalculateState(LastEatTime, maxSatiety);
        public int Cleanness => CalculateState(LastCleanTime, maxCleanness);
        public int Sleepiness => CalculateState(LastSleepTime, maxSleepiness);


        public static Pet? GetPetByUserId(long userId) => FileManager.GetPetFromFile(userId.ToString());

        public static Pet CreatePet(string name, long userId)
        {
            var pet = new Pet(name, userId);
            FileManager.SavePetToFile(pet);
            return pet;
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
            return
                $"Состояние {Name}:\n\nСытость: {Satiety}/{maxSatiety}\nЧистота: {Cleanness}/{maxCleanness}\nБодрость: {Sleepiness}/{maxSleepiness}";
        }

        public void Eat()
            => DoPetAction(() => LastEatTime = DateTime.Now);

        public void Clean()
            => DoPetAction(() => LastCleanTime = DateTime.Now);

        public void Sleep(int hours)
            => DoPetAction(() => LastSleepTime = DateTime.Now);

        public void Speak()
        {
            throw new NotImplementedException();
        }

        private void DoPetAction(Action petAction)
        {
            petAction.Invoke();
            FileManager.SavePetToFile(this);
        }

        private int CalculateState(DateTime lastStateChangeTime, int maxStateValue)
        {
            var state = maxStateValue - (int) (DateTime.Now - lastStateChangeTime).TotalHours * 5;
            return state > 0 ? state : 0;
        }
    }
}