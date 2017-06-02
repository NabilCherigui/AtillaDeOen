using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private NavMeshAgent _agent;
    
    private float _animationTime1 = 1.333f;
    private float _timeCompare;

    private int _currentGoal = 0;

    public override void Enter()
    {
        _agent.SetDestination(_patrolPoints[_currentGoal].position);
		_agent.Resume ();
    }

    public override void Leave()
    {
        _agent.Stop();
    }

    public override void Act()
    {
        if (_agent.remainingDistance <= 0.00001)
        {
            _currentGoal++;
            if (_currentGoal >= _patrolPoints.Length)
            {
                _currentGoal = 0;
            }
            _agent.SetDestination(_patrolPoints[_currentGoal].position);
        }
        
        /*if (GetComponent<StateMachine>().animator.GetInteger("States") == 0)
        {
            _timeCompare = Time.time + _animationTime1;
                GetComponent<StateMachine>().animator.SetInteger("States", 1);
        }
        else if (GetComponent<StateMachine>().animator.GetInteger("States") == 1 && _timeCompare < Time.time)
        {
            GetComponent<StateMachine>().animator.SetInteger("States", 2);
        }*/
    }

    public override void Reason()
    {
		if (GetComponent<Demon>()._Peripheral)
         GetComponent<StateMachine>().SetState(StateID.Follow);
    }
}
