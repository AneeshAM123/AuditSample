using System.Runtime.Serialization;

namespace Datarynx.Enums
{
    public enum TaskState
    {
        [EnumMember(Value = "Not Started")]
        NotStarted = 0,

        [EnumMember(Value = "In-Progress")]
        InProgress = 1
    }
}
