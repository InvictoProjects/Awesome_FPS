using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player.Characteristics
{
    public class PlayerHealth : HealthSystem
    {
        [SerializeField] private Volume _volume;
        public override void Die()
        {
            base.Die();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public override void Damage(float amount)
        {
            base.Damage(amount);
            _volume.GetComponent<Vignette>().active = true;
        }
    }
}
