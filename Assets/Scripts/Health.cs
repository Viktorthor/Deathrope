using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Health : MonoBehaviour
{
    public int health = 10;
    public TextMeshProUGUI healthDisplay;

    PhotonView view;
    public GameObject gameOver;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        Time.timeScale = 1.0f;
        PhotonNetwork.MinimalTimeScaleToDispatchInFixedUpdate = 0f;
    }

    public void TakeDamage()
    {
        view.RPC("TakeDamageRPC", RpcTarget.All);
    }

    [PunRPC]
    void TakeDamageRPC()
    {
        if (health <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0.0f;
        }

        healthDisplay.text = "Health: " + health.ToString();
        health -= 1;
        
    }
}
