using System;
using NAudio.CoreAudioApi;

namespace CanetisRadar2.Audio
{
    public sealed class Speakers
    {
        private readonly MMDevice _device;

        public readonly Speaker Speaker1 = new Speaker();
        public readonly Speaker Speaker2 = new Speaker();
        public readonly Speaker Speaker3 = new Speaker();
        public readonly Speaker Speaker4 = new Speaker();
        public readonly Speaker Speaker5 = new Speaker();
        public readonly Speaker Speaker6 = new Speaker();
        public readonly Speaker Speaker7 = new Speaker();
        public readonly Speaker Speaker8 = new Speaker();

        public Speakers()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            _device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
        }

        public void Update()
        {
            if (_device.AudioMeterInformation.PeakValues.Count != 8)
                throw new Exception("Duh 7.1 plz");

            Speaker1.Value = _device.AudioMeterInformation.PeakValues[0];
            Speaker2.Value = _device.AudioMeterInformation.PeakValues[1];
            Speaker3.Value = _device.AudioMeterInformation.PeakValues[2];
            Speaker4.Value = _device.AudioMeterInformation.PeakValues[3];
            Speaker5.Value = _device.AudioMeterInformation.PeakValues[4];
            Speaker6.Value = _device.AudioMeterInformation.PeakValues[5];
            Speaker7.Value = _device.AudioMeterInformation.PeakValues[6];
            Speaker8.Value = _device.AudioMeterInformation.PeakValues[7];
        }
    }
}