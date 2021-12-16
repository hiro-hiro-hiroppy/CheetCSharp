using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWS.Simple.Lambda
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(object input, ILambdaContext context)
        {
            // ó‚¯æ‚Á‚½ˆø”‚ğƒƒO‚Éo—Í
            context.Logger.LogLine($"Arg : [{input}]");
            // ‚n‚j ‚Æ‚¢‚¤•¶š—ñ‚ğ•Ô‚·
            return "OK"; //input?.ToUpper();
        }
    }
}
