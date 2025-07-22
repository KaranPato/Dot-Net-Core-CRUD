using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecepiCRUD.Service.Interfaces;
using RecepiCRUD.ViewModel;
using System;

namespace RecepiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepiController : ControllerBase
    {
        //private readonly IRecepiService _recepiService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RecepiController> _logger;
        public RecepiController(IUnitOfWork unitOfWork, ILogger<RecepiController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

        /// <summary>
        /// This method is used to get all recepies
        /// </summary>
        /// <returns>Successful message with a Response View Model</returns>
        /// <response code="200">Recepies found successfully.</response>
        [ProducesResponseType(200, Type = typeof(ResponseVM))]
        [AllowAnonymous]
        [HttpGet("GetRecepies")]
        public ActionResult GetRecepies()
        {
            try
            {
                _logger.LogInformation("In method GetRecepies");
                var recepies = _unitOfWork.RecepiService.GetRecepi();
                return Ok(recepies);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost("GetRecepiById")]
        public ActionResult GetRecepiById([FromBody] RecepiVM recepiVM)
        {
            try
            {
                var recepies = _unitOfWork.RecepiService.GetRecepiById(recepiVM.RecepiId);
                return Ok(recepies);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost("AddRecepi")]
        public ActionResult AddRecepi([FromBody]RecepiVM recepiVM)
        {
            try
            {
                var recepi = _unitOfWork.RecepiService.AddRecepi(recepiVM);
                return Ok(recepi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpDelete("{Id}")]
        public ActionResult DeleteRecepi([FromRoute]int Id)
        {
            try
            {
                var recepi = _unitOfWork.RecepiService.DeleteRecepi(Id);
                return Ok(recepi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}