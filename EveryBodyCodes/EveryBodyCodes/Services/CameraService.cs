using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveryBodyCodes.DataAccess;
using EveryBodyCodes.Models;

namespace EveryBodyCodes.Services
{
    public class CameraService : ICameraService
    {
        private readonly ICameraDataAccess _cameraDataAccess;

        public CameraService(ICameraDataAccess cameraDataAccess)
        {
            _cameraDataAccess = cameraDataAccess;
        }

        public async Task<List<CameraData>> SearchByCameraName(string CameraName)
        {
            var baseList = await _cameraDataAccess.ReadAllData();

            if (string.IsNullOrEmpty(CameraName))
                return baseList;

            return baseList.Where(e => e.Name.Contains(CameraName)).ToList();
        }

        public async Task<List<List<CameraData>>> SearchByCameraNameFormatted(string CameraName)
        {
            var column1 = new List<CameraData>();
            var column2 = new List<CameraData>();
            var column3 = new List<CameraData>();
            var column4 = new List<CameraData>();

            var baseList = await SearchByCameraName(CameraName);

            foreach (var item in baseList)
            {
                if (item.Number == -1)
                {
                    //error ones
                    continue;
                }
                else if (item.Number % 3 == 0 && item.Number % 5 == 0)
                {
                    column3.Add(item);
                }
                else if (item.Number % 3 == 0)
                {
                    column1.Add(item);
                }
                else if (item.Number % 5 == 0)
                {
                    column2.Add(item);
                }
                else
                {
                    column4.Add(item);
                }
            }

            var result = new List<List<CameraData>>() { column1, column2, column3, column4 };
            return result;
        }
    }
}
