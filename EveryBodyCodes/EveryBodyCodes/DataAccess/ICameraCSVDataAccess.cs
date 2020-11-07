using System.Collections.Generic;
using EveryBodyCodes.Models;

namespace EveryBodyCodes.DataAccess
{
    public interface ICameraCSVDataAccess
    {
        List<CameraData> ReadAllData();
    }
}