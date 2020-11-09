using System.Collections.Generic;
using System.Threading.Tasks;
using EveryBodyCodes.Models;

namespace EveryBodyCodes.DataAccess
{
    public interface ICameraDataAccess
    {
        Task<List<CameraData>> ReadAllData();
    }
}