using UnityEngine;
using UnityEngine.UI;

public class UIPoints : MonoBehaviour {
    private PlayerInventory _playerInventory;
    private Text _text;

    private void Awake()
    {
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = "Pontszám: " + _playerInventory.pickupCount + " / 10";
    }
	
}

