using System;

namespace airbnb.comLister.Models
{
    public class KnownException : Exception
    {
        public KnownException(string s) : base(s)
        {

        }
    }
}