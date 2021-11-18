using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource audios;
    [SerializeField] private float tenpariKeisu=1;
    [SerializeField] private FaceCount faceCount;
    float tmpCheck=1;
    

    
    void Start()
    {
        audios=GetComponent<AudioSource>();
        Invoke("SoundPlay",5.0f);
        GameObject faceTmp=GameObject.Find("FaceCount");
        faceCount=faceTmp.GetComponent<FaceCount>();
        tenpariKeisu=faceCount.tenpariKeisu;
        
    }

    // Update is called once per frame
    void Update()
    {
        tenpariKeisu=faceCount.tenpariKeisu;
        if(tmpCheck!=tenpariKeisu){

            tmpCheck=tenpariKeisu;
            if(tenpariKeisu==1.5f){
                SoundPlay(0);
            }
            else if(tenpariKeisu==2.0f){
                SoundPlay(1);
            }
        }
      
        
    }
    public void SoundPlay(int i){
          audios.clip=clips[i];
            audios.Play();

    }
}
