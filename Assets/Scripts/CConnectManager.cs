using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.UI;

public class CConnectManager : _MonoBehaviour, IPunCallbacks
{
    public GameObject _startPanel;

    public InputField _nameInputField;
    public Button _connectButton;

    public Text _messageText;

    public static bool IsJoinedRoom = false;

    private void Awake()
    {
        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings("v1.0");
        }
    }

    private void Update()
    {
        _connectButton.interactable = IsJoinedRoom;
    }

    public void OnJoinedLobby()
    {
        _messageText.text = "Photon Cloud Lobby Connected...";

        PhotonNetwork.JoinOrCreateRoom(
            "Room",
            new RoomOptions()
            {
                MaxPlayers = 10,
                IsOpen = true,
                IsVisible = true
            },
            TypedLobby.Default
        );
    }

    public void OnJoinedRoom()
    {
        _messageText.text = "Photon Room Joined...";

        IsJoinedRoom = true;
    }

    public void OnCreatePhotonObjectBtnClick(string prefabName)
    {
        float posX = UnityEngine.Random.Range(-3.0f, 3.0f);
        float posZ = UnityEngine.Random.Range(0.0f, 3.0f);

        //GameObject playerPrefab = (GameObject)Resources.Load("Prefabs/Player");
        //Instantiate(playerPrefab, new Vector3(posX, 0.0f, posZ), Quaternion.identity);
        GameObject player = PhotonNetwork.Instantiate("Prefabs/Player", new Vector3(posX, 0.01f, posZ), Quaternion.identity, 0);

        CFollowCamera camera = Camera.main.GetComponent<CFollowCamera>();
        camera.Init(player.transform);

        _startPanel.SetActive(false);
    }

    public void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.Log(this.GetMethodName() + ":" + cause);
    }

    public void OnPhotonCreateRoomFailed(object[] codeAndMsg)
    {
        Debug.Log(this.GetMethodName() + ":" + codeAndMsg[1]);
    }

    public void OnPhotonJoinRoomFailed(object[] codeAndMsg)
    {
        Debug.Log(this.GetMethodName() + ":" + codeAndMsg[1]);
    }

    public void OnConnectedToPhoton()
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnLeftRoom()
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnCreatedRoom()
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnLeftLobby()
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnConnectionFail(DisconnectCause cause)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnDisconnectedFromPhoton()
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnReceivedRoomListUpdate()
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnConnectedToMaster()
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnPhotonMaxCccuReached()
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnPhotonCustomRoomPropertiesChanged(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnPhotonPlayerPropertiesChanged(object[] playerAndUpdatedProps)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnUpdatedFriendList()
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnCustomAuthenticationFailed(string debugMessage)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnWebRpcResponse(OperationResponse response)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnOwnershipRequest(object[] viewAndPlayer)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnLobbyStatisticsUpdate()
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnPhotonPlayerActivityChanged(PhotonPlayer otherPlayer)
    {
        Debug.Log(this.GetMethodName());
    }

    public void OnOwnershipTransfered(object[] viewAndPlayers)
    {
        Debug.Log(this.GetMethodName());
    }
}
