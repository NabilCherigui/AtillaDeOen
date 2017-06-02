using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : State
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _player;
	private int delay = 30;
	public override void Enter ()
	{
		_agent.Resume ();
	}
    public override void Act()
    {
        _agent.SetDestination(_player.position);
		delay--;
    }

    public override void Reason()
    {
		if (!GetComponent<Demon>()._Peripheral)
        {
            GetComponent<StateMachine>().SetState(StateID.Wander);
        }
    }
	public void OnTriggerEnter(Collider col)
	{
		if (delay < 0) 
		{
			GetComponent<StateMachine> ().SetState (StateID.Attack);
			delay = 30;
		}
	}
}
