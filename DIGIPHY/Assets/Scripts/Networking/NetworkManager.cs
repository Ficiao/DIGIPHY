using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform _chessLocation;
    [SerializeField] private Transform _connect4Location;
    private GameObject networkPlayer;

    private void Start()
    {
        Debug.Log("Connecting to PUN server...");
        //UIManager.Instance.SetNetworkStatusText("[NetManager] Connecting to PUN server...");

        PhotonNetwork.ConnectUsingSettings();

        PhotonNetwork.KeepAliveInBackground = 240f;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to PUN server. Joining or creating the room...");
        //UIManager.Instance.SetNetworkStatusText("[NetManager] Connected to PUN server. Joining or creating the room...");

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Main Room", roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created the room.");
        //UIManager.Instance.SetNetworkStatusText("[NetManager] Created the room.");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined the room.");
        //UIManager.Instance.SetNetworkStatusText("[NetManager] Joined the room.");
        //UIManager.Instance.SetNetworkStatusText("[NetManager] " + PhotonNetwork.CurrentRoom.ToStringFull());

        networkPlayer = PhotonNetwork.Instantiate("NetworkPlayer", transform.position, transform.rotation);
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("ChessPrefab", _chessLocation.position, _chessLocation.rotation);
            PhotonNetwork.Instantiate("Connect4Prefab", _connect4Location.position, _connect4Location.rotation);
        }
        Destroy(_chessLocation.gameObject);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("New player joined the room.");
        //UIManager.Instance.SetNetworkStatusText("[NetManager] New player joined the room.");
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Destroy(networkPlayer);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log(cause.GetType().ToString());
        //UIManager.Instance.SetNetworkStatusText("[NetManager] " + cause.GetType().ToString());
    }
}
