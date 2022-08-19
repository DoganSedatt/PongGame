using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class top : MonoBehaviour
{
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;
    static int player1Score;
    static int player2Score;
    static GameObject topPrefab;
    static GameObject yeniTop;
    public AudioSource ballShoot;
    Vector2 baslangicPoz;
    private void Start()
    {
        baslangicPoz = this.transform.position;
        topPrefab = GameObject.FindGameObjectWithTag("top").gameObject;
        
    }
    void Update()
    {
        if (player1Score == 2 || player2Score == 2)
        {
            
            if (player1Score > player2Score)
            {
                Debug.Log("Player1 kazandý");
            }
            else
            {
                Debug.Log("Player2 kazandý");
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log("Çarpýlan nesne:"+collision.gameObject.name);
        
        if (collision.gameObject.name == "sagduvar")
        {
            Debug.Log("Score:" + player1Score);
            player1Score++;
            player1.SetText(player1Score.ToString());
            //this.transform.position = baslangicPoz;
            yeniTop= Instantiate(topPrefab, baslangicPoz, Quaternion.identity);
            if (yeniTop)
            {
                yeniTop.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,0.1f));

            }
            Debug.Log("Topun konumu:" + topPrefab.transform.position);
        }
        if (collision.gameObject.name == "solduvar")
        {
            Debug.Log("Score:" + player2Score);
            player2Score++;
            player2.SetText(player2Score.ToString());
            //this.transform.position = baslangicPoz;
            yeniTop = Instantiate(topPrefab, baslangicPoz, Quaternion.identity);
            if (yeniTop)
            {
                yeniTop.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0.1f));

            }
            Debug.Log("Topun konumu:" + topPrefab.transform.position);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1"|| collision.gameObject.name == "Player2")
        {
            Debug.Log("Topa çarptý");
            ballShoot.Play();
        }
    }
}
