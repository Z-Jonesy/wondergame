
using UnityEngine;

public class GameState : MonoBehaviour {

    public int WinThreshold = 4;
    private PlayerInventory _playerInventory;

    private void Awake()
    {
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }
	
    private void Update()
    {
        if (FindObjectsOfType<Pickup>().Length < WinThreshold - _playerInventory.pickupCount) {
            Debug.Log("a játékos már nem nyerhet"); }
        if (WinThreshold <= _playerInventory.pickupCount)
        {
            Debug.Log("a játékos már nyert");
        }
    }

}
