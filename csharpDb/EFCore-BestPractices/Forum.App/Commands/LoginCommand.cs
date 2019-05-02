using Forum.Models;
using Forum.Services.Contracts;

namespace Forum.App.Commands.Contrancts
{
    public class LoginCommand : ICommand
    {
        private readonly IUserService userService;

        public LoginCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(params string[] arguments)
        {
            var username = arguments[0];
            var password = arguments[1];

            var user = userService.ByUsernameAndPassword<User>(username, password);

            if (user == null)
            {
                return "Invalid username or password";
            }

            Session.User = user;

            return "Logged in successfully";
        }
    }
}
