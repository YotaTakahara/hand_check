using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private GameObject goal;
    [SerializeField] private float circleDistance=0.5f;
    [SerializeField] private FaceCount faceCount;
    public  Vector3 targetPosition;

    public float speed=0.1f;
    public Vector3 firstPosition;
    public int HP=5;
    void Start()
    {
        goal=GameObject.Find("Goal");
        GameObject faceTmp=GameObject.Find("FaceCount");
        faceCount=faceTmp.GetComponent<FaceCount>();
        //Debug.Log("goal:"+goal.transform.position);
        targetPosition=this.transform.position;
        firstPosition=this.transform.position;
        //Debug.Log("targetPosition:"+targetPosition);
        
    }

    
    void Update()
    {
        float tenpariKeisu=faceCount.tenpariKeisu;
        speed=speed*tenpariKeisu;
        
        float tmpDistance=Vector3.Magnitude(targetPosition-transform.position);
       // Debug.Log("tmpDistance:"+tmpDistance);
        if(tmpDistance<circleDistance){
            targetPosition=SelectWhere();
           // Debug.Log("目標位置の変更が起こりました:"+targetPosition);
        }
       // Debug.Log("目標位置の変更が起こりました:"+targetPosition);
        // Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        Vector3 ne=targetPosition-transform.position;
        //ne.z=0;
        //Debug.Log("ne.normalized:"+ne.normalized*speed*Time.deltaTime);

       // Debug.Log("transform.position:"+transform.position);
        transform.Translate(ne* speed * Time.deltaTime);
        if(transform.position.z<-0.1f){
        Debug.Log("transform.position:"+transform.position);
        Debug.Log("targetPosition:"+targetPosition);
        Debug.Log("ne.normalized:"+ne*speed*Time.deltaTime);

        }
        }

        
    

    public Vector3 SelectWhere(){
       // UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    //   UnityEngine.Random.InitState(DateTime.Now.Millisecond);
        float tmpX=Random.Range(transform.position.x-0.4f,transform.position.x);
        float tmpY=Random.Range(-0.45f,0.45f);
        
        Vector3 where=new Vector3(tmpX,tmpY,-0.1f);
        return where;

    }
    public void RelocateToFirst(){
        this.transform.position=firstPosition;
        Debug.Log("firstPosition");
    }
    public void RedChange(Vector3 place){
        Debug.Log("targetPosition:"+targetPosition);
        targetPosition=place;
    
    }
}
