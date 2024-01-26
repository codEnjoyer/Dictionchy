using Dictionchy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionchy.Infrastructure
{
    internal static class FileManager
    {
        public static string GetPath()
        {
            var relativePath = DotEnv.Resources;
            Directory.CreateDirectory(relativePath);
            return Path.GetFullPath(relativePath);
        }

        public static void DumpPetToFile(Pet pet) 
            => ClassDumper.Dump(pet, GetPath(), pet.OwnerId.ToString());
    }
}
