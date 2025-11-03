using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float catchDistance = 1.5f;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("❌ No NavMeshAgent found on " + gameObject.name + "! Please add one.");
            return;
        }

        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindWithTag("Player");
            if (foundPlayer != null)
                player = foundPlayer.transform;
            else
                Debug.LogError("❌ Player not found! Make sure your player has the tag 'Player'.");
        }
    }

    void Update()
    {
        if (agent == null || player == null)
            return;

        agent.SetDestination(player.position);

        // Catch player if close enough
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= catchDistance)
        {
            Debug.Log("💀 Enemy caught the player!");
            GameManager.Instance.GameOver();
        }
    }
}
