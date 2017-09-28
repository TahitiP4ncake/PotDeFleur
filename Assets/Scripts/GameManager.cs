using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager singleton;

    void Awake()
    {
        if (singleton != null && singleton != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (singleton == null)
            {
                Debug.LogError("[GameManager]: Instance does not exist!");
                return null;
            }

            return singleton;
        }
    }

    void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
