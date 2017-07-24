using System.Runtime.Serialization;

namespace Port.Net.Models.Dto
{
    [DataContract]
    public class EmailModel
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "EmailAddress")]
        public string EmailAddress { get; set; }

        [DataMember(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "Message")]
        public string Message { get; set; }
    }
}