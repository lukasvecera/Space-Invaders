using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 25;
    AudioManager audioManager;

    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                audioManager.PlaySFX(audioManager.hit);
                player.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
