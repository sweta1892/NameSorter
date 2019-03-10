using NameSorter.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.Services
{
    class FileReadDataService : IReadDataService
    {

        private static Logger log = LogManager.GetCurrentClassLogger();
        public List<Name> ReadData(string fileName)
        {
            List<Name> listOfNames = new List<Name>();
            CreateNameObjects createNameObjects = new CreateNameObjects();
            NameDataValidateService dataValidation = new NameDataValidateService();

            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    string NameRecord="";
                    while ((NameRecord = streamReader.ReadLine()) != null)
                    {
                        if (dataValidation.IsValid(NameRecord))
                        {
                            listOfNames.Add(createNameObjects.CreateNameObjectFromString(NameRecord));
                        }
                        else
                        {
                            log.Info("Name record "+ NameRecord + " ignored due to invalid format.");
                        }
                    }
                }
            }
            catch (IOException e)
            {
               log.Error(e.Message);
            }

            return listOfNames;

        }
    }
}
