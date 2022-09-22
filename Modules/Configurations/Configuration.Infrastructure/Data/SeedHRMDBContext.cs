

using System.Runtime.CompilerServices;
using System.Text.Json;
using Core.Domains;
using Core.Domains.Position;
using Domains.Directory;
using Microsoft.Extensions.Logging;
[assembly:InternalsVisibleTo("Configuration.Api")]
namespace Configuration.Infrastructure.Data
{
    internal class SeedHRMDBContext
    {
        public  static async Task SeedAsync(HRMDBContext hRMDBContext,ILoggerFactory loggerFactory){
             string CONFIG_DATA_DIRECTORY="../../Modules/Configurations/Configuration.Infrastructure/ConfigData";
            try
            {
                if(!hRMDBContext.Countries.Any())
                {
                    var countryData  =  File.ReadAllText(CONFIG_DATA_DIRECTORY+"/Country.json");
                    var countries = JsonSerializer.Deserialize<List<Country>>(countryData);
                    foreach (var item in countries)
                    {
                        hRMDBContext.Countries.Add(item);
                    }
                    await hRMDBContext.SaveChangesAsync();
                }
               
                if(!hRMDBContext.KeyValues.Any())
                {
                    var keyValueData  =  File.ReadAllText(CONFIG_DATA_DIRECTORY+"/KeyValue.json");
                    var keyValues = JsonSerializer.Deserialize<List<KeyValue>>(keyValueData);
                    foreach (var item in keyValues)
                    {
                        hRMDBContext.KeyValues.Add(item);
                    }
                    await hRMDBContext.SaveChangesAsync();
                }
               
                if(!hRMDBContext.Titles.Any())
                {
                    var titlesData  =  File.ReadAllText(CONFIG_DATA_DIRECTORY+"/Title.json");
                    var titles = JsonSerializer.Deserialize<List<Title>>(titlesData);
                    foreach (var item in titles)
                    {
                        hRMDBContext.Titles.Add(item);
                    }
                    await hRMDBContext.SaveChangesAsync();
                }

                if(!hRMDBContext.PositionChangeReasons.Any())
                {
                   await hRMDBContext.PositionChangeReasons.AddRangeAsync(
                        PositionChangeReason.Correction,
                        PositionChangeReason.Promotion,
                        PositionChangeReason.Demotion,
                        PositionChangeReason.Transfer,
                        PositionChangeReason.Employment,
                        PositionChangeReason.Other                    
                    );
                     await hRMDBContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SeedHRMDBContext>();
                logger.LogError(ex,"Error while seeding!.");
            }
        }
    }
}
