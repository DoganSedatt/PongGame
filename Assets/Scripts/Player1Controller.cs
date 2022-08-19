using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player1Controller : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    //Vector3 eski;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       //eski =this.transform.localScale;
       //DOTween.Init();
    }
    //IEnumerator Scaling()
    //{
    //    //Debug.Log("Player1 Scale:" + this.transform.localScale);
    //    this.transform.localScale = new Vector3(0.5f, 10, 1);
    //    yield return new WaitForSeconds(1);
    //    this.transform.localScale = eski;
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(Input.GetKey(KeyCode.Space)) StartCoroutine("Scaling");

        bool pressW = Input.GetKey(KeyCode.W);
        bool pressS = Input.GetKey(KeyCode.S);

        if (pressW || pressS)//Eðer W veya S tuþuna basýlýyorsa;
        {
            float vertical = Input.GetAxis("Vertical");

            rb.velocity = new Vector2(0, vertical * speed);
            //Topu dikey yönde yukarý ve aþaðý hareket ettir.
        }
        if (!(pressS || pressW))//Eðer W veya S tuþuna basýlmýyorsa;
        {
            rb.velocity = new Vector2(0, 0);
            //Topun hareketini durdur.Sürekli hareket halinde olmayý engellemek için.
        }
        //float vertical = Input.GetAxis("Vertical");//Yukarý aþaðý tuþlarýný kontrol eder
        //float hor = Input.GetAxis("Horizontal");
        //Vector2 v = new Vector2(hor*speed, vertical*speed);
        //rb.velocity = v;

    }
}
