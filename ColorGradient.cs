using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace CanetisRadar2
{
    public class ColorGradient
    {
        private readonly IEnumerable<ColorRange> _colors;

        public ColorGradient(IEnumerable<ColorRange> colors)
        {
            _colors = colors;
        }

        public Color At(float value)
        {
            foreach (ColorRange color in _colors)
                if (color.IsInRange(value))
                    return color.Get(value);

            return Colors.Black;
        }

        public class ColorRange
        {
            private readonly float _min;
            private readonly float _max;
            private readonly Color _start;
            private readonly Color _end;

            public ColorRange(float min, float max, Color start, Color end)
            {
                _min = min;
                _max = max;
                _start = start;
                _end = end;
            }

            public bool IsInRange(float target)
            {
                return _min <= target && target < _max;
            }

            public Color Get(float target)
            {
                return Lerp(_start, _end, (target - _min) / (_max - _min));
            }

            private static Color Lerp(Color a, Color b, float t)
            {
                t = Clamp01(t);
                return Color.FromArgb(
                    (byte) (a.A + (b.A - a.A) * t * 255),
                    (byte) (a.R + (b.R - a.R) * t * 255),
                    (byte) (a.G + (b.G - a.G) * t * 255),
                    (byte) (a.B + (b.B - a.B) * t * 255)
                );
            }

            private static float Clamp01(float value)
            {
                return value switch
                {
                    < 0F => 0F,
                    > 1F => 1F,
                    _ => value
                };
            }
        }
    }
}