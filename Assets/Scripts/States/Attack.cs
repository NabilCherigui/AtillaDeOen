using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : State
{

	public override void Act()
	{
		gameObject.tag = "Attack";
	}

	public override void Reason()
	{
		if (!GetComponent<Demon>()._Peripheral)
		{
			GetComponent<StateMachine>().SetState(StateID.Wander);
		}
		else
		{
			GetComponent<StateMachine>().SetState(StateID.Follow);
		}
	}
}