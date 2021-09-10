using UnityEngine;
public class Player : Movement
{
    float h, v;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (h != 0 && !isMoving) StartCoroutine(MoveHorizontal(h, rb2d));
        else if (v != 0 && !isMoving) StartCoroutine(MoveVertical(v, rb2d));
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }
}