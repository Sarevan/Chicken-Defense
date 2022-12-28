using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Bars
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TextMeshProUGUI textHealthValue;

        public TextMeshProUGUI TextHealthValue => textHealthValue;
        
        public void SetMaxHealth(float health)
        {
            slider.maxValue = health;
            slider.value = health;
        }

        public void SetHealth(float health)
        {
            slider.value = health;
        }
    }
}