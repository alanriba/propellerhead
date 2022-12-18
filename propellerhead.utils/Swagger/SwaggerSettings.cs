using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Propellerhead.Utils.Swagger
{
    [ExcludeFromCodeCoverage]
    internal class SwaggerSettings
    {
        public static string SettingName = "SwaggerConfiguration";
        public string Title { get; set; }
        public string ContactName { get; set; }
        public string ContactUrl { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string ServerPrefix { get; set; }
        public string Scheme { get; set; }
        public IEnumerable<string> HeadersVersions { get; set; }
        public IEnumerable<SwaggerVersionConfiguration> SwaggerVersionConfiguration { get; set; }

        /// <summary>
        /// Información de contacto para la definición swagger
        /// </summary>
        /// <param name="version"></param>
        /// <returns>OpenApiInfo</returns>
        public OpenApiInfo GetInfo(string version)
        {
            OpenApiInfo info = new OpenApiInfo
            {
                Contact = new OpenApiContact
                {
                    Email = Email ?? "name@exmaple.com",
                    Name = ContactName ?? "Contact Name",
                    Url = new Uri(ContactUrl ?? @"https://example.com")
                },
                Description = Description,
                Title = Title,
                Version = version
            };
            return info;
        }
    }
}
