using UnityEngine;

namespace Assets.Scripts.UI
{
    public class Billboard : MonoBehaviour
    {
        private Transform cam;

        private void Start()
        {
            cam = Camera.main.transform;
        }

        void LateUpdate()
        {
            transform.LookAt(transform.position + cam.forward);
        }
    }
}
