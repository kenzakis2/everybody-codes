using System.Collections.Generic;
using System.Threading.Tasks;
using EveryBodyCodes.Models;

namespace EveryBodyCodes.Services
{
    public interface ICameraService
    {
        /// <summary>
        /// Searching records by camera name
        /// </summary>
        /// <param name="CameraName">string contained in the name field. if empty, all records will be returned.</param>
        /// <returns>Matching camera data records</returns>
        Task<List<CameraData>> SearchByCameraName(string CameraName);

        /// <summary>
        /// Search and format Camera Records according to business rule
        /// </summary>
        /// <param name="CameraName">string contained in the name field. if empty, all records will be returned.</param>
        /// <returns>Matching camera data records in 4 Lists.</returns>
        Task<List<List<CameraData>>> SearchByCameraNameFormatted(string CameraName);
    }
}