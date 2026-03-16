using UnityEngine;

public class GhostDeath : MonoBehaviour
{
    private Animator animator;
    private bool isDead = false;
    private Collider2D col;

    AudioManager audioManager;

    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("bullet"))
        {
            isDead = true;
            audioManager.PlaySFX(audioManager.dead);
            animator.SetBool("IsAlive", false);
            Debug.Log("SetBool se provedl");

            if (col != null) col.enabled = false;

            Destroy(collision.gameObject);

        }
    }


    public void DestroyAfterAnimation()
    {
        Destroy(gameObject);
    }
}
