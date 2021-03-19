using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using CanetisRadar2.Annotations;
using CanetisRadar2.Audio;

namespace CanetisRadar2.View
{
    public sealed class ColoredSpeakers : INotifyPropertyChanged
    {
        private readonly Speakers _speakers;
        private const float Amplifier = 1f;

        public ColoredSpeakers(Speakers speakers)
        {
            _speakers = speakers;

            _speakers.Speaker1.PropertyChanged += (_, _) => OnPropertyChanged(nameof(ColorSpeakerLeftTop));
            _speakers.Speaker2.PropertyChanged += (_, _) => OnPropertyChanged(nameof(ColorSpeakerRightTop));
            _speakers.Speaker3.PropertyChanged += (_, _) => OnPropertyChanged(nameof(ColorSpeakerLeftTop));
            _speakers.Speaker3.PropertyChanged += (_, _) => OnPropertyChanged(nameof(ColorSpeakerRightTop));
            _speakers.Speaker5.PropertyChanged += (_, _) => OnPropertyChanged(nameof(ColorSpeakerLeftBottom));
            _speakers.Speaker6.PropertyChanged += (_, _) => OnPropertyChanged(nameof(ColorSpeakerRightBottom));
            _speakers.Speaker7.PropertyChanged += (_, _) => OnPropertyChanged(nameof(ColorSpeakerLeftCenter));
            _speakers.Speaker8.PropertyChanged += (_, _) => OnPropertyChanged(nameof(ColorSpeakerRightCenter));
        }

        public Brush ColorSpeakerLeftTop =>
            _gradient.At(Math.Max(_speakers.Speaker1, _speakers.Speaker3) * Amplifier).toBrush();

        public Brush ColorSpeakerLeftCenter =>
            _gradient.At(_speakers.Speaker7 * Amplifier).toBrush();

        public Brush ColorSpeakerLeftBottom =>
            _gradient.At(_speakers.Speaker5 * Amplifier).toBrush();

        public Brush ColorSpeakerRightTop =>
            _gradient.At(Math.Max(_speakers.Speaker2, _speakers.Speaker3) * Amplifier).toBrush();

        public Brush ColorSpeakerRightCenter =>
            _gradient.At(_speakers.Speaker8 * Amplifier).toBrush();

        public Brush ColorSpeakerRightBottom =>
            _gradient.At(_speakers.Speaker6 * Amplifier).toBrush();

        private readonly ColorGradient _gradient = new(new[]
        {
            new ColorGradient.ColorRange(0, 0.005f, Colors.White, Colors.White),
            new ColorGradient.ColorRange(0.005f, 0.60f, Colors.Yellow, Colors.Red),
            new ColorGradient.ColorRange(0.60f, 1, Colors.Red, Colors.Red)
        });

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public static class ColorExtension
    {
        public static Brush toBrush(this Color c)
        {
            return new SolidColorBrush {Color = c};
        }
    }
}