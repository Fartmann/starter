using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int winningScore = 10;
    public TMP_Text player1text;
    public TMP_Text player2text;
    public TMP_Text winMessage;

    private static int player1score;
    private static int player2score;

    public static bool playing;

    // Start is called before the first frame update
    void Start()
    {
        winMessage.transform.parent.gameObject.SetActive(false);

        player1score = 0;
        
        player2score = 0;
        
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        player1text.text = player1score.ToString();
        player2text.text = player2score.ToString();

        if (player1score >= winningScore) 
        {
            winMessage.text = "PLAYER 1\nWINS!";
            winMessage.transform.parent.gameObject.SetActive(true);
        }
        else if (player2score >= winningScore) 
        {
            winMessage.text = "PLAYER 2\nWINS!";
            winMessage.transform.parent.gameObject.SetActive(true);
        }
    }

    public static void AddScore(int player)
    {
        if (player == 1)
        {
            player1score++;
            if (player1score == winningScore) 
            {
                playing = false;
            }
        }
        else if (player == 2)
        {
            player2score++;
            if (player2score == winningScore) 
            { 
                playing = false;
            }
        }
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
    }
}
