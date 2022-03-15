using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Summary.JsonSummary.Interface
{
    interface IJsonSummary
    {
        string JsonSerialize<T>(List<T> data);
        List<T> JsonDeserialize<T>(string serializeObject);
    }
}
