using UnityEngine;

public class ball_cs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
    public int brickCount = 0;
    public scoreScript score;

    void Start()
    {
       rb=GetComponent<Rigidbody2D>();
       //(1,1)
       direction=Vector2.one.normalized;
       score = GameObject.FindGameObjectWithTag("logic").GetComponent<scoreScript>();
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
            brickCount = brickCount + 1;
            //1 means score happened
            score.addScore(1);
            Debug.Log("Bricks destroyed: " + brickCount);
        }

        else if(collision.gameObject.CompareTag("sideWall"))
        {
            direction.x = -direction.x;
        }

        else if(collision.gameObject.CompareTag("topWall"))
        {
            direction.y = -direction.y;
        }

        else if(collision.gameObject.CompareTag("bottomWall"))
        {
            Debug.Log("Game over");
            gameObject.SetActive(false);
            //0 means game over
            score.addScore(0);
        }
    }
}
