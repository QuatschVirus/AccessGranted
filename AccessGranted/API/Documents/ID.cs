using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessGranted.API.Documents
{
    public class ID : Document
    {
        public override DocumentIdentifier Identifier => DocumentIdentifier.ID;

        public string Code { get; internal set; } = string.Empty;
        public string LastName { get; internal set; } = string.Empty;
        public string FirstName { get; internal set; } = string.Empty;
        public DateOnly DateOfBirth { get; internal set; }
        public DateOnly Expires {  get; internal set; }

        public string FacialRecognitionHash { get; internal set; } = string.Empty;
        public string FingerprintHash { get; internal set; } = string.Empty;

        public string Issued { get; internal set; } = string.Empty;
    }
}
