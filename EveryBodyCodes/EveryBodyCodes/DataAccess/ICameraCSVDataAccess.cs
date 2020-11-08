using System.Collections.Generic;
using EveryBodyCodes.Models;

namespace EveryBodyCodes.DataAccess
{
    public interface ICameraDataAccess
    {
        List<CameraData> ReadAllData();
    }
}