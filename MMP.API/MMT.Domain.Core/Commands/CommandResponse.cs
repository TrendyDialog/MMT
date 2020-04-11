namespace MMT.Domain.Core.Commands
{
    public class CommandResponse
    {
        private static CommandResponse Ok = new CommandResponse { Success = true };
        private static CommandResponse Fail = new CommandResponse { Success = false };

        public CommandResponse(bool success = false)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}
