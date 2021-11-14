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
    [SerializeField] private  int tmp=0;
    [SerializeField] private Text text;
    public int score=0;


    void Start(){
        GameObject ani=GameObject.Find("AnimatorVir");
        handAnimator=ani.GetComponent<HandAnimator>();
        GameObject ene=GameObject.Find("EnemyList");
        enemyList=ene.GetComponent<EnemyList>();
        eneList=enemyList.eneList;
        tmp=eneList.Count;
        

    }
    void Update(){
        int now=eneList.Count;
        if(now<tmp){
            score=tmp-now;
           // tmp=now;
        }
        text.text="score:"+score;

    }
}
