using UnityEngine;
using UnityEngine.AI;
 
// Walk to a random position and repeat
[RequireComponent(typeof(NavMeshAgent))]
public class RandomWalk : MonoBehaviour
{
    public float m_Range = 500.0f;
    NavMeshAgent m_agent;
 
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }
 
    void Update()
    {
        if (m_agent.pathPending || m_agent.remainingDistance > 0.1f)
        {
            return;
        }
 
        Vector3 randomPos = Random.insideUnitCircle*m_Range;
        m_agent.destination = new Vector3(randomPos.x,randomPos.y,51);
    }
}