using System.Collections.Generic;
using System.Threading.Tasks;
using EveryBodyCodes.Models;

namespace EveryBodyCodes.DataAccess
{
    public interface ICameraDataAccess
    {
        /// <summary>
        /// Reading All Data
        /// </summary>
        /// <returns>List of CameraData records</returns>
        Task<List<CameraData>> ReadAllData();
    }
}