using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    private int checkMon=0;
    private int checkChara=0;
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
        checkMon+=1;
        }
        if(checkMon==2&&checkChara==1){
            
        }

        
    }
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="MainCharacter"){
            GetComponent<Renderer>().material.color=Color.red;
            checkChara=1;
        }
    }
}
