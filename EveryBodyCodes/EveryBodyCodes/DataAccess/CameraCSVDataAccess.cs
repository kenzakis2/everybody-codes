using EveryBodyCodes.Configurations;
using EveryBodyCodes.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;

namespace EveryBodyCodes.DataAccess
{
    public class CameraCSVDataAccess : ICameraCSVDataAccess
    {
        private readonly CameraConfiguration cameraConfiguration;

        public CameraCSVDataAccess(IOptions<CameraConfiguration> options)
        {
            cameraConfiguration = options.Value;
        }

        public List<CameraData> ReadAllData()
        {
            var result = new List<CameraData>();
            using (var reader = new StreamReader(cameraConfiguration.CSVAddress))
            {
                using (var file = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                {
                    file.Read();
                    file.ReadHeader();
                    while (file.Read())
                    {
                        var record = new CameraData
                        {
                            Name = file.GetField("Camera"),
                            Latitude = file.GetField("Latitude"),
                            Longitude = file.GetField("Longitude")
                        };
                        result.Add(record);
                    }
                }
            }

            return result;
        }
    }
}
