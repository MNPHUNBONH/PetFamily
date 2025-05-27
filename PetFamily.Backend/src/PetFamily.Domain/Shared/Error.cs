namespace PetFamily.Domain.Shared;

public record Error
{
    public const string SEPARATOP = "||"; 
    public string Code { get; }
    public string Message { get; }
    public ErrorType Type { get; }
    public string? InlalidField { get; }

    private Error(string code, string message, ErrorType type, string? inlalidField = null)
    {
        Code = code;
        Message = message;
        Type = type;
        InlalidField = inlalidField;
    }
    
    public static Error Validation(string code, string message,string? invalidField = null) =>
        new Error(code, message, ErrorType.Validation, invalidField );
    
    public static Error NotFound(string code, string message) =>
        new Error(code, message, ErrorType.NotFound);
    
    public static Error Failure(string code, string message) =>
        new Error(code, message, ErrorType.Failure);
    
    public static Error Conflict(string code, string message) =>
        new Error(code, message, ErrorType.Conflict);

    public string Serialize()
    {
        return string.Join(SEPARATOP,Code,Message,Type);
    }

    public static Error DeSerialize(string serialized )
    {
        var parts = serialized.Split(SEPARATOP);

        if (parts.Length < 2)
            throw new ArgumentException($"Invalid serialized format");

        if (Enum.TryParse<ErrorType>(parts[2], out var type) == false)
            throw new ArgumentException($"Invalid serialized format");
        
        return new Error(parts[0], parts[1], type);
    }

    public ErrorList ToErrorList() => new([this]);
}

public enum ErrorType
{
    NotFound,
    Validation,
    Failure,
    Conflict
}