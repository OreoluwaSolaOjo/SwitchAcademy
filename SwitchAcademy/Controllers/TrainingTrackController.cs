using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SwitchAcademy.Persistence.DTOs;
using SwitchAcademy.Persistence.Models;
using SwitchAcademy.Persistence.Responses;
using SwitchAcademy.Services.Interfaces;

namespace SwitchAcademy.Controllers
{
    [Route("api/v1/training-track")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class TrainingTrackController : Controller
    {
        private readonly ITrainingTrackService _trainingTrackService;
        private readonly ILogger<TrainingTrackController> _logger;

        public TrainingTrackController(ITrainingTrackService trainingTrackService, ILogger<TrainingTrackController> logger)
        {
            _trainingTrackService = trainingTrackService;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<ActionResult<AllTrainingTrackResponse<GetTrainingTrackDto>>> GetAll()
        {
            var response = await _trainingTrackService.GetAllTrainingTracks();
            _logger.LogInformation($"Response gotten from trainingtrack Service");
            if (response.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("getTrainingTrack/{Id}")]
        public async Task<ActionResult<GetSingleTrainingTrackResponse<GetTrainingTrackDto>>> GetById(int Id)
        {
        
            var response = await _trainingTrackService.GetTrackById(Id);
            if (response.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
