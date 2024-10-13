namespace AccessGranted.API
{
    /// <summary>
    /// Allows you to manage the current case
    /// </summary>
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

        /// <summary>
        /// Deny entry for the applicant
        /// </summary>
        /// <param name="document">The identifier of the document that caused the denial</param>
        /// <param name="reason">The document-specific reason code for the denial</param>
        public void Deny(DocumentIdentifier document, int reason)
        {
            state = State.Denied;
            faultyDocument = document;
            faultReason = reason;
        }

        /// <summary>
        /// Detain the applicant
        /// </summary>
        /// <param name="document">The identifier of the document that caused detainment</param>
        /// <param name="reason">The document-specific reason for detainment</param>
        public void Detain(DocumentIdentifier document, int reason)
        {
            state = State.Detained;
            faultyDocument = document;
            faultReason = reason;
        }


    }
}
