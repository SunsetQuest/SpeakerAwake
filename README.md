# Speaker Awake

**Speaker Awake** is a lightweight Windows system tray application that continuously plays a very low-volume, low-frequency sine wave tone to prevent speakers from automatically turning off due to inactivity. This ensures that your audio hardware remains responsive and avoids delays or missing audio fragments when new sounds start playing.

This application was generated with the help of ChatGPT.

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

### Custom Icons and Resources

 - If you encounter issues with icons or resources, you can manually set the tray icon in TrayIcon.cs.
 - Ensure that any custom icons (SpeakerAwakeIcon and SpeakerAwakeIconPaused) are added to your project resources and referenced in the code.

## Notes and Troubleshooting

 - Since the volume is extremely low, you should not hear the tone under normal conditions. If you do, try lowering the volume or choosing a frequency that is less audible.
 - If your speakers still sleep at the chosen frequency and volume, try adjusting the frequency upwards until it prevents sleep.
 - If the tray icon doesn't appear, ensure that the application isn't blocked by your system or antivirus. Also, double-check .NET dependencies.

## Credits

 - **Developer:** Solution generated and refined with the assistance of ChatGPT.
 - **Libraries:** Uses [NAudio](https://github.com/naudio/NAudio) for audio output.

**Speaker Awake** is provided as-is, with no warranty or guarantee of its effectiveness for all hardware setups. Your mileage may vary.
