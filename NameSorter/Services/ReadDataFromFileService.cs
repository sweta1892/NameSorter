using NameSorter.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.Services
{
    class ReadDataFromFileService : IReadDataService
    {
        public List<Name> ReadData(string fileName)
        {
            List<Name> listOfNames = new List<Name>();
            CreateNameObjects createNameObjects = new CreateNameObjects();
            DataValidationService dataValidation = new DataValidationService();

            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    string line="";
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (dataValidation.IsValid(line))
                        {
                            listOfNames.Add(createNameObjects.CreateNameObjectFromString(line));
                        }
                        else
                        {
                            //log error to file
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return listOfNames;

        }
    }
}
