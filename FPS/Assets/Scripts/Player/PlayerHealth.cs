using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player.Characteristics
{
    public class PlayerHealth : HealthSystem
    {
        public override void Die()
        {
            base.Die();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
