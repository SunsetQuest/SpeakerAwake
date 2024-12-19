using System.Drawing;
using System.IO;
using System.Windows.Forms; // Add reference to WindowsFormsIntegration and System.Windows.Forms
using Application = System.Windows.Application;

namespace SpeakerAwake
{
    public class TrayIcon : IDisposable
    {
        private readonly AudioEngine _audioEngine;
        private readonly SettingsManager _settingsManager;
        private readonly NotifyIcon _notifyIcon;
        private readonly Icon SpeakerAwakeIcon = new(new MemoryStream(Properties.Resources.SpeakerAwakeIcon));
        private readonly Icon SpeakerAwakeIconPaused = new(new MemoryStream(Properties.Resources.SpeakerAwakeIconPaused));

        public TrayIcon(AudioEngine audioEngine, SettingsManager settingsManager)
        {
            _audioEngine = audioEngine;
            _settingsManager = settingsManager;
            _notifyIcon = new NotifyIcon
            {
                Text = "Speaker Awake",
                Icon = SpeakerAwakeIcon, // Add a suitable icon as a resource
                Visible = true
            };
        }

        public void Initialize()
        {
            ContextMenuStrip contextMenu = new();

            // Pause/Resume
            ToolStripMenuItem pauseItem = new("Pause")
            {
                Checked = false
            };
            pauseItem.Click += (s, e) =>
            {
                if (_audioEngine.IsPlaying)
                {
                    _audioEngine.Stop();
                    pauseItem.Text = "Resume";
                    _notifyIcon.Icon = SpeakerAwakeIconPaused; // A red line icon version
                }
                else
                {
                    _audioEngine.Start();
                    pauseItem.Text = "Pause";
                    _notifyIcon.Icon = SpeakerAwakeIcon;
                }
            };
            _ = contextMenu.Items.Add(pauseItem);

            // Frequency menu
            ToolStripMenuItem freqMenu = new("Frequency");
            int[] freqs = new[] { 5, 10, 15, 20, 30, 50, 100 };
            foreach (int f in freqs)
            {
                ToolStripMenuItem freqItem = new($"{f} Hz")
                {
                    Checked = _audioEngine.FrequencyHz == f
                };
                freqItem.Click += (s, e) => SetFrequency(f, freqMenu);
                _ = freqMenu.DropDownItems.Add(freqItem);
            }
            _ = contextMenu.Items.Add(freqMenu);

            // Volume menu
            ToolStripMenuItem volMenu = new("Volume");
            (string Label, float Value)[] vols = new (string Label, float Value)[]
            {
                ("0.5%", 0.005f),("1%",0.01f),("2%",0.02f),("3%",0.03f),("4%",0.04f),("5%",0.05f),("10%",0.10f)
            };
            foreach ((string Label, float Value) v in vols)
            {
                ToolStripMenuItem volItem = new(v.Label)
                {
                    Checked = Math.Abs(_audioEngine.VolumePercent - v.Value) < 0.0001f
                };
                volItem.Click += (s, e) => SetVolume(v.Value, volMenu);
                _ = volMenu.DropDownItems.Add(volItem);
            }
            _ = contextMenu.Items.Add(volMenu);

            // Exit
            ToolStripMenuItem exitItem = new("Exit");
            exitItem.Click += (s, e) => Application.Current.Shutdown();
            _ = contextMenu.Items.Add(exitItem);

            _notifyIcon.ContextMenuStrip = contextMenu;
        }

        private void SetFrequency(int frequency, ToolStripMenuItem parentMenu)
        {
            foreach (ToolStripMenuItem item in parentMenu.DropDownItems)
            {
                item.Checked = false;
            }

            ToolStripMenuItem? selected = parentMenu.DropDownItems.OfType<ToolStripMenuItem>()
                .FirstOrDefault(i => i.Text == $"{frequency} Hz");
            if (selected != null)
            {
                selected.Checked = true;
            }

            _audioEngine.SetFrequency(frequency);
            _settingsManager.Save(_audioEngine.FrequencyHz, _audioEngine.VolumePercent);
        }

        private void SetVolume(float volume, ToolStripMenuItem parentMenu)
        {
            foreach (ToolStripMenuItem item in parentMenu.DropDownItems)
            {
                item.Checked = false;
            }

            string label = $"{volume * 100:0.##}%";
            ToolStripMenuItem? selected = parentMenu.DropDownItems.OfType<ToolStripMenuItem>()
                .FirstOrDefault(i => i.Text == label);
            if (selected != null)
            {
                selected.Checked = true;
            }

            _audioEngine.SetVolume(volume);
            _settingsManager.Save(_audioEngine.FrequencyHz, _audioEngine.VolumePercent);
        }

        public void Dispose()
        {
            _notifyIcon?.Dispose();
        }
    }
}
