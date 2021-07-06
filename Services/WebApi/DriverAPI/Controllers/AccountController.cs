﻿using DriverAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DriverAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<IdentityUser> _userManager;

		public AccountController(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/api/Register")]
		public IActionResult Post([FromBody] RegisterRequestDto loginRequestModel)
		{
			var user = new IdentityUser() { UserName = loginRequestModel.Username };
			var result = _userManager.CreateAsync(user, loginRequestModel.Password).Result;

			if (result.Succeeded)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
