using NAudio.Wave;

//namespace SpeakerAwake


namespace SpeakerAwake
{
    public class AudioEngine
    {
        private readonly WaveOutEvent _waveOut;
        private readonly SineWaveProvider _waveProvider;
        public bool IsPlaying { get; private set; }
        public int FrequencyHz { get; private set; }
        public float VolumePercent { get; private set; }

        public AudioEngine(int frequencyHz, float volumePercent)
        {
            FrequencyHz = frequencyHz;
            VolumePercent = volumePercent;

            _waveProvider = new SineWaveProvider()
            {
                Frequency = FrequencyHz,
                Volume = VolumePercent
            };
            _waveOut = new WaveOutEvent
            {
                DesiredLatency = 300
            };
            _waveOut.Init(_waveProvider);
        }

        public void Start()
        {
            if (!IsPlaying)
            {
                _waveOut.Play();
                IsPlaying = true;
            }
        }

        public void Stop()
        {
            if (IsPlaying)
            {
                _waveOut.Stop();
                IsPlaying = false;
            }
        }

        public void SetFrequency(int frequencyHz)
        {
            FrequencyHz = frequencyHz;
            _waveProvider.Frequency = frequencyHz;
        }

        public void SetVolume(float volumePercent)
        {
            VolumePercent = volumePercent;
            _waveProvider.Volume = volumePercent;
        }
    }

    public class SineWaveProvider : WaveProvider32
    {
        public float Frequency { get; set; }
        public float Volume { get; set; } // 0.0 to ~0.05 or so for very low volume

        private int _sample;

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int n = 0; n < sampleCount; n++)
            {
                float sample = (float)(Volume * Math.Sin(2 * Math.PI * _sample * Frequency / WaveFormat.SampleRate));
                buffer[n + offset] = sample;
                _sample++;
                if (_sample >= WaveFormat.SampleRate)
                {
                    _sample = 0;
                }
            }
            return sampleCount;
        }
    }
}
