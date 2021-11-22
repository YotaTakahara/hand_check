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
    public float timeScore=0;
    int life=5;


    void Start(){
        Debug.Log("jgjhfjghfjhgjfhgjjfgjfjgf");
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
        Debug.Log("faceCount:"+faceCount);
        tenpariKeisu=faceCount.tenpariKeisu;
        TenpariChange(tenpariKeisu);
        Initialize();

        
      
         //Instantiate(wallList[0],transform.position,Quaternion.identity);

        

    }
    void Update(){
        Debug.Log("faceCount:"+faceCount.tenpariKeisu);
        tenpariKeisu=faceCount.tenpariKeisu;
        timeScore+=Time.deltaTime;
        //life=playerMove.life;
        //text.color=new Color(0.5,0)
        text.text="Time:"+(int)timeScore+"\n"+"テンパリ係数"+tenpariKeisu+"\n"+"life:"+life;
        
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
        timeScore=faceCount.timeScore;
        //playerMove.life=life;
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
        faceCount.timeScore=timeScore;
        
        DontDestroyOnLoad(faceCount);
        //playerMove.RelocateToFirst();
        //DontDestroyOnLoad(player);
        //DontDestroyOnLoad(this);
        
         if(SceneManager.GetActiveScene().name == "TestAnimator"){
            //sceneState=0;
            //Instantiate(wallList[0],transform.position,Quaternion.identity);
            //SceneManager.LoadScene("Tmp");
            SceneManager.LoadScene("UserRegistration");

        }
        else if(SceneManager.GetActiveScene().name == "Tmp"){
            //sceneState=1;
            //Instantiate(wallList[1],transform.position,Quaternion.identity);
            SceneManager.LoadScene("UserRegistration");

        }
        
    }
    public void TenpariChange(float k){
        if(1<k){
        Debug.Log("テンパリ係数の変化により、状況が変化いたしました");
        this.check=0;
        textTenpari.text="ステージレベル"+k;
        }
    }
    public void MeetEnemy(Vector3 place){
        Instantiate(effect,place,Quaternion.identity);
        //playerMove.life-=1;
        life-=1;
         CheckLife();
    }
     public void CheckLife(){
        if(life <=0){
            SceneManager.LoadScene("Fish");

        }
    }

    
}
