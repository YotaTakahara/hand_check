using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float circle=0.7f;
    [SerializeField] private Vector3 goalPoint;
    [SerializeField] private float speed=0.1f;
   // public  int sceneScore;
    [SerializeField] private GameController gameController; 
    [SerializeField] private FaceCount faceCount;
    float tenpariKeisu=1.0f;
    float tenpariTmp=1f;
   // [SerializeField] private GameObject effect;
    
    

    // Start is called before the first frame update
    void Start()
    {
        goalPoint=transform.position;
        GameObject gameCon=GameObject.Find("GameController");
        gameController=gameCon.GetComponent<GameController>();
        GameObject faceTmp=GameObject.Find("FaceCount");
        faceCount=faceTmp.GetComponent<FaceCount>();
         tenpariKeisu=faceCount.tenpariKeisu;
        

        //sceneScore=gameController.scoreState;

        
    }

    // Update is called once per frame
    void Update()
    {
        tenpariKeisu=faceCount.tenpariKeisu;
        if(tenpariTmp<tenpariKeisu){
            tenpariTmp=tenpariKeisu;
            TenpariChange(tenpariKeisu);
        }
        // int tmpScore=gameController.sceneState;
        // if(sceneScore<tmpScore){

        // }
       // Debug.Log("tmpScore:"+tmpScore);
        
        float distance=Vector3.Magnitude(goalPoint-transform.position);
        if(distance<circle){
            goalPoint=SelectPoint();

        }
         Quaternion targetRotation = Quaternion.LookRotation(goalPoint - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        transform.Translate(Vector3.forward * speed/2 * Time.deltaTime);
        
        
        
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
            gameController.MeetEnemy(collider.transform.position);
            Debug.Log("アタック対象発見!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //Instantiate(effect,transform.position,Quaternion.identity);
        }
    }

    public void TenpariChange(float k){
        speed=speed*k;
    }
}
