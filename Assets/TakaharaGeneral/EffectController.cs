using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectController : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource audios;
    [SerializeField] private float tenpariKeisu=1;
    [SerializeField] private FaceCount faceCount;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private List<Image> images=new List<Image>();
    [SerializeField] private　List<Text> texts=new List<Text>();
    [SerializeField] private List<GameObject> enemies=new List<GameObject>(); 
    
    float tmpCheck=1;
    public float cautionDistacne=0.5f;

    

    
    void Start()
    {
        audios=GetComponent<AudioSource>();
        Invoke("SoundPlay",5.0f);
        GameObject faceTmp=GameObject.Find("FaceCount");
        faceCount=faceTmp.GetComponent<FaceCount>();
        player=GameObject.Find("Player");
        playerMove=player.GetComponent<PlayerMove>();
        tenpariKeisu=faceCount.tenpariKeisu;
        for(int i=0;i<images.Count;i++){
            texts.Add(images[i].GetComponentInChildren<Text>());
            enemies.Add((GameObject)images[i].GetComponent<CubeBox>().target);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // for(int i=0;i<images.Count;i++){
        //     float distance=Vector3.Magnitude(images[i].transform.position-player.transform.position);
        //     if(distance<cautionDistacne){
        //         images[i].color=Color.red;
        //         texts[i].text="Caution";
        //         texts[i].color=Color.red;
        //         texts[i].fontSize=20;
        //     }else{
        //         images[i].color=Color.white;
        //         texts[i].text="";
        //     }
        // }
        if(tenpariKeisu==2){
            EnemyCaution();

        }
        //tenpariKeisu=faceCount.tenpariKeisu;
        // if(tmpCheck!=tenpariKeisu){

        //     tmpCheck=tenpariKeisu;
        //     if(tenpariKeisu==1.5f){
        //         SoundPlay(0);
        //     }
        //     else if(tenpariKeisu==2.0f){
        //         SoundPlay(1);
        //     }
        // }
      
        
    }
    public void SoundPlay(){
        int tmp=0;
        tenpariKeisu=faceCount.tenpariKeisu;
        if(tenpariKeisu==1){
            tmp=0;
        }
        else if(tenpariKeisu==1.5){
            tmp=1;
        }else if(tenpariKeisu==2){
            tmp=2;
        }
        audios.clip=clips[tmp];
        audios.Play();
    }
    public void PlayerColor(){
        int tmp=0;
        tenpariKeisu=faceCount.tenpariKeisu;
        if(tenpariKeisu==1){
            tmp=0;
        }
        else if(tenpariKeisu==1.5){
            tmp=1;
            player.GetComponent<Renderer>().material.color=new Color(0,0,0.8f,0.5f);

        }else if(tenpariKeisu==2){
            tmp=2;
            player.GetComponent<Renderer>().material.color=new Color(1f,0,1f,0.8f);
        }
        
    }
    public void EnemyCaution(){
        for(int i=0;i<images.Count;i++){
            float distance=Vector3.Magnitude(images[i].transform.position-player.transform.position);
            if(distance<cautionDistacne){
                images[i].color=Color.red;
                texts[i].text="Caution";
                texts[i].color=Color.red;
                texts[i].fontSize=20;
            }else{
                images[i].color=Color.white;
                texts[i].text="";
            }
        }

    }



}
