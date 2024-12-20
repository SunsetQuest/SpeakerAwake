# Speaker Awake

**Speaker Awake** is a lightweight Windows system tray application that continuously plays a very low-volume, low-frequency sine wave tone to prevent speakers from automatically turning off due to inactivity. This ensures that your audio hardware remains responsive and avoids delays or missing audio fragments when new sounds start playing.

This works well with the Klipsch USB speakers and possibly other brands.

This application was generated with the help of ChatGPT.

![image](https://github.com/user-attachments/assets/a2b3feed-eeb8-4bdb-aec7-32e392904518)

This application has been tested with Klipsch USB speakers and should also work with various other brands and models. Even at extremely low amplitude and frequencies, the tone is generally inaudible, helping maintain your audio system’s readiness without introducing noticeable background noise.

## Features

 - **System Tray Integration:** Runs silently in the background from the Windows system tray.
 - **Low-Frequency, Low-Volume Tone:** Keeps speakers awake without producing an audible sound.
 - **Configurable Frequency and Volume:** Easily adjust frequency (5, 10, 15, 20, 30, or 50 Hz) and volume (0.5% to 5%).
 - **Pause Function:** Temporarily stop the tone if you want to save power or quiet the system.
 - **Persistent Settings:** Your selected frequency and volume are stored and reloaded on the next run.
 - **.NET 8 LTS:** Built using modern .NET LTS for longevity and stability.

## Getting Started

### Prerequisites

 - Windows 10 or later
 - .NET 8 Runtime installed
 - NAudio library (already referenced in the project)

### Installation

 - Clone or download the project.
 - Restore NuGet packages: dotnet restore
 - Build: dotnet build
 - Run: dotnet run

### Usage

 - On launch, the app will start minimized to the system tray.
 - The default tone is 20 Hz at 2% volume.
 - Right-click on the tray icon to access the context menu.
 - From the menu, you can:
   - **Pause/Resume:** Pause or resume the low-level tone.
   - **Frequency:** Select a preferred frequency.
   - **Volume:** Adjust the volume level.
   - **Exit:** Close the application.
 - Changes to frequency and volume are saved automatically, so they persist between sessions.
 - Add to your Startup folder to launch with Windows.

### Custom Icons and Resources

 - If you encounter issues with icons or resources, you can manually set the tray icon in TrayIcon.cs.
 - Ensure that any custom icons (SpeakerAwakeIcon and SpeakerAwakeIconPaused) are added to your project resources and referenced in the code.

## Notes and Troubleshooting

 - Since the volume is extremely low, you should not hear the tone under normal conditions. If you do, try lowering the volume or choosing a frequency that is less audible.
 - If your speakers still sleep at the chosen frequency and volume, try adjusting the frequency upwards until it prevents sleep.
 - If the tray icon doesn't appear, ensure that the application isn't blocked by your system or antivirus. Also, double-check .NET dependencies.

## Drawbacks
- **Increased Power Usage:** Speakers remain powered and ready, potentially increasing electricity consumption compared to letting them sleep.
- **Minor Resource Utilization:** The application consumes a slight amount of CPU and memory to generate and play the low-level tone.
- **Potentially Reduced Audio Quality:** Although this is unlikely to be perceptible, injecting even a minor signal into the audio channel could theoretically reduce audio fidelity. Most users, even audiophiles, should find this effect negligible at low amplitude and volume.
- **Platform Limitation:** Currently, this application is supported on Windows only

## Credits

 - **Developer:** Solution generated and refined with the assistance of ChatGPT.
 - **Libraries:** Uses [NAudio](https://github.com/naudio/NAudio) for audio output.

**Speaker Awake** is provided as-is, with no warranty or guarantee of its effectiveness for all hardware setups. Your mileage may vary.
