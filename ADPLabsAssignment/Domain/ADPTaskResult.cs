namespace ADPLabsAssignment.Domain
{
    public class ADPTaskResult
    {
        public ADPTaskResult(string id, double result)
        {
            this.id = id;
            this.result = result;
        }

        public string id { get; private set ; }
        public double result { get; private set; }
    }
}
