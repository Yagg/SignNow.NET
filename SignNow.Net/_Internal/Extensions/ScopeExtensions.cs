using SignNow.Net.Model;
using System;

namespace SignNow.Net.Internal.Extensions
{
    public static class ScopeExtensions
    {
        public static string AsString(this Scope scope)
        {
            switch (scope)
            {
                case Scope.All: return "*";
                case Scope.User: return "user";
                default: throw new NotImplementedException($"Unable to convert scope value {scope} to string.");
            }
        }
    }
}
