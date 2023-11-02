using System;

public interface IModifiedOn
{
    public string? ModifiedByUserId { get; set; }
    public DateTime? ModifiedOn { get; set; }
}