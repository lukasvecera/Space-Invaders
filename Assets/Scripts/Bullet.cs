using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bullSpeed = 10f;
    public float bullDamage = 10f;
    public float healthPig = 20f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        Vector2 force = transform.up * bullSpeed;
        rb.AddForce(force, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
