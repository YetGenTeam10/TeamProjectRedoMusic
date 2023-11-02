using System;

public interface IDeletedOn
{
    public string? DeletedByUserId { get; set; }
    public DateTime? DeletedOn { get; set; }
    public bool? IsDeleted { get; set; }
}
