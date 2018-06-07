using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {
    private NavMeshAgent _navMeshAgent;
    private Transform _player;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        _navMeshAgent.SetDestination(_player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            if (other.gameObject.GetComponent<PlayerInventory>().pickupCount>0)
                other.gameObject.GetComponent<PlayerInventory>().pickupCount--;
            Debug.Log("elkapta");
        }

    }

}
