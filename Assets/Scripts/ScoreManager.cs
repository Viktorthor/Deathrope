using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    PhotonView view;
    public TextMeshProUGUI scoreDisplay;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void AddScore()
    {
        view.RPC("AddScoreRPC", RpcTarget.All);
    }

    [PunRPC]
    void AddScoreRPC()
    {
        score++;
        scoreDisplay.text = "Score:" + score.ToString();
    }


}
