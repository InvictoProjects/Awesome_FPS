using Assets.Scripts.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthImage;
        [SerializeField] private Image damageImage;
        [SerializeField] private EnemyHealth health;

        private void Awake()
        {
            health.OnHealthChanged += HealthBar_OnHealthChanged;
            health.OnDeath += Health_OnDeath;
            damageImage.fillAmount = healthImage.fillAmount;
        }

        private void Health_OnDeath()
        {
            gameObject.SetActive(false);
        }

        private void HealthBar_OnHealthChanged(float percentage)
        {
            ChangeImageToPercentage(percentage);
        }

        private void ChangeImageToPercentage(float percentage)
        {
            healthImage.fillAmount = percentage;
        }
    }
}
