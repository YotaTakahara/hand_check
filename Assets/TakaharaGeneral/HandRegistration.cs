using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using MediaPipe;
using MediaPipe.FaceLandmark;

namespace MediaPipe.HandPose {

public class HandRegistration : MonoBehaviour
{
    #region Editable attributes

    [SerializeField] WebcamInput _webcam = null;
    [SerializeField] ResourceSet _resources = null;
    [SerializeField] bool _useAsyncReadback = true;
    [Space]
    [SerializeField] Mesh _jointMesh = null;
    [SerializeField] Mesh _boneMesh = null;
    [Space]
    [SerializeField] Material _jointMaterial = null;
    [SerializeField] Material _boneMaterial = null;
    [Space]
    [SerializeField] RawImage _monitorUI = null;
        //   [SerializeField] private Image target;//=new Image[21];
    // [SerializeField] private List<Image> target = new List<Image>();
    // [SerializeField] private List<Text> targetText = new List<Text>();
    //[SerializeField] private CreateObject creObj;
    //[SerializeField] private GameController gameController;
    //hennkou
    [SerializeField] ResourceSetFace _resources1 = null;
    [SerializeField] Mesh _template = null;
    [SerializeField] Shader _shader = null;
    public List<Image> targetFace = new List<Image>();

    [SerializeField] private FaceCount faceCount;
    [SerializeField] private RegistrationCount registrationCount;
    public int meshCheck=0;
    public int checkStart=0;
    public float spanCount=5f;
    public float tmpSpan=0f;
    public int frameCount=0;
   
    // public GameObject tmp;
  


        #endregion

        #region Private members
        //Vector3[] tmpPlace=new Vector3[16];
        //float[] diff=new float[16];
        float howcheck=3;
        float span=4.5f;

        



        HandPipeline _pipeline;
        FaceLandmarkDetector _detector;
        Material _material;
         


    static readonly (int, int)[] BonePairs =
    {
        (0, 1), (1, 2), (1, 2), (2, 3), (3, 4),     // Thumb
        (5, 6), (6, 7), (7, 8),                     // Index finger
        (9, 10), (10, 11), (11, 12),                // Middle finger
        (13, 14), (14, 15), (15, 16),               // Ring finger
        (17, 18), (18, 19), (19, 20),               // Pinky
        (0, 17), (2, 5), (5, 9), (9, 13), (13, 17)  // Palm
    };

    Matrix4x4 CalculateJointXform(Vector3 pos)
      => Matrix4x4.TRS(pos, Quaternion.identity, Vector3.one * 0.07f);

    Matrix4x4 CalculateBoneXform(Vector3 p1, Vector3 p2)
    {
        var length = Vector3.Distance(p1, p2) / 2;
        var radius = 0.03f;

        var center = (p1 + p2) / 2;
        var rotation = Quaternion.FromToRotation(Vector3.up, p2 - p1);
        var scale = new Vector3(radius, length, radius);

        return Matrix4x4.TRS(center, rotation, scale);
    }

        #endregion

        #region MonoBehaviour implementation
      //  [SerializeField] private CreateObject object;

        void Start()
        {
            //hennkou
            // _detector = new FaceLandmarkDetector(_resources1);
            // _material = new Material(_shader);
             _detector = new FaceLandmarkDetector(_resources1);
             _material = new Material(_shader);

             _pipeline = new HandPipeline(_resources);
           
            //  Debug.Log("")
            // GameObject tmpCreate=GameObject.Find("CreateObject");
            // creObj=tmpCreate.GetComponent<CreateObject>();
            //GameObject tmpCon=GameObject.Find("GameController");
            //gameController=tmpCon.GetComponent<GameController>();
            GameObject tmpFaceCalc=GameObject.Find("FaceCount");
            faceCount=tmpFaceCalc.GetComponent<FaceCount>();

            GameObject regiTmp=GameObject.Find("RegistrationCount");
            registrationCount=regiTmp.GetComponent<RegistrationCount>();
           // checkStart=registrationCount.checkStart;
            



    

      
        }

        void OnDestroy()
      => _pipeline.Dispose();


    public int tmpGuu=0;
    public int tmpHitosashi=0;
    public int PoseHitosashi(Vector3 place){
    //  Debug.Log("tmpHitosashi:"+tmpHitosashi);
        if(4<=tmpHitosashi){
         
            return 1;
        }else{
            return 0;
        }
    }
    public int tmpHutasashi=0;
    public int PoseHutasashi(Vector3 place){
        return 0;
       
       
    }



    void LateUpdate()
    {
        //checkStart=registrationCount.checkStart;
        int checkCount=0;
        int  checkCountHitosashi=0;
         float  checkCountHutasashi=0;
         howcheck+=Time.deltaTime;
        // Feed the input image to the Hand pose pipeline.
        _pipeline.UseAsyncReadback = _useAsyncReadback;
        _detector.ProcessImage(_webcam.Texture);
        _pipeline.ProcessImage(_webcam.Texture);

        var layer = gameObject.layer;
          //  int check = 0;
          Debug.Log("なんでやねん"+checkStart);
          if(checkStart==1){
        tmpSpan+=Time.deltaTime;
        frameCount+=1;
        Debug.Log("ここまでおっけい");
        if(tmpSpan<spanCount){
                    for(int i=0;i<HandPipeline.KeyPointCount;i++){
                       // Debug.Log("_pipeline.GetKeyPoint(i):"+_pipeline.GetKeyPoint(i));

                    registrationCount.handCheck[i]+=_pipeline.GetKeyPoint(i)-_pipeline.GetKeyPoint(6);
                    }



                }
                else{
                    checkStart=2;
                    Debug.Log("check Finished!!!!!!!!!!");
                    registrationCount.average(frameCount);
                }

    }


            

            // Joint balls
            for (var i = 0; i < HandPipeline.KeyPointCount; i++)
            {
                var xform = CalculateJointXform(_pipeline.GetKeyPoint(i));
                
                
               

    
                // Debug.Log("xform:" + xform);
                //Debug.Log("_pipeline:" + _pipeline);
                //Debug.Log("HandPipeline.KeyPointCount:" + HandPipeline.KeyPointCount);
                Graphics.DrawMesh(_jointMesh, xform, _jointMaterial, layer);
              
               
              

            }
          
            

            // Bones
            foreach (var pair in BonePairs)
        {
            var p1 = _pipeline.GetKeyPoint(pair.Item1);
            var p2 = _pipeline.GetKeyPoint(pair.Item2);
            var xform = CalculateBoneXform(p1, p2);
            Graphics.DrawMesh(_boneMesh, xform, _boneMaterial, layer);
        }

        // UI update
        _monitorUI.texture = _webcam.Texture;

   
    








   
    
    









    }
     public void OnRenderObject(){
   
    }

    #endregion
}

} // namespace MediaPipe.HandPose
