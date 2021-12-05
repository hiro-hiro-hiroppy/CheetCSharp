using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CheetNetCoreMVC.CS
{
    public class StringCh
    {
        public string[] StringSplit(string value, string separator)
        {
            string[] result;

            result = value.Split(separator);

            return result;
        }

        public string StringTrim(string value)
        {
            string result = "";

            return result;
        }



    }
}