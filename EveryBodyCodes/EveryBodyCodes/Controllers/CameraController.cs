using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EveryBodyCodes.Services;
using EveryBodyCodes.Models;

namespace EveryBodyCodes.Controllers
{
    [Route("api/[controller]")]
    public class CameraController : Controller
    {
        public ICameraService _cameraService;

        public CameraController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        [HttpGet("listed")]
        public IEnumerable<CameraData> GetAll()
        {
            return _cameraService.SearchByCameraName("");
        }

        [HttpGet("listed/{name}")]
        public IEnumerable<CameraData> Get(string name)
        {
            return _cameraService.SearchByCameraName(name);
        }

        [HttpGet("formatted")]
        public IEnumerable<List<CameraData>> GetAllFormatted()
        {
            return _cameraService.SearchByCameraNameFormatted("");
        }

        [HttpGet("formatted/{name}")]
        public IEnumerable<List<CameraData>> GetFormatted(string name)
        {
            return _cameraService.SearchByCameraNameFormatted(name);
        }
    }
}
