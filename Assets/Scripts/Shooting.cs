using System.Collections;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPref;
    public Transform muzzle;

    public int maxAmmo = 6;
    private int currentAmmo;

    public TMP_Text ammoText;       // UI text pro náboje
    public TMP_Text reloadText;     // UI text pro "Reloading..."

    public float reloadTime = 1.5f;
    private bool isReloading = false;

    private bool infiniteAmmo = false;
    private float powerupTimer = 0f;
    public TMP_Text powerupText; // text "No reload!"

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }

    private void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
        reloadText.gameObject.SetActive(false); // skrýt na začátku
    }

    void Update()
    {
        if (isReloading) return;

        if (Input.GetKeyDown(KeyCode.Space) && !isReloading && (currentAmmo > 0 || infiniteAmmo))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        if (infiniteAmmo)
        {
            powerupTimer -= Time.deltaTime;
            if (powerupTimer <= 0)
            {
                infiniteAmmo = false;
                powerupText.gameObject.SetActive(false);
            }
        }
    }

    private void Shoot()
    {
            audioManager.PlaySFX(audioManager.shooting);
        if (!infiniteAmmo)
        {
            audioManager.PlaySFX(audioManager.shooting);
            currentAmmo--;
            UpdateAmmoUI();
        }
        GameObject bullet = Instantiate(bulletPref, muzzle.position, muzzle.rotation);
        Destroy(bullet, 3f);

    }

    private IEnumerator Reload()
    {
        audioManager.PlaySFX(audioManager.reload);
        isReloading = true;
        reloadText.gameObject.SetActive(true); // zobraz zprávu

        yield return new WaitForSeconds(reloadTime); // čekej

        currentAmmo = maxAmmo;
        reloadText.gameObject.SetActive(false); // skryj zprávu
        UpdateAmmoUI();

        isReloading = false;
    }

    private void UpdateAmmoUI()
    {
        if (ammoText != null)
        {
            ammoText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
        }
    }

    public void ActivateInfiniteAmmo(float duration)
    {
        infiniteAmmo = true;
        powerupTimer = duration;
        powerupText.gameObject.SetActive(true);
        powerupText.text = "NO RELOAD!";
    }
}
