using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unifi.Annotations;
using UnifiCommands;

namespace Unifi
{

    /// <summary>
    /// Class that represents settings to save to Settings.json
    /// </summary>
    internal class ProgramSettings : INotifyPropertyChanged
    {
        private Venue _venue = Venue.R01;

        public Venue Venue
        {
            get => _venue;
            set
            {
                if (value != _venue)
                {
                    _venue = value;
                    OnPropertyChanged(nameof(Venue));
                }
            }
        }

        private bool _isDebugMode;

        public bool IsDebugMode
        {
            get => _isDebugMode;
            set
            {
                if (value != _isDebugMode)
                {
                    _isDebugMode = value;
                    OnPropertyChanged(nameof(IsDebugMode));
                }
            }
        }

        private string _installDirectory = Variables.DefaultInstallFolder;
        public string InstallDirectory
        {
            get => _installDirectory;
            set
            {
                if (value != _installDirectory)
                {
                    _installDirectory = value;
                    OnPropertyChanged(nameof(InstallDirectory));
                }
            }
        } 

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    internal class SettingsHelper
    {
        public static ProgramSettings LoadSettings()
        {
            if (!File.Exists(Variables.ProgramSettingFilePath))
            {
                return new ProgramSettings();
            }

            string json = File.ReadAllText(Variables.ProgramSettingFilePath);
            
            try
            {
                return JsonConvert.DeserializeObject<ProgramSettings>(json, new StringEnumConverter());
            }
            catch 
            {
                return new ProgramSettings();
            }
        }

        public static void SaveSettings(ProgramSettings programSettings)
        {
            string json = JsonConvert.SerializeObject(programSettings);
            File.WriteAllText(Variables.ProgramSettingFilePath, json);
        }
    }


    internal enum Venue
    {
        R01,
        R02,
        QA2
    }
}
 