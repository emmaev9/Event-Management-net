namespace TicketMS.Exceptions
{
    public class InvalidFieldException : Exception
    {
        public InvalidFieldException() { }

        public InvalidFieldException(string message) : base(message) { }

        public InvalidFieldException(string message, Exception innerException) : base(message, innerException) { }

        public InvalidFieldException(int entityId, string entityName) : base(FormattableString.Invariant($"'{entityName}' with id '{entityId}' was not found")) { }
    }
}
