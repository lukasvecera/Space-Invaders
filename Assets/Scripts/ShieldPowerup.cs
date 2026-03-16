using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    public float duration = 5f;
    AudioManager audioManager;

    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.powerup);
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.shieldDuration = duration;
                player.ActivateShield();
            }

            Destroy(gameObject);
        }
    }
}
