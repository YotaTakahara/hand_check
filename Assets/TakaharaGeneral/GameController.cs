using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MediaPipe.HandPose;

public class GameController : MonoBehaviour
{
    [SerializeField] private HandAnimator handAnimator;
    [SerializeField] private EnemyList enemyList;

    [SerializeField] private List<GameObject> eneList;
    [SerializeField] private List<GameObject> eneList1;
    [SerializeField] private List<GameObject> wallList=new List<GameObject>();
    [SerializeField] private  int tmp=0;
    [SerializeField] private Text text;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMove playerMove;
    public int sceneState=0;
    public int score=0;


    void Start(){
        GameObject ani=GameObject.Find("AnimatorVir");
        handAnimator=ani.GetComponent<HandAnimator>();
        GameObject ene=GameObject.Find("EnemyList");
        enemyList=ene.GetComponent<EnemyList>();
        eneList=enemyList.eneList;
        eneList1=enemyList.eneList1;
        player=GameObject.Find("Player");
        playerMove=player.GetComponent<PlayerMove>();
        
      
         Instantiate(wallList[0],transform.position,Quaternion.identity);

        

    }
    void Update(){
        
        text.text="score:"+score;
        ScoreScene();

    }

    public void ScoreScene(){
        if(sceneState==1){
            Instantiate(wallList[1],transform.position,Quaternion.identity);
            score=eneList.Count;
            
        }

    }
    public void StateChange(){
        Debug.Log("状態が推移しましたのでお知らせします!!!!!!!!!!!!!!!!!!!");
        playerMove.RelocateToFirst();
        
        
    }

    
}
