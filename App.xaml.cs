using System.Windows;

namespace SpeakerAwake
{
    public partial class App : Application
    {
        private TrayIcon? _trayIcon;
        private AudioEngine? _audioEngine;
        private SettingsManager? _settingsManager;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _settingsManager = new SettingsManager();
            Settings settings = _settingsManager.Load();

            _audioEngine = new AudioEngine(settings.FrequencyHz, settings.VolumePercent);
            _audioEngine.Start();

            _trayIcon = new TrayIcon(_audioEngine, _settingsManager);
            _trayIcon.Initialize();

            // Hide main window if it exists
            MainWindow window = new();
            window.Hide();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _audioEngine.Stop();
            _trayIcon.Dispose();
            base.OnExit(e);
        }
    }
}
