﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using VillaManage_VillaAPI.Model;
using VillaManage_VillaAPI.Model.DTO;
using VillaManage_VillaAPI.Repository.IRepository;

namespace VillaManage_VillaAPI.Controllers
{
    [Route("api/UserAuth")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;
        protected APIResponse _response;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            this._response = new();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _userRepo.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessagess.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode=HttpStatusCode.OK;
            _response.IsSuccess=true;
            _response.Result = loginResponse;
            return Ok(_response);

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDTO model)
        {
         bool ifUserNameUnique = _userRepo.IsUniqueUser(model.UserName);
            if (!ifUserNameUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessagess.Add("Username already exists");
                return BadRequest(_response);
            }
           var user = await _userRepo.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessagess.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
