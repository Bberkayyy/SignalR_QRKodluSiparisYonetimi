namespace SignalR_WebUI.Dtos.ValidationErrorDtos;

public class ResultValidationErrorDto
{
    public string propertyName { get; set; }
    public string errorMessage { get; set; }
    public object attemptedValue { get; set; }
    public object customState { get; set; }
    public int severity { get; set; }
    public string errorCode { get; set; }
    public Formattedmessageplaceholdervalues formattedMessagePlaceholderValues { get; set; }

    public class Formattedmessageplaceholdervalues
    {
        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public int TotalLength { get; set; }
    }
}
