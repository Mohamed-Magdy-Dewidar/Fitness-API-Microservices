
using Contracts;
using MassTransit;
using UserProfileService.DataBase;
using UserProfileService.Entities;

namespace UserProfileService.Features.Profiles;

public class UserProfileCreatedConsumer : IConsumer<UserCreatedEvent>
{
    private readonly Repository<UserProfile, string> _repository;

    public UserProfileCreatedConsumer(Repository<UserProfile, string> repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        var userProfile = new UserProfile
        {
            Id = context.Message.UserId,
            UserName = context.Message.UserName,
            CreatedOnUtc = context.Message.CreatedOnUtc,
            Email = context.Message.Email
        };

        await _repository.AddAsync(userProfile);
        await _repository.SaveChangesAsync();
    }
}