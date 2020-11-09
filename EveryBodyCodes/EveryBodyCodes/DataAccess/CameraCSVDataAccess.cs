using EveryBodyCodes.Configurations;
using EveryBodyCodes.Models;
using Microsoft.Extensions.Options;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;

namespace EveryBodyCodes.DataAccess
{
    public class CameraCSVDataAccess : ICameraDataAccess
    {
        private readonly CameraConfiguration cameraConfiguration;

        public CameraCSVDataAccess(IOptions<CameraConfiguration> options)
        {
            cameraConfiguration = options.Value;
        }

        /// <summary>
        /// Reading all the data from CSV
        /// </summary>
        /// <returns>List of Camera Data</returns>
        public async Task<List<CameraData>> ReadAllData()
        {
            var result = new List<CameraData>();
            using (var reader = new StreamReader(cameraConfiguration.CSVAddress))
            {
                using (var file = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                {
                    file.Configuration.Delimiter = ";";
                    file.Configuration.MissingFieldFound = null;
                    file.Read();
                    file.ReadHeader();
                    while (await file.ReadAsync())
                    {
                        var record = new CameraData
                        {
                            Name = file.GetField("Camera"),
                            Latitude = file.GetField("Latitude"),
                            Longitude = file.GetField("Longitude")
                        };

                        if (!record.Name.ToLower().StartsWith("error"))
                        {
                            record.Number = GetCameraNumber(record.Name);
                            result.Add(record);
                        }
                        else
                        {
                            //TODO: Log reading error
                        }
                    }
                }
            }

            return result;
        }

        private int GetCameraNumber(string CameraName)
        {
            var pattern = @"UTR-CM-(\d+)";
            var match = Regex.Match(CameraName, pattern);
            if (match.Success)
            {
                var numPart = match.Groups[1];
                return int.Parse(numPart.Value);
            }

            return -1;
        }
    }
}
