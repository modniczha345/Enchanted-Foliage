using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifetime;

    void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }

    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        CancelInvoke("DestroyFireball");
        DestroyFireball();
    }

    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
