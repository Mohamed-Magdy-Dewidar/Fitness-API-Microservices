namespace Contracts;


public record UserCreatedEvent
{
        public required string UserId { get; init; }
        public required string Email { get; init; }
        public required  string UserName { get; init; }
        public DateTime CreatedOnUtc { get; set; }
}

