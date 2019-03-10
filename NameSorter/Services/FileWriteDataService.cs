using NameSorter.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.Services
{
    class FileWriteDataService : IWriteDataService
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
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
                log.Error(e.Message);
            }
        }
    }
}
