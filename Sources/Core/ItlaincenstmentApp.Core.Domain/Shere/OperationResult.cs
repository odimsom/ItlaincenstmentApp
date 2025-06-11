namespace ItlaincenstmentApp.Core.Domain.Shere
{
    public class OperationResult<T>
    {
        public T Value { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        private OperationResult(T value, bool isSuccess, string message)
        {
            Value = value;
            IsSuccess = isSuccess;
            Message = message;
        }
        public static OperationResult<T> Success(T value, string successMessage) => new OperationResult<T>(value, true, successMessage);
        public static OperationResult<T> Fail(string errorMessage, T value = default!) => new OperationResult<T>(value, false, errorMessage);
    }
}
