﻿using Microsoft.Extensions.Configuration;
using Syrx.Extensions;
using static Syrx.Validation.Contract;

namespace Syrx.Commanders.Databases.Settings.Extensions.Json
{
    public static class UseFileExtensions
    {
        public static SyrxBuilder UseFile(this SyrxBuilder factory, string fileName, IConfigurationBuilder builder)
        {
            Throw<ArgumentNullException>(builder != null, $"ConfigurationBuilder is null! Check bootstrap.");
            Throw<ArgumentNullException>(!string.IsNullOrWhiteSpace(fileName), nameof(fileName));

            builder?.AddJsonFile(fileName);

            return factory;
        }
    }
}