using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCount : MonoBehaviour
{

    public float tenpariKeisu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float DiffFaceScore(Vector3 tmp,Vector3 now){
       return Vector3.Magnitude(tmp-now);

    }
    public void CalcFaceScore(float[] diff){
        float tmp=0;
         for(int i=0;i<diff.Length;i++){
             tmp+=diff[i];
         }
         tenpariKeisu=tmp;
         Debug.Log("tenpariKeisu:"+tenpariKeisu);
         

    }
}
