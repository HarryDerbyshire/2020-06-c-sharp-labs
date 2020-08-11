using System;

namespace RadioApp
{
    public class Radio
    {
        private int _channel;
        private bool _on;
        public Radio(int channel = 1, bool on = false)
        {
            _channel = channel;
            _on = on;
        }

        public bool IsOn
        {
            get { return _on; }
            private set {; }
        }

        public int Channel
        {
            get { return _channel; }
            set { if ((value >= 1 && value <= 4) && _on == true) _channel = value; }
        }
        public string Play()
        {

            if (_on == true && (_channel >= 1 && _channel <= 4))
            {
 
                return $"Playing channel {_channel}";
            }

            return "Radio is off";
        }

        public void TurnOn()
        {
            _on = true;
        }

        public void TurnOff()
        {
            _on = false;
        }
    }
    // implement a class Radio that corresponds to the Class diagram 
    //   and specification in the Radio_Mini_Project document
}