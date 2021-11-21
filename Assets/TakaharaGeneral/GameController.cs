using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MediaPipe.HandPose;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private HandAnimator handAnimator;
    [SerializeField] private EnemyList enemyList;
    [SerializeField] private GameObject effect;

    [SerializeField] private List<GameObject> eneList;
    //[SerializeField] private List<GameObject> eneList1;
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

    //public int playerHP=5;
    public int sceneState=0;
    public int score=0;
    int life=5;


    void Start(){
        GameObject ani=GameObject.Find("AnimatorVir");
        handAnimator=ani.GetComponent<HandAnimator>();
        GameObject ene=GameObject.Find("EnemyList");
        enemyList=ene.GetComponent<EnemyList>();
        eneList=enemyList.eneList;
        //eneList1=enemyList.eneList1;
        player=GameObject.Find("Player");
        playerMove=player.GetComponent<PlayerMove>();
        //life=playerMove.life;
        GameObject tmpFace=GameObject.Find("FaceCount");
        faceCount=tmpFace.GetComponent<FaceCount>();
        tenpariKeisu=faceCount.tenpariKeisu;
        Initialize();

        
      
         //Instantiate(wallList[0],transform.position,Quaternion.identity);

        

    }
    void Update(){
        tenpariKeisu=faceCount.tenpariKeisu;
        //life=playerMove.life;
        text.text="score:"+score+"\n"+"テンパリ係数"+tenpariKeisu+"\n"+"life:"+life;
        
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
   

    public void Initialize(){
        //score=PlayerPrefs.GetInt("Score",0);
        life=faceCount.life;
        playerMove.life=life;
        if(SceneManager.GetActiveScene().name == "TestAnimator"){
            sceneState=0;
            Instantiate(wallList[0],transform.position,Quaternion.identity);

        }
        else if(SceneManager.GetActiveScene().name == "Tmp"){
            sceneState=1;
            Instantiate(wallList[1],transform.position,Quaternion.identity);

        }
            
          

    }
    public void ScoreCount(){
        
    }
    public void StateChange(){
        Debug.Log("状態が推移しましたのでお知らせします!!!!!!!!!!!!!!!!!!!");
        faceCount.life=life;
        
        DontDestroyOnLoad(faceCount);
        //playerMove.RelocateToFirst();
        //DontDestroyOnLoad(player);
        //DontDestroyOnLoad(this);
        
         if(SceneManager.GetActiveScene().name == "TestAnimator"){
            //sceneState=0;
            //Instantiate(wallList[0],transform.position,Quaternion.identity);
            SceneManager.LoadScene("Tmp");

        }
        else if(SceneManager.GetActiveScene().name == "Tmp"){
            //sceneState=1;
            //Instantiate(wallList[1],transform.position,Quaternion.identity);
            SceneManager.LoadScene("Boss");

        }
        
    }
    public void TenpariChange(float k){
        Debug.Log("テンパリ係数の変化により、状況が変化いたしました");
        this.check=0;
        textTenpari.text="ステージレベル"+k;
    }
    public void MeetEnemy(Vector3 place){
        Instantiate(effect,place,Quaternion.identity);
        //playerMove.life-=1;
        life-=1;
    }

    
}
