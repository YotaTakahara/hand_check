using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCount : MonoBehaviour
{

    public float tenpariKeisu=1;
    [SerializeField] private GameController gameController;
    [SerializeField] private float tmpScore=0;
    [SerializeField] private float tmpScore1=0;
    [SerializeField] private float tenpariTmp=0;
    float sceneMove=0;
    void Start()
    {
        GameObject tmpGamCon=GameObject.Find("GameController");
        gameController=tmpGamCon.GetComponent<GameController>();
        
        sceneMove=tenpariKeisu;
        
        
    }

    // Update is called once per frame
    void Update()
    {if(0.5<tenpariTmp){
        tmpScore+=1;

    }
    if(1<tenpariTmp){
        tmpScore+=1;
    }
    if(tenpariTmp<=0.5){
        tmpScore-=1;
        tmpScore1-=1;
        if(tmpScore<0){
            tmpScore=0;
        }if(tmpScore1<0){
            tmpScore1=0;
        }
    }

    if(30<tmpScore){
        tenpariKeisu=1.5f;
    }
    if(30<tmpScore1){
        tenpariKeisu=2f;
    }

    if(sceneMove<tenpariKeisu){
        sceneMove=tenpariKeisu;
        gameController.TenpariChange(tenpariKeisu);
    }



        
    }

    public float DiffFaceScore(Vector3 tmp,Vector3 now){
       return Vector3.Magnitude(tmp-now);

    }
    public void CalcFaceScore(float[] diff){
        float tmp=0;
         for(int i=0;i<diff.Length;i++){
             tmp+=diff[i];
         }
         tenpariTmp=tmp;
         //Debug.Log("tenpariTmp:"+tenpariTmp);
         

    }
}
