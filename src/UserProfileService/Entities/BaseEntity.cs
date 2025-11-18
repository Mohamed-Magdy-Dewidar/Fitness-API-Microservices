namespace UserProfileService.Entities;

public class BaseEntity<TKey>
{
    public TKey Id { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime UpdatedOnUtc { get; set; }

    public bool IsDeleted { get; set; }
}
