using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShieldScript : MonoBehaviour {

    void Start()
    {



    }

    void Update()
    {




    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle") {
            Destroy(other.gameObject);
        }
    }
}

        
     

