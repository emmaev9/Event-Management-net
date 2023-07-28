﻿namespace TicketMS.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() { }

        public EntityNotFoundException(string message) : base(message) { }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        public EntityNotFoundException(int entityId, string entityName) : base(FormattableString.Invariant($"'{entityName}' with id '{entityId}' was not found")) { }
    }
}
