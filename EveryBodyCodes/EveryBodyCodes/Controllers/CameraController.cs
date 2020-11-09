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
        public async Task<IEnumerable<CameraData>> GetAll()
        {
            return await _cameraService.SearchByCameraName("");
        }

        [HttpGet("listed/{name}")]
        public async Task<IEnumerable<CameraData>> Get(string name)
        {
            return await _cameraService.SearchByCameraName(name);
        }

        [HttpGet("formatted")]
        public async Task<IEnumerable<List<CameraData>>> GetAllFormatted()
        {
            return await _cameraService.SearchByCameraNameFormatted("");
        }

        [HttpGet("formatted/{name}")]
        public async Task<IEnumerable<List<CameraData>>> GetFormatted(string name)
        {
            return await _cameraService.SearchByCameraNameFormatted(name);
        }
    }
}
