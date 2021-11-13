using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MediaPipe.HandPose;

public class CubeBox : MonoBehaviour
{
    [SerializeField] private GameObject animatorVir;
    [SerializeField] private HandAnimator handAnimator;
    [SerializeField] private GameObject target;
    [SerializeField] private EnemyGenerator enemyGenerator;
    // Start is called before the first frame update
    void Start()
    {
        animatorVir=GameObject.Find("AnimatorVir");
        handAnimator=animatorVir.GetComponent<HandAnimator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other) {
        Debug.Log("攻撃判定");
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
