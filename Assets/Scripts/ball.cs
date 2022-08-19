using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ball : MonoBehaviour
{
    public GameManager gameManager;
    public float speed;
    public GameObject racket;
    public AudioSource ballSound;
    void Start()
    {
        float random = Random.Range(0f, 260f);
        Vector2 deneme= new Vector2(Mathf.Cos(random), Mathf.Sin(random));
        GetComponent<Rigidbody2D>().velocity =deneme*speed;
    }
    
    
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    // Update is called once per frame
    void Update()
    {
        hitFactor(this.transform.position, racket.transform.position, 1);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Racket?
        if (col.gameObject.name == "Player1")
        {
            ballSound.Play();
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "Player2")
        {
            ballSound.Play();
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "sagduvar")
        {
            //Debug.Log("sagduvara çarptý");
            gameManager.Player1Score();
        }
        if (collision.gameObject.name == "solduvar")
        {
            //Debug.Log("solduvara çarptý");
            gameManager.Player2Score();
        }
    }
}
