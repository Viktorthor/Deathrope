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

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void TakeDamage()
    {
        view.RPC("TakeDamageRPC", RpcTarget.All);
    }
    [PunRPC]
    void TakeDamageRPC()
    {
        health -= 1;
        healthDisplay.text = "Health: " + health.ToString();
    }
}
