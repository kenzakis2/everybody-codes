using System.Collections.Generic;
using EveryBodyCodes.Models;

namespace EveryBodyCodes.Services
{
    public interface ICameraService
    {
        List<CameraData> SearchByCameraName(string CameraName);
        List<List<CameraData>> SearchByCameraNameFormatted(string CameraName);
    }
}