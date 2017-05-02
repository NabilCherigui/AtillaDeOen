using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    [SerializeField] private Vector3[] _patrolPoints;
    [SerializeField] private NavMeshAgent _agent;
    private int _currentGoal = 0;

    public override void Enter()
    {
        _agent.SetDestination(_patrolPoints[_currentGoal]);
    }

    public override void Leave()
    {
        _agent.Stop();
    }

    public override void Act()
    {
        if (_agent.remainingDistance <= float.Epsilon)
        {
            _currentGoal++;
            if (_currentGoal > _patrolPoints.Length)
            {
                _currentGoal = 0;
            }
            _agent.SetDestination(_patrolPoints[_currentGoal]);
        }
    }

    public override void Reason()
    {
		if (GetComponent<Demon>()._Peripheral)
         GetComponent<StateMachine>().SetState(StateID.Follow);
    }
}
