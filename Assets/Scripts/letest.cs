using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;
using UnityEngine;

public class letest : MonoBehaviour {
    public x360_Gamepad gamepad;

    

    private GamepadManager manager;
	// Use this for initialization
	void Start () {
        manager = GamepadManager.Instance;
        //  gamepad = manager.GetGamepad();
        gamepad=manager.GetGamepad(1);

        StartCoroutine(Gamepadator());
        
    }


    IEnumerator Gamepadator()
    {
        yield return new WaitForSeconds(.5f);
        print(manager.ConnectedTotal());
    }
    // Update is called once per frame
    void Update()
    {
        if (gamepad.GetButtonDown("A"))
        {
            Debug.Log("oui");
        }
        
    }
   
    }

