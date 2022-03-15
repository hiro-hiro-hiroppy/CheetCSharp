using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Summary.ApiSummary.Interface
{
    interface IApiSummary
    {
        dynamic CallGetWebAPI(string url);
        void CallPostWebAPI(string url, string data);
        void CallPutWebAPI(string url, string data);
        void CallDeleteWebAPI(string url);
    }
}
