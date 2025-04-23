using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecepiCRUD.Service.Interfaces;
using RecepiCRUD.ViewModel;

namespace RecepiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepiController : ControllerBase
    {
        private readonly IRecepiService _recepiService;
        public RecepiController(IRecepiService recepiService)
        {
            _recepiService = recepiService;

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
                var recepies = _recepiService.GetRecepi();
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
                var recepies = _recepiService.GetRecepiById(recepiVM.RecepiId);
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
                var recepi = _recepiService.AddRecepi(recepiVM);
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
                var recepi = _recepiService.DeleteRecepi(Id);
                return Ok(recepi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}