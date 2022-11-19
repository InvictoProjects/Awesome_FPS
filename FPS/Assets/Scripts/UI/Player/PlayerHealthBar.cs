using Assets.Scripts.Player.Characteristics;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;
        [SerializeField] private Image _damageImage;
        [SerializeField] private PlayerHealth _health;

        private const float _damageTimerMax = 1f;
        private float _damageTimer;

        private void Awake()
        {
            _health.OnHealthDamaged += HealthBar_OnHealthDamaged;
            _health.OnHealthHealed += HealthBar_OnHealthHealed;

            _damageImage.fillAmount = _healthImage.fillAmount;
        }

        private void HealthBar_OnHealthDamaged(float percentage)
        {
            ResetDamageTimer();
            ChangeImageToPercentage(percentage);
        }

        private void HealthBar_OnHealthHealed(float percentage)
        {
            ChangeImageToPercentage(percentage);
            _damageImage.fillAmount = _healthImage.fillAmount;
        }

        private void Update()
        {
            ShrinkBar();
        }

        private void ShrinkBar()
        {
            _damageTimer -= Time.deltaTime;
            if (_damageTimer < 0 && _healthImage.fillAmount < _damageImage.fillAmount)
            {
                float shrinkSpeed = 1f;
                _damageImage.fillAmount -= shrinkSpeed * Time.deltaTime;
            }
        }

        private void ResetDamageTimer()
        {
            _damageTimer = _damageTimerMax;
        }

        private void ChangeImageToPercentage(float percentage)
        {
            _healthImage.fillAmount = percentage;
        }
    }
}
