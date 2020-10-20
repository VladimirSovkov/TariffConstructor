
using System;

namespace TariffConstructor.Toolkit.Exceptions
{
    public static class ValidationMessage
    {
        public static string MustSpecify(string what) => $"Must specify {what}";
        public static string AlreadyExists(string what) => $"Already exists {what}";

        public static string Incorrect(string v)
        {
            throw new NotImplementedException();
        }

        public static string MustBeGreater(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
