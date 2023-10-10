namespace IdentityService.Application.Users.Commands
{

	public class CreateUserCommand : Mediator.IRequest<System.Guid>
	{
		public CreateUserCommand() : base()
		{
		}

        [System.ComponentModel.DataAnnotations.Required]
        public string UserName { get; set; }



        [System.ComponentModel.DataAnnotations.Required]
        public string LastName { get; set; }



        [System.ComponentModel.DataAnnotations.Required]
        public string FirstName { get; set; }



        [System.ComponentModel.DataAnnotations.Required]
        public string EmailAddress { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; set; }


    }
}
