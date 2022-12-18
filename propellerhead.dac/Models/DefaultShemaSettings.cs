using System;
namespace propellerhead.dac.Models
{
    public class DefaultShemaSettings
    {
        public static string SettingName => "DefaultDatabaseSchema";
        public string DefaultSchemaCustomer { get; set; }
    }
}

