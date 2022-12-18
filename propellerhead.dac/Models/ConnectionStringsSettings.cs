using System;
using System.Diagnostics.CodeAnalysis;

namespace propellerhead.dac.Models
{
    [ExcludeFromCodeCoverage]
    public class ConnectionStringsSettings
    {
        public static string SettingName = "ConnectionStrings";
        public string ConnectionStringCustomer { get; set; }

    }
}

