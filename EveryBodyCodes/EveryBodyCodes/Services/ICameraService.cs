using System.Collections.Generic;
using System.Threading.Tasks;
using EveryBodyCodes.Models;

namespace EveryBodyCodes.Services
{
    public interface ICameraService
    {
        Task<List<CameraData>> SearchByCameraName(string CameraName);
        Task<List<List<CameraData>>> SearchByCameraNameFormatted(string CameraName);
    }
}