using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
