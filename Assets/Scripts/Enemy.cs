using UnityEngine;
using Photon.Pun;
public class Enemy : MonoBehaviour
{

    PlayerController[] players;
    PlayerController nearestPlayer;
    float speed;
    ScoreManager score;
    Spawner gameManager;
    PhotonView view;

    public GameObject deathFX;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        players = FindObjectsOfType<PlayerController>();
        score = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<Spawner>();
    }

    private void Update()
    {
        speed = gameManager.enemySpeed;

        float distanceOne = Vector2.Distance(transform.position, players[0].transform.position);
        float distanceTwo = Vector2.Distance(transform.position, players[1].transform.position);

        if(distanceOne < distanceTwo)
        {
            nearestPlayer = players[0];
        } else
        {
            nearestPlayer = players[1];
        }

        if(nearestPlayer != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, nearestPlayer.transform.position, speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (collision.tag == "Tether")
            {
                score.AddScore();
                view.RPC("SpawnFX", RpcTarget.All);
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }

    [PunRPC]
    void SpawnFX()
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);
    }
}
