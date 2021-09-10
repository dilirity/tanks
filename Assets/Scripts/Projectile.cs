using UnityEngine.Tilemaps;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject brickGameObject;
    GameObject steelGameObject;
    Rigidbody2D rb2d;
    Tilemap tilemap;

    public int speed = 1;
    public bool destroySteel = false;

    bool toBeDestroyed = false;

    void OnEnable()
    {
        if (rb2d != null)
        {
            rb2d.velocity = transform.up * speed;
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;

        brickGameObject = GameObject.FindGameObjectWithTag("Brick");
        steelGameObject = GameObject.FindGameObjectWithTag("Steel");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
        tilemap = collision.gameObject.GetComponent<Tilemap>();
        if ((collision.gameObject == brickGameObject) || (destroySteel && collision.gameObject == steelGameObject))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }

            this.gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        if (toBeDestroyed)
        {
            Destroy(this.gameObject);
        }
    }

    public void DestroyProjectile()
    {
        if (gameObject.activeSelf == false)
        {
            Destroy(this.gameObject);
        }
        toBeDestroyed = true;
    }
}
