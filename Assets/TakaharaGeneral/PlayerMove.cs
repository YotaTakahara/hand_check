using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private GameObject goal;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float circleDistance=0.3f;
    public float speed=0.1f;
    public Vector3 firstPosition;
    // Start is called before the first frame update
    void Start()
    {
        goal=GameObject.Find("Goal");
        targetPosition=goal.transform.position;
        firstPosition=this.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float tmpDistance=Vector3.Magnitude(targetPosition-transform.position);
        if(tmpDistance<circleDistance){
            targetPosition=SelectWhere();
            Debug.Log("目標位置の変更が起こりました:"+targetPosition);
        }
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        
    

    public Vector3 SelectWhere(){
       // UnityEngine.Random.InitState(DateTime.Now.Millisecond);
        float tmpX=Random.Range(goal.transform.position.x,transform.position.x);
        float tmpY=Random.Range(-0.45f,0.45f);
         tmpX=Random.Range(goal.transform.position.x,transform.position.x);
         tmpY=Random.Range(-0.45f,0.45f);
        Vector3 where=new Vector3(tmpX,tmpY,-0.1f);
        return where;

    }
    public void RelocateToFirst(){
        this.transform.position=firstPosition;
    }
}
