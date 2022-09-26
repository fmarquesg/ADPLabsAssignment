namespace ADPLabsAssignment.Domain
{
    public class ADPTaskInformation
    {
        public ADPTaskInformation(string id, string operation, double left, double right)
        {
            this.id = id;
            this.operation = operation;
            this.left = left;
            this.right = right;
        }

        public string id { get; private set; }
        public string operation { get; private set; }
        public double left { get; private set; }
        public double right { get; private set; }
    }
}
