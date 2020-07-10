﻿using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MyVetNuske.Common.Helpers
{
    public class Settings
    {
        private const string _pet = "Pet";
        private static readonly string _settingsDefault = string.Empty;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string Pet
        {
            get => AppSettings.GetValueOrDefault(_pet, _settingsDefault);
            set => AppSettings.AddOrUpdateValue(_pet, value);
        }


    }
}
