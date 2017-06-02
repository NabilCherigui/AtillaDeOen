using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : State
{
    
	private float _animationTime1 = 3.375f;
	private float _timeCompare;
	
	public override void Act()
	{
	}

	public override void Reason()
	{			
		gameObject.tag = "Attack";

		/*if (GetComponent<StateMachine>().animator.GetInteger("States") == 2)
		{
			_timeCompare = Time.time + _animationTime1;
			GetComponent<StateMachine>().animator.SetInteger("States", 3);
			print("Ik ga ff sigaretten halen.");
		}
		else if (GetComponent<StateMachine>().animator.GetInteger("States") == 3 && _timeCompare < Time.time)
		{
			GetComponent<StateMachine>().animator.SetInteger("States", 4);
			gameObject.tag = "Attack";
			print("hallo zoon ik ben er.");
		}*/
		
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