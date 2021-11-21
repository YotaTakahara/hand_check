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
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private EnemyMove enemyMove;
    [SerializeField] private EffectController effectController;
    public int life=5;
    float sceneMove=0;
    void Start()
    {
        GameObject tmpGamCon=GameObject.Find("GameController");
        gameController=tmpGamCon.GetComponent<GameController>();
        GameObject tmpEff=GameObject.Find("EffectController");
        effectController=tmpEff.GetComponent<EffectController>();
        // GameObject playerTmp=GameObject.Find("Player");
        // playerMove=playerTmp.GetComponent<PlayerMove>();
        // GameObject enemyMove=GameObject.Find("")
        
        sceneMove=tenpariKeisu;
        
        
    }

    // Update is called once per frame
    void Update()
    {if(0.3<tenpariTmp){
        tmpScore+=1;

    }
    if(0.5<tenpariTmp){
        tmpScore1+=1;
    }
    if(tenpariTmp<=0.3){
        tmpScore-=1;
        tmpScore1-=1;
        if(tmpScore<0){
            tmpScore=0;
        }if(tmpScore1<0){
            tmpScore1=0;
        }
    }

    if(30<tmpScore&&tenpariKeisu<1.5f){
        tenpariKeisu=1.5f;
        effectController.SoundPlay();
        effectController.PlayerColor();
    }
    if(30<tmpScore1&&tenpariKeisu<2f){
        tenpariKeisu=2f;
        effectController.SoundPlay();
        effectController.PlayerColor();
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
