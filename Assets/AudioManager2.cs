using UnityEngine;

public class AudioManager2 : MonoBehaviour
{

    public static AudioClip point;
    public static AudioClip hit;
    public static AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayPoint() {
        audioSource.clip = point;
        audioSource.Play();
    }

    public static void PlayHit() {
        audioSource.clip = hit;
        audioSource.Play();
    }
}
