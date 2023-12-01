﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presencasEventoRepository { get; set; }

        public PresencasEventoController()
        {
            _presencasEventoRepository = new PresencaRepository();
        }


        [HttpGet]
        public IActionResult Get()

        {
            try
            {
                return Ok(_presencasEventoRepository.Listar());


            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }


        [HttpPost]
        public IActionResult Post(PresencasEvento presencasEvento)

        {
            try
            {
                _presencasEventoRepository.Inscrever(presencasEvento);

                return StatusCode(202);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }

        [HttpDelete]
        public IActionResult Delete(Guid id)

        {
            try
            {
                _presencasEventoRepository.Deletar(id);

                return StatusCode(202);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }




        }


    }
}
