using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool pressForward = Input.GetKey(KeyCode.UpArrow);
        bool pressBack = Input.GetKey(KeyCode.DownArrow);
        
        if (pressForward || pressBack)//E�er W veya S tu�una bas�l�yorsa;
        {
            float vertical = Input.GetAxis("Vertical");
            
            rb.velocity = new Vector2(0, vertical * speed);
            //Topu dikey y�nde yukar� ve a�a�� hareket ettir.
        }
        if (!(pressForward || pressBack ))//E�er W veya S tu�una bas�lm�yorsa;
        {
            rb.velocity = new Vector2(0, 0);
            //Topun hareketini durdur.S�rekli hareket halinde olmay� engellemek i�in.
        }
    }
}
