using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public float rotationSpeed = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found on this GameObject.");
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(agent != null)
        {
            agent.SetDestination(player.position);
        }
        
        //if (player != null)
        //{
            
        //    Vector3 direction = (player.position - transform.position).normalized;

        //    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        //    agent.SetDestination(player.position);
        //}
    }
}