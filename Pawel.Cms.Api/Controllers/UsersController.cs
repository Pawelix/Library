using System;
using Microsoft.AspNetCore.Mvc;
using Pawel.Cms.Common.DTOs;
using Pawel.Cms.Domain.Services.Interfaces;

namespace Pawel.Cms.Api.Controllers
{
    /// <summary>
    ///  Users Controller 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IEmailService _emailService;
              
        /// <summary>
        /// jaki opis
        /// </summary>
        /// <param name="emailService"></param>
        public UsersController(IEmailService emailService)
        {
            _emailService = emailService;
        }      
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public void Post([FromBody] EmailDTO model)
        {
            _emailService.SendEmail($"{model.FromAddress} - {model.Subject} ", model.Content);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("SendActivationLink/{id}")]
        public void SendActivationLink([FromRoute] Guid id)
        {
            // 1 . get user !!!
            // 2 if user nie jest nullem to :
            var body = _emailService.CreateActivationLinkBody(id);
            _emailService.SendEmail("Activation link - Cms.pl", body, "u.sobek@wp.pl" /*tu podajesz user.email*/);
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("ActivationUser/{id}")]
        public void ActivationUser([FromRoute] Guid id)
        {
            var test = id;
            // 1. userService.activate(id) :( w srodku userService.GetUser(id) )
            // 1.1check expiration date = przy rejestracji jest zapisywana data CreateDate, trzeba spr czy (DateTime.Now - CreateDate ).Days < 30
            // 1.2. update isActive = true ( UsersRepository.ActiveUser(id))

            // przekierowac na strone logowania + komunikat/dymek z info ze udalo się aktywowac
        }
    }
}
