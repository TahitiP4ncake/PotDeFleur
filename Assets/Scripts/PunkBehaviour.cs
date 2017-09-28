using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunkBehaviour : MonoBehaviour {

    public Rigidbody rb;

    public float punchSpeed;    


    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag=="Weapon")
        {
            rb.velocity += (transform.position - other.gameObject.transform.position) * punchSpeed;
            print("punched!");
        }
    }
}
