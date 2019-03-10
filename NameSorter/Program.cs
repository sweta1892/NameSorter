using NameSorter.Services;
using NameSorter.Models;
using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using System.IO;
using NLog;
using System.Collections.Generic;

[assembly: InternalsVisibleTo("NameSorterTest")]
namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            var _NameSorterSettingsConfig = new NameSorterSettingsConfig();
            configuration.GetSection("NameSorterSettings").Bind(_NameSorterSettingsConfig);

            //reads Output location from command-line arg
            string inputFileName = args[0].Trim();

            //reads Output location from config
            string outputFileName = _NameSorterSettingsConfig.Output;
            
            //reads Input file and stores data in memory-list for processing
            IReadDataService _dataReader = new FileReadDataService();
            List<Name> ListOfNames = _dataReader.ReadData(inputFileName);

            //reads Sorting method from config
            ISortingService _nameSorter = new NameSortingService(_NameSorterSettingsConfig.SortingSwitch);
            ListOfNames = _nameSorter.SortNameList(ListOfNames);
    
            //stores sorted names to the Output file
            IWriteDataService _dataWriter = new FileWriteDataService();
            _dataWriter.WriteData(outputFileName, ListOfNames);

            //print sorted names on screen
            new PrintNameList().PrintFullList(ListOfNames);
            Console.ReadKey();
           }       
    }
}