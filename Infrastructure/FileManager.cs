using Dictionchy.Domain;

namespace Dictionchy.Infrastructure
{
    public static class FileManager
    {
        public static string GetPath()
        {
            var relativePath = DotEnv.Resources;
            Directory.CreateDirectory(relativePath);
            return Path.GetFullPath(relativePath);
        }

        public static void SavePetToFile(Pet pet)
        {
            var db = new FileDB<Pet>();
            db.Save(pet, GetPath(), pet.OwnerId.ToString());
        }

        public static Pet? GetPetFromFile(string filename)
        {
            var db = new FileDB<Pet>();
            return db.Get(GetPath(), filename);
        }
    }
}
