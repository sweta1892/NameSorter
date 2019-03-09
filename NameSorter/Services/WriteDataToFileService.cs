using NameSorter.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.Services
{
    class WriteDataToFileService : IWriteDataService
    {
       
        public void WriteData(string fileName, List<Name> listOfNames)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(fileName))
                {
                    foreach (Name name in listOfNames)
                    {
                        streamWriter.WriteLine(name.ToString());
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be write");
                Console.WriteLine(e.Message);
            }
        }
    }
}
