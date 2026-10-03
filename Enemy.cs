using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    void Start()
    {

    }

    void Update()
    {
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Laser"))
        {
            health -= 25;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}