using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameOver : MonoBehaviour
{

    public Text scoreText;
    public GameObject restartButton;
    public GameObject waitingText;
    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        scoreText.text = "Final score: " + FindObjectOfType<ScoreManager>().score.ToString();

        if(PhotonNetwork.IsMasterClient == false)
        {
            restartButton.SetActive(false);
            waitingText.SetActive(true);
        }
    }

    public void OnClickRestart()
    {
        view.RPC("Restart", RpcTarget.All);
    }

    [PunRPC]
    void Restart()
    {
        PhotonNetwork.LoadLevel("Game");
        Time.timeScale = 1.0f;
    }

}
