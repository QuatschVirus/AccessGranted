namespace AG_API
{

    public sealed class Case
    {
        public enum State
        {
            Granted,
            //Investigate,
            Denied,
            Detained
        }

        public State state { get; private set; }
        public DocumentIdentifier faultyDocument { get; private set; }
        public int faultReason { get; private set; }

        public void Deny(DocumentIdentifier document, int reason)
        {
            state = State.Denied;
            faultyDocument = document;
            faultReason = reason;
        }

        public void Detain(DocumentIdentifier document, int reason)
        {
            state = State.Detained;
            faultyDocument = document;
            faultReason = reason;
        }


    }
}
