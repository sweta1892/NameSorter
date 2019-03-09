using NameSorter.Services;
using NameSorter.Models;
using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Logging;

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

            var servicesProvider = BuildDi();
            var runner = servicesProvider.GetRequiredService<Runner>();

            runner.DoAction("Action1");

            NameList nameList = new NameList();
            string inputFileName = args[0].Trim();

            string outputFileName = _NameSorterSettingsConfig.Output;
            
            IReadDataService _dataReader = new ReadDataFromFileService();
            nameList.listOfNames = _dataReader.ReadData(inputFileName);

            ISortingService _nameSorter = new NameSortingService(_NameSorterSettingsConfig.SortingSwitch);
            nameList.listOfNames = _nameSorter.SortNameList(nameList.listOfNames);
                        
            IWriteDataService _dataWriter = new WriteDataToFileService();
            _dataWriter.WriteData(outputFileName, nameList.listOfNames);

            nameList.PrintFullList();
            Console.ReadKey();

            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            NLog.LogManager.Shutdown();
        }

        private static ServiceProvider BuildDi()
        {
            return new ServiceCollection()
                .AddLogging(builder => {
                    builder.SetMinimumLevel(LogLevel.Information);
                    builder.AddNLog(new NLogProviderOptions
                    {
                        CaptureMessageTemplates = true,
                        CaptureMessageProperties = true
                    });
                })
                .AddTransient<Runner>()
                .BuildServiceProvider();
        }
    }
}