using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    public GameObject playButton;
    public GameObject cancelButton;

    private void Awake()
    {
        lobby = this; // For the singleton, lives within the main menu screen.
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the Master server.");
        playButton.SetActive(true);
    }

    public void OnPlayButtonClick()
    {
        playButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnCancelButtonClick()
    {
        cancelButton.SetActive(false);
        playButton.SetActive(true);

        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("Failed to join a random room.");
        CreateRoom();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("Couldn't create a new room.");
        CreateRoom();
    }

    void CreateRoom()
    {
        string randomRoomName = "Room " + DateTime.UtcNow.ToString();
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 12 };
        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
