using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : State
{
	[SerializeField] private int _wanderTime;
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private float _distance;
	[SerializeField] private int _maxWanderRounds;
	private int _wanderRounds = 0;
	private int _timer;
	public override void Enter()
	{
		_timer = _wanderTime;
		_agent.SetDestination(RandomNavPosition(this.transform.position, _distance, -1));
		_agent.Resume();
	}

	public override void Leave()
	{
		_agent.Stop();
	}

	public override void Act()
	{
		_timer--;
		if (_timer < 0)
		{
			_timer = _wanderTime;
			_agent.SetDestination(RandomNavPosition(this.transform.position, _distance, -1));
			_agent.Resume();
			_wanderRounds++;
		}
	}

	public override void Reason()
	{
		if (GetComponent<Demon>()._Peripheral)
		{
			GetComponent<StateMachine>().SetState(StateID.Follow);
		}
		if (_wanderRounds > _maxWanderRounds)
		{
			GetComponent<StateMachine>().SetState(StateID.Patrol);
		}
	}

	private Vector3 RandomNavPosition(Vector3 origin, float distance, int layerMask)
	{
		Vector3 randomDirection = Random.insideUnitSphere * distance;
		randomDirection += origin;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, distance, layerMask);
		return hit.position;
	}
}
