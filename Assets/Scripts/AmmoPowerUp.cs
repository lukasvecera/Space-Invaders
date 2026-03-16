using UnityEngine;

public class AmmoPowerUp : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public float duration = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.powerup);
            Shooting shooting = other.GetComponent<Shooting>();
            if (shooting != null)
            {
                shooting.ActivateInfiniteAmmo(duration);
            }

            Destroy(gameObject);
        }
    }
}
