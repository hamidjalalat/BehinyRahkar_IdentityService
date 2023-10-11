﻿namespace IdentityService.Application.Users.Commands
{

	public class CreateUserCommand : Mediator.IRequest<System.Guid>
	{
		public CreateUserCommand() : base()
		{
		}

        public string UserName { get; set; }


        public string LastName { get; set; }


        public string FirstName { get; set; }


        public string EmailAddress { get; set; }

        public string Password { get; set; }


    }
}
