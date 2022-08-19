using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float zaman;
    public ball top;
    public int player1Score;
    public int player2Score;
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;
    public TextMeshProUGUI time;
    float randomBallPossValue;
    Vector2 randomBallPoss;
    public GameObject gameOver;
    public bool oyunDurdumu = false;
    void FixedUpdate()
    {
        
        zaman -= Time.deltaTime;
        int zamanInt = (int)zaman;
        //Debug.Log("Zaman:" + zamanInt);
        time.SetText(zamanInt.ToString());
        if (zaman <= 0.0f)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;

            if (player1Score>player2Score) {
                Debug.Log("Player 1 Kazanadý");
            }
            if (player1Score == player2Score)
            {
                Debug.Log("Berabere");
            }
            else
            {
                Debug.Log("Player2 Kazandý");
            }
        }
    }
    public void Player1Score()
    {
        Debug.Log("Player1 artý");
        player1Score++;
        player1.SetText(player1Score.ToString());
        top.transform.position = Vector2.zero;
        float speed = top.speed;
        Debug.Log(top.speed.ToString());
        randomBallPossValue = Random.Range(0f, 260f);
        randomBallPoss = new Vector2(Mathf.Cos(randomBallPossValue), Mathf.Sin(randomBallPossValue));
        top.GetComponent<Rigidbody2D>().velocity = randomBallPoss * speed;
        //top.GetComponent<Rigidbody2D>().velocity = Vector2.right*speed;
    }
    public void Player2Score()
    {
        player2Score++;
        player2.SetText(player2Score.ToString());
        top.transform.position = Vector2.zero;
        float speed = top.speed;
        //Debug.Log(top.speed.ToString());
        randomBallPossValue = Random.Range(0f, 260f);
        randomBallPoss = new Vector2(Mathf.Cos(randomBallPossValue), Mathf.Sin(randomBallPossValue));
        top.GetComponent<Rigidbody2D>().velocity = randomBallPoss * speed;
        //top.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }

    public void PauseGame()
    {
        
        if (Input.GetKey(KeyCode.P))
        {
            oyunDurdumu = !oyunDurdumu;
            
        }
        if (oyunDurdumu == true)//Oyun durdurma kodu çalýþmadý.
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }
}
