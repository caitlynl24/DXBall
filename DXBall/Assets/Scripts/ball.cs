using UnityEngine;

public class ball_cs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
    void Start()
    {
       rb=GetComponent<Rigidbody2D>();
       //(1,1)
       direction=Vector2.one.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity=direction*speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("paddle"))
        {
            direction.y = -direction.y;
        }

        else if(collision.gameObject.CompareTag("brick"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
        }

        else if(collision.gameObject.CompareTag("wall"))
        {
            direction.x = -direction.x;
        }

        else if(collision.gameObject.CompareTag("ceiling"))
        {
            direction.y = -direction.y;
        }
    }
}
