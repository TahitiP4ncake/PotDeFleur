using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

    public PlanteController player;
	
	void Dash () 
	{
        player.Dash();
	}

    void AttackOn()
    {
        player.AttackOn();
    }

    void AttackOff()
    {
        player.AttackOff();
    }

    void GetUp()
    {
        player.GetUp();
    }
}
