namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Input;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Views;

    public class AddReplyController : IController
    {
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;
        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        public AddReplyController()
        {
            this.ResetReply();
        }

        public PostViewModel Post { get; private set; }

        public ReplyViewModel Reply { get; private set; }

        private TextArea TextArea { get; set; }

        public bool Error { get; set; }

        public MenuState ExecuteCommand(int index)
        {
            throw new System.NotImplementedException();
        }

        public IView GetView(string userName)
        {
            this.Reply.Author = userName;
            return new AddReplyView(this.Post, this.Reply, this.TextArea, this.Error);
        }

        public void ReadAuthor()
        {
            this.Reply.Author = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        private enum Command
        {
            AddAuthor,
            Write,
            Back
        }

        public void ResetReply()
        {
            this.Error = false;
            this.Post = new PostViewModel();
            this.Reply = new ReplyViewModel();
            this.TextArea = new TextArea(centerLeft - 18, centerTop - 7,
                TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }
    }
}
