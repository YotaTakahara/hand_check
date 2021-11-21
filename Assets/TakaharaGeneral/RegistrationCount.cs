using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MediaPipe.HandPose;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegistrationCount : MonoBehaviour
{
    [SerializeField] private HandRegistration handRegistration;
    [SerializeField] private GameController gameController;
    [SerializeField] private Text text;
    [SerializeField] private Image image;

    public Vector3[] handCheck=new Vector3[21];
    public float span=5.0f;
    public float checkStart=0;
    int setNum=0;
    int score=0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject conTmp=GameObject.Find("GameController");
        gameController=conTmp.GetComponent<GameController>();
        score=gameController.score;
        GameObject handTmp=GameObject.Find("AnimatorVir");
        handRegistration=handTmp.GetComponent<HandRegistration>();
        

        for(int i=0;i<handCheck.Length;i++){
            handCheck[i]=Vector3.zero;
        }
        setNum=PlayerPrefs.GetInt("numberID",1111111);
        Debug.Log("setNUm:"+setNum);
        int tmp=PlayerPrefs.GetInt($"ID:{setNum}",1111);
        float tmpScore=PlayerPrefs.GetFloat($"SCORE{setNum}",0f);
        Debug.Log("Score:"+score);
        Debug.Log("tmp:"+tmp);
        for(int i=0;i<handCheck.Length;i++){
            //string tmpNu="handCheck"+setNum+"["+i+"]";
            string tmpNu=$"handCheck{setNum}[{i}]";
            string shin=PlayerPrefs.GetString(tmpNu,"ggggggggggg");
            Debug.Log($"shin:{i}{shin}");

        }
        if(setNum!=0){
            setNum+=1;
        }
        text.text="ボタンを押してユーザ登録を開始してください";

        
    }

    // Update is called once per frame
    void Update()
    {
        if(checkStart<=2){
        checkStart=handRegistration.checkStart;
        }
        score=gameController.score;
        if(checkStart==1){
            float tmp=handRegistration.spanCount-handRegistration.tmpSpan;
            text.text="後"+tmp+"秒間です";

        }else if(checkStart==2){
            checkStart=3;
            PrintScore();
           
            
        }



        
    }
    public void average(int frameCount){
       for(int i=0;i<handCheck.Length;i++){
           handCheck[i]=handCheck[i]/frameCount;
           Debug.Log("handCheck[i]:"+handCheck[i]);
       }
       PlayerRegistration();


    }
    public void PlayerRegistration(){
        PlayerPrefs.SetInt("numberID",setNum);
        string num="ID:"+setNum.ToString();
        PlayerPrefs.SetFloat($"SCORE{setNum}",score);

        
        PlayerPrefs.SetInt(num,setNum);
        for(int i=0;i<handCheck.Length;i++){
            //string tmp="handCheck"+setNum+"["+i+"]";
            string tmp=$"handCheck{setNum}[{i}]";
            //string nextTmp="("+handCheck[i].x+","+handCheck[i].y+","+handCheck[i].z+")";
            string nextTmp=$"({handCheck[i].x},{handCheck[i].y},{handCheck[i].z})";
            PlayerPrefs.SetString(tmp,nextTmp);
        }
        Debug.Log("読み込みができました");

    } 
    public void StartClick(){
        checkStart=1;
        handRegistration.checkStart=1;
        text.text="測定開始!!!!!";

    }
    public void PrintScore(){
        Debug.Log("setNum:"+setNum);
        for(int i=0;i<=setNum;i++){
            text.text+="ID:"+PlayerPrefs.GetInt($"ID:{setNum}",1111)+"score:"+PlayerPrefs.GetFloat($"SCORE{setNum}",0f)+"\n";
            for(int j=0;j<handCheck.Length;j++){
                

            }
        }

    }
   
}
