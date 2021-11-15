using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float circle=0.7f;
    [SerializeField] private Vector3 goalPoint;
    [SerializeField] private float speed=0.1f;
    [SerializeField] private int sceneScore;
    [SerializeField] private GameController gameController; 
    
    

    // Start is called before the first frame update
    void Start()
    {
        goalPoint=transform.position;
        GameObject gameCon=GameObject.Find("GameController");
        gameController=gameCon.GetComponent<GameController>();
        //sceneScore=gameController.scoreState;

        
    }

    // Update is called once per frame
    void Update()
    {
        int tmpScore=gameController.sceneState;
       // Debug.Log("tmpScore:"+tmpScore);
        if(sceneScore==tmpScore){
        float distance=Vector3.Magnitude(goalPoint-transform.position);
        if(distance<circle){
            goalPoint=SelectPoint();

        }
         Quaternion targetRotation = Quaternion.LookRotation(goalPoint - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        
        
    }

    public Vector3 SelectPoint(){
        float tmpX=Random.Range(-1.2f,1.2f);
        float tmpY=Random.Range(-0.45f,0.45f);
        Vector3 where=new Vector3(tmpX,tmpY,-0.1f);
        return where;


    }
    void OnCollisionEnter(Collision Collider){
      //  Debug.Log("buttukatta!!!!!!!!!!!!!!!!!");
    }
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="MainCharacter"){
            Debug.Log("アタック対象発見!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }
}
