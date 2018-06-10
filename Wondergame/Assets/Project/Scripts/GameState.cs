using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour {

    public int WinThreshold = 1;
    private PlayerInventory _playerInventory;
    private Pickup[] _pickups;
    private int pickupsCount;


    private void Awake()
    {
        _pickups = FindObjectsOfType<Pickup>();
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }
	
    private void Update()
    {
        if (CanWin())
        {
            Debug.Log("a játékos már nem nyerhet");
        }
        if (WinThreshold <= _playerInventory.pickupCount)
        {
            Debug.Log("a játékos már nyert");
        }
    }

    public bool CanWin()
    {
        
        return _pickups.Count(p => p.isActiveAndEnabled) < WinThreshold - _playerInventory.pickupCount;
        
    }
}
