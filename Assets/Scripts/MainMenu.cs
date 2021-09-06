using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MainMenu : MonoBehaviourPunCallbacks
{

    public InputField createInput;
    public InputField joinInput;
    public InputField nickNameInput;

    public void CreateRoom()
    {
        RoomOptions roomInfo = new RoomOptions();
        roomInfo.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(createInput.text, roomInfo);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void SetNickname()
    {
        PhotonNetwork.NickName = nickNameInput.text;
    }

}
