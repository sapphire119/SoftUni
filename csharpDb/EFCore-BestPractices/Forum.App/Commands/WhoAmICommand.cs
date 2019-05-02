namespace Forum.App.Commands
{
    using Forum.App.Commands.Contrancts;

    public class WhoAmICommand : ICommand
    {
        public string Execute(params string[] arguments)
        {
            if (Session.User == null)
            {
                return "You are not logged in!";
            }

            var currentUser = $"{Session.User.Username}";

            return currentUser;
        }
    }
}
