using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MediaPipe.HandPose;

public class CubeBox : MonoBehaviour
{
    [SerializeField] private GameObject animatorVir;
    [SerializeField] private HandAnimator handAnimator;
    public GameObject target;
    [SerializeField] private Canvas canvas;
    [SerializeField] private EnemyGenerator enemyGenerator;
    // Start is called before the first frame update
    void Start()
    {

        GameObject canvasObj=GameObject.Find("Canvas");
        GameObject eneObj=GameObject.Find("EnemyGenerator");
        canvas=canvasObj.GetComponent<Canvas>();
        animatorVir=GameObject.Find("AnimatorVir");
        handAnimator=animatorVir.GetComponent<HandAnimator>();
        enemyGenerator=eneObj.GetComponent<EnemyGenerator>();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other) {
      //  Debug.Log("攻撃判定");
        if(handAnimator.Pose()==1){
            Destroy(target.gameObject);
            Destroy(this.gameObject);
            enemyGenerator.GenerateEne();
            
        }
    }
     void OnTriggerStay(Collider other) {
     //   Debug.Log("shineee");

    }
}
