﻿using System.ComponentModel.DataAnnotations;

namespace CompanyCatalogue.Helpers
{
	public class LoginModel
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}