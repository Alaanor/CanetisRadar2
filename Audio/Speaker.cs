using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CanetisRadar2.Annotations;

namespace CanetisRadar2.Audio
{
    public class Speaker : INotifyPropertyChanged
    {
        // How many time in second the value will stay at his highest value
        // 
        // Why ? to highlight the sound direction at their highest, so it give
        // me this time to read the information in the middle of a fight.
        private const double HighestDelayTime = 1d;

        private float _value;
        private DateTime _nextThresholdTime = DateTime.Now;

        public float Value
        {
            get => _value;
            set
            {
                if (value < _value && DateTime.Now <= _nextThresholdTime)
                    return;
                
                if (value > _value)
                    _nextThresholdTime = DateTime.Now.AddSeconds(HighestDelayTime);

                _value = value;
                OnPropertyChanged();
            }
        }

        public static implicit operator float(Speaker s) => s._value;

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}