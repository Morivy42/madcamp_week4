// Description: This script is used to start the server and client.
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button _startServerButton;
    [SerializeField] private Button _startClientButton;
    [SerializeField] private Button _startHostButton;

    private void Awake(){
        _startServerButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartServer();
        });
        _startClientButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
        });
        _startHostButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
        });
    }
}
