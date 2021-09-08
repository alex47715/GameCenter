using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GameCenter.DAL.Enums
{
    public enum ParcelStatus
    {
        [EnumMember(Value = "UnPaid")]
        UnPaid = 0,
        [EnumMember(Value = "WaitingSender")]
        WaitingSender = 1,
        [EnumMember(Value = "OnTheWay")]
        OnTheWay = 2,
        [EnumMember(Value = "Received")]
        Received = 3
    }
}
