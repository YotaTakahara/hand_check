using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        Debug.Log("itaaai");
        if(collision.gameObject.tag=="Monster"){
        GetComponent<Renderer>().material.color=Color.green;
        }
    }
}
