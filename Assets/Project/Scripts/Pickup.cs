using UnityEngine;

public class Pickup : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            other.gameObject.GetComponent<PlayerInventory>().pickupCount++;
            gameObject.SetActive(false);
        }
    }

}
