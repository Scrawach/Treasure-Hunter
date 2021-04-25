using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class Music : MonoBehaviour
    {
        private const string VolumeName = "Volume";
        
        public Slider Slider;
        public AudioMixer Mixer;

        private bool _volumeOff;
        private float _lastValue;

        private void Awake()
        {
            _lastValue = -15f;
        }

        private void OnEnable()
        {
            Slider.onValueChanged.AddListener(OnValueChanged);

            Mixer.GetFloat(VolumeName, out float value);
            Slider.value = value;
        }

        private void OnDisable()
        {
            Slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnToggleClicked()
        {
            if (_volumeOff)
            {
                _volumeOff = false;
                Mixer.SetFloat(VolumeName, _lastValue);
            }
            else
            {
                _volumeOff = true;
                
                Mixer.SetFloat(VolumeName, -80f);
            }
        }

        private void OnValueChanged(float arg0)
        {
            _lastValue = arg0;
            
            if (_volumeOff)
            {
                return;
            }

            Mixer.SetFloat(VolumeName, arg0);
        }
    }
}