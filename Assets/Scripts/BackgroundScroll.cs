using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Transform tilemap1;
    public Transform tilemap2;
    public float scrollSpeed = 0.5f;

    private float tilemapHeight;

    void Start()
    {
        // Spočítáme výšku z tilemapy 1
        var bounds = tilemap1.GetComponent<Renderer>().bounds;
        tilemapHeight = bounds.size.y;
    }

    void Update()
    {
        tilemap1.position += Vector3.down * scrollSpeed * Time.deltaTime;
        tilemap2.position += Vector3.down * scrollSpeed * Time.deltaTime;

        if (tilemap1.position.y <= -tilemapHeight)
        {
            tilemap1.position += Vector3.up * tilemapHeight * 2f;
        }

        if (tilemap2.position.y <= -tilemapHeight)
        {
            tilemap2.position += Vector3.up * tilemapHeight * 2f;
        }
    }
}
