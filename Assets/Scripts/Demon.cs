using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StateID
{
	Idle = 0,
	Patrol = 1,
	Attack = 2,
	Smell = 3,
    Wander = 4,
    Follow = 5,
    Creep = 6
}

public class Demon : MonoBehaviour {

	/** we declareren de statemachine */
	private StateMachine stateMachine;

	// Use this for initialization
	void Start () {
		/** we halen een referentie op naar de state machine */
		stateMachine = GetComponent<StateMachine>();

		/** we voegen de verschillende states toe aan de state machine */
		MakeStates();
	}
	
	void MakeStates() {

	}

    public static bool Peripheral()
    {
        return false;
    }
}