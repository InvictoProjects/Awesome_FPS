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
            health.OnCurrentHealthChanged += HealthBar_OnCurrentHealthChanged;
            health.OnDead += Health_OnDead;
            damageImage.fillAmount = healthImage.fillAmount;
        }

        private void Health_OnDead()
        {
            gameObject.SetActive(false);
        }

        private void HealthBar_OnCurrentHealthChanged(float percentage, float currentHealth)
        {
            ChangeImageToPercentage(percentage);
        }

        private void ChangeImageToPercentage(float percentage)
        {
            healthImage.fillAmount = percentage;
        }
    }
}
