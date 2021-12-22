using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hades
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private Slider healthBar;

        public void OnHealthEvent(int health, int maxHealth)
        {
            if (healthText != null) healthText.text = $"{health}/{maxHealth}";
            if (healthBar != null) healthBar.value = (float)health / maxHealth;
        }
    }
}