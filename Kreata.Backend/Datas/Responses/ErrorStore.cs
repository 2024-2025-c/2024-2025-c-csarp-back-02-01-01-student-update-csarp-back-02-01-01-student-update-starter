namespace Kreata.Backend.Datas.Responses
{
    public class ErrorStore
    {
        public ErrorStore()
        {
            Error = string.Empty;
        }

        public string Error { get; set; } = string.Empty;
        public bool HasError => !string.IsNullOrEmpty(Error);
        public void ClearErrorStore()
        {
            Error = string.Empty;
        }
        public void ClearAndAddError(string error)
        {
            Error = error;
        }
        public void AppendNewError(string error)
        {
            Error = $"{Error}\n{error}";
        }
    }
}
