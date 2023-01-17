using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;


public class GameManager : MonoBehaviourPunCallbacks
{

    public static GameManager instance;
    public static int player1Score = 0;
    public static int player2Score = 0;
    public TextMeshProUGUI text1Score, text2Score;
    public static GameObject goalScreen;


    private void Awake()
    {   
        SetScoreText();
        // Survive between reloading of the scene
        instance = this;
    }

    void SetScoreText()
    {
        text1Score.text = player1Score.ToString();
        text2Score.text = player2Score.ToString();
    }

    void Update()
    {
        SetScoreText();
    }

}
