
using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer;

public record VolunteerEmail
{
    private static readonly Regex EmailRegex = new Regex(
        @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);
    public const int MAX_LENGTH = 100;
    public string Value { get; }

    private VolunteerEmail(string value)
    {
        Value = value;
    }
    
    public static Result<VolunteerEmail,Error> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Errors.General.ValueIsInvalid("VolunteerEmail");
        
        if (email.Length > MAX_LENGTH)
            return Errors.General.ValueIsRequired("VolunteerEmail");
        
        if (!EmailRegex.IsMatch(email))
             return Errors.General.ValueIsInvalid("VolunteerEmail");
        
        return new VolunteerEmail(email);
    }
    
};