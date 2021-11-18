using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MediaPipe.HandPose;

public class GameController : MonoBehaviour
{
    [SerializeField] private HandAnimator handAnimator;
    [SerializeField] private EnemyList enemyList;
    [SerializeField] private GameObject effect;

    [SerializeField] private List<GameObject> eneList;
    [SerializeField] private List<GameObject> eneList1;
    [SerializeField] private List<GameObject> wallList=new List<GameObject>();
    [SerializeField] private  int tmp=0;
    [SerializeField] private Text text;
    [SerializeField] private Text textTenpari;
    [SerializeField] private Text textTenpariMini;
    private float check=100;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject cir;
    [SerializeField] private FaceCount faceCount;
    [SerializeField] private float tenpariKeisu=1;

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
        GameObject tmpFace=GameObject.Find("FaceCount");
        faceCount=tmpFace.GetComponent<FaceCount>();
        tenpariKeisu=faceCount.tenpariKeisu;
        
      
         Instantiate(wallList[0],transform.position,Quaternion.identity);

        

    }
    void Update(){
        tenpariKeisu=faceCount.tenpariKeisu;
        text.text="score:"+score+"\n"+"テンパリ係数"+tenpariKeisu;
        ScoreScene();
        if(check<5){
            textTenpariMini.text="テンパリ係数が"+tenpariKeisu+"になりました";
            check+=Time.deltaTime;
        }else{
            textTenpariMini.text="";

        }

    }
    public void CreateBlock(Vector3 place){
         place.z=-0.2f;
         Instantiate(block,place,Quaternion.identity);
    }
    public void NextPosition(Vector3 place){
        place.z=-0.1f;
        playerMove.RedChange(place);
        Debug.Log("place:"+place);

         place.z=0;
         Instantiate(cir,place,Quaternion.identity);
         


    }
   

    public void ScoreScene(){
        if(sceneState==1){
            Instantiate(wallList[1],transform.position,Quaternion.identity);
            score=score+eneList.Count;
            
        }

    }
    public void StateChange(){
        Debug.Log("状態が推移しましたのでお知らせします!!!!!!!!!!!!!!!!!!!");
        playerMove.RelocateToFirst();
        
        
    }
    public void TenpariChange(float k){
        Debug.Log("テンパリ係数の変化により、状況が変化いたしました");
        this.check=0;
        textTenpari.text="ステージレベル"+k;
    }
    public void MeetEnemy(Vector3 place){
        Instantiate(effect,place,Quaternion.identity);
    }

    
}
