using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
     public List<GameObject> eneList=new List<GameObject>();
     // public List<GameObject> eneList1=new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WhatWillDie(int nowScene){
      // for(int i=0;i<eneList.Count;i++){
      //   int tmp=eneList[i].GetComponent<EnemyMove>().sceneScore;
      //   GameObject monTmp=eneList[i];
      //   if(tmp<nowScene){
      //     eneList.RemoveAt(i);
      //     Destroy(monTmp.gameObject);
      //   }

      // }
      
    }
}
