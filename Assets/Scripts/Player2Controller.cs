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
        
        if (pressForward || pressBack)//Eðer W veya S tuþuna basýlýyorsa;
        {
            float vertical = Input.GetAxis("Vertical");
            
            rb.velocity = new Vector2(0, vertical * speed);
            //Topu dikey yönde yukarý ve aþaðý hareket ettir.
        }
        if (!(pressForward || pressBack ))//Eðer W veya S tuþuna basýlmýyorsa;
        {
            rb.velocity = new Vector2(0, 0);
            //Topun hareketini durdur.Sürekli hareket halinde olmayý engellemek için.
        }
    }
}
