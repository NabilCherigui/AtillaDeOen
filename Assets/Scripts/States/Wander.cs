using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : State
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private int _maxRounds;
    [SerializeField] private float _maxDistance;
    private int _rounds = 0;
    public override void Enter()
    {
        _agent.SetDestination(RandomNavPos(_maxDistance, this.transform.position, -1));
    }

    public override void Leave()
    {
        _agent.Stop();
    }

    public override void Act()
    {
        if (_agent.remainingDistance <= float.Epsilon || _agent.isPathStale || !_agent.hasPath)
        {
            _rounds++;
            _agent.SetDestination(RandomNavPos(_maxDistance, this.transform.position, -1));
        }
    }

    public override void Reason()
    {
        if (Demon.Peripheral())
        {
            GetComponent<StateMachine>().SetState(StateID.Follow);
        }
        if (_rounds > _maxRounds)
        {
            GetComponent<StateMachine>().SetState(StateID.Patrol);
        }
    }

    private Vector3 RandomNavPos(float distance, Vector3 origin, int layerMask)
    {
        Vector3 direction = Random.insideUnitSphere * distance;
        direction += origin;
        NavMeshHit hit;
        NavMesh.SamplePosition(direction, out hit, distance, layerMask);
        return hit.position;
    }
}
