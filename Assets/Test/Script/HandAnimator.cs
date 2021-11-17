using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using MediaPipe;
using MediaPipe.FaceLandmark;

namespace MediaPipe.HandPose {

public class HandAnimator : MonoBehaviour
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
    [SerializeField] private List<Image> target = new List<Image>();
    [SerializeField] private List<Text> targetText = new List<Text>();
    //[SerializeField] private CreateObject creObj;
    [SerializeField] private GameController gameController;
    //hennkou
    [SerializeField] ResourceSetFace _resources1 = null;
    [SerializeField] Mesh _template = null;
    [SerializeField] Shader _shader = null;
    public List<Image> targetFace = new List<Image>();

    [SerializeField] private FaceCount faceCount;
   
    // public GameObject tmp;
  


        #endregion

        #region Private members
        Vector3[] tmpPlace=new Vector3[16];
        float[] diff=new float[16];

        



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
            for (int i = 0; i < target.Count;i++)
            {
            //    Debug.Log("target[i].GetComponent<Text>():" + target[i].GetComponentInChildren<Text>());
                // Text tmp = target[i].GetComponentInChildren<Text>();
                // targetText.Add(tmp);
            }
            //  Debug.Log("")
            // GameObject tmpCreate=GameObject.Find("CreateObject");
            // creObj=tmpCreate.GetComponent<CreateObject>();
            GameObject tmpCon=GameObject.Find("GameController");
            gameController=tmpCon.GetComponent<GameController>();
            GameObject tmpFaceCalc=GameObject.Find("FaceCount");
            faceCount=tmpFaceCalc.GetComponent<FaceCount>();
            

        Vector4 place = _detector.UpdatePostReadCache()[1];
      Vector4 place1 = _detector.UpdatePostReadCache()[205];
      Vector4 place2 = _detector.UpdatePostReadCache()[425];
      Vector4 place3 = _detector.UpdatePostReadCache()[33];
      Vector4 place4 = _detector.UpdatePostReadCache()[133];
      Vector4 place5 = _detector.UpdatePostReadCache()[263];
      Vector4 place6 = _detector.UpdatePostReadCache()[362];
      Vector4 place7 = _detector.UpdatePostReadCache()[168];
      Vector4 place8 = _detector.UpdatePostReadCache()[78];
      Vector4 place9 = _detector.UpdatePostReadCache()[13];
      Vector4 place10 = _detector.UpdatePostReadCache()[308];
      Vector4 place11 = _detector.UpdatePostReadCache()[14];
      Vector4 place12 = _detector.UpdatePostReadCache()[70];
      Vector4 place13 = _detector.UpdatePostReadCache()[55];
      Vector4 place14 = _detector.UpdatePostReadCache()[300];
      Vector4 place15 = _detector.UpdatePostReadCache()[285];    


      tmpPlace[0] = new Vector3(place.x - 0.5f, place.y - 0.5f, 0);
      tmpPlace[1] = new Vector3(place1.x - 0.5f, place1.y - 0.5f, 0);
      tmpPlace[2] = new Vector3(place2.x - 0.5f, place2.y - 0.5f, 0);
      tmpPlace[3] = new Vector3(place3.x - 0.5f, place3.y - 0.5f, 0);
      tmpPlace[4] = new Vector3(place4.x - 0.5f, place4.y - 0.5f, 0);
      tmpPlace[5] = new Vector3(place5.x - 0.5f, place5.y - 0.5f, 0);
      tmpPlace[6] = new Vector3(place6.x - 0.5f, place6.y - 0.5f, 0);
      tmpPlace[7] = new Vector3(place7.x - 0.5f, place7.y - 0.5f, 0);
      tmpPlace[8] = new Vector3(place8.x - 0.5f, place8.y - 0.5f, 0);
      tmpPlace[9] = new Vector3(place9.x - 0.5f, place9.y - 0.5f, 0);
      tmpPlace[10] = new Vector3(place10.x - 0.5f, place10.y - 0.5f, 0);
      tmpPlace[11] = new Vector3(place11.x - 0.5f, place11.y - 0.5f, 0);
      tmpPlace[12] = new Vector3(place12.x - 0.5f, place12.y - 0.5f, 0);
      tmpPlace[13] = new Vector3(place13.x - 0.5f, place13.y - 0.5f, 0);
      tmpPlace[14] = new Vector3(place14.x - 0.5f, place14.y - 0.5f, 0);
      tmpPlace[15] = new Vector3(place15.x - 0.5f, place15.y - 0.5f, 0);

      
        }

        void OnDestroy()
      => _pipeline.Dispose();


    public int tmpGuu=0;
    // public int Pose(){
    //     if(tmpGuu>50){
    //        // gameController.NextPosition(place);
            
    //         Debug.Log("ぐー!!!!!!!!!!!!!!!!!!!!");
    //         return 1;
    //     }else{
    //         return 0;
    //     }
    // }
    public int tmpHitosashi=0;
    public int PoseHitosashi(Vector3 place){
    //  Debug.Log("tmpHitosashi:"+tmpHitosashi);
        if(3<=tmpHitosashi){
           // creObj.InstanceObject(place);
         //  place.z=-0.5f;
          // Instantiate(tmp,place,Quaternion.identity);
          gameController.CreateBlock(place);
          // Debug.Log("place:"+place);
            //Debug.Log("人差し指!!!!!!!!!!!!!!!!!!!!");
            return 1;
        }else{
            return 0;
        }
    }
    public int tmpHutasashi=0;
    public int PoseHutasashi(Vector3 place){
       
        //Debug.Log("tmpHutasashi:"+tmpHutasashi);
        if(5<=tmpHutasashi){
            gameController.NextPosition(place);
            //Debug.Log("ピース!!!!!!!!!!!!!!!!!!!!");
            return 1;
        }else{
            return 0;
        }
    }



    void LateUpdate()
    {
        int checkCount=0;
        int  checkCountHitosashi=0;
         int  checkCountHutasashi=0;
        // Feed the input image to the Hand pose pipeline.
        _pipeline.UseAsyncReadback = _useAsyncReadback;
        _detector.ProcessImage(_webcam.Texture);
        _pipeline.ProcessImage(_webcam.Texture);

        var layer = gameObject.layer;
          //  int check = 0;
            

            // Joint balls
            for (var i = 0; i < HandPipeline.KeyPointCount; i++)
            {
                var xform = CalculateJointXform(_pipeline.GetKeyPoint(i));
                // Debug.Log("xform:" + xform);
                //Debug.Log("_pipeline:" + _pipeline);
                //Debug.Log("HandPipeline.KeyPointCount:" + HandPipeline.KeyPointCount);
                Graphics.DrawMesh(_jointMesh, xform, _jointMaterial, layer);
              
                    target[i].rectTransform.position = new Vector3(150, 150, 0);
                    target[i].rectTransform.position = new Vector3((float)_pipeline.GetKeyPoint(i).x * 500 + 533, (float)_pipeline.GetKeyPoint(i).y * 500 + 300, 0);
                    target[i].rectTransform.position = (_pipeline.GetKeyPoint(i));
                  //  Debug.Log("target[i].rectTransform.position:"+target[i].rectTransform.position);
                   // Debug.Log("target[i].position:"+target[i].rectTransform.localPosition);
                   // Debug.Log("target.position:"+target[i].transformposition)
                   // target[i].GetComponentInChildren<Text>().text="" + i + "";
                 //  targetText[0].text =""+i+"";
               // Debug.Log("_pipeline.GetKeyPoint(i):" + _pipeline.GetKeyPoint(i));//RectTransformUtility.WorldToScreenPoint(Camera.main, target.position)
          //          Debug.Log(" target.rectTransform.position:" + target[i].rectTransform.position);
              if(_pipeline.GetKeyPoint(i).z<0){
                  checkCount+=1;
              }
              if(i==6||i==7||i==8){
                  if(0<=_pipeline.GetKeyPoint(i).z) {
                      checkCountHitosashi+=2;
                  }
              }
              else{
                  if(_pipeline.GetKeyPoint(i).z<0) {
                      checkCountHitosashi+=1;
                  }
              }
              if(18<checkCountHitosashi){
                this.tmpHitosashi+=1;
               // Debug.Log("一刺し");

            }else{
                this.tmpHitosashi=0;
            }



            if(i==18||i==19||i==20){
                  if(0<=_pipeline.GetKeyPoint(i).z) {
                      checkCountHutasashi+=2;
                  }
              }
              else{
                  if(_pipeline.GetKeyPoint(i).z<0) {
                      checkCountHutasashi+=1;
                  }
              }
              if(21<checkCountHutasashi){
                this.tmpHutasashi+=1;
             //   Debug.Log("2刺し");

            }else{
                this.tmpHutasashi=0;
            }





            }




              
            if(15<checkCount){
                this.tmpGuu+=1;

            }else{
                this.tmpGuu=0;
            }

           
           int tmp2=PoseHutasashi(_pipeline.GetKeyPoint(20));
           int tmp1=0;
           if (tmp2==0){
                tmp1=PoseHitosashi(_pipeline.GetKeyPoint(8));
           }
          // int tmp1=PoseHitosashi(_pipeline.GetKeyPoint(8));
        //    if(tmp1==0&&tmp2==0){
        //         int tmp0=Pose();

        //    }
          
            

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

      Vector4 place = _detector.UpdatePostReadCache()[1];
      Vector4 place1 = _detector.UpdatePostReadCache()[205];
      Vector4 place2 = _detector.UpdatePostReadCache()[425];
      Vector4 place3 = _detector.UpdatePostReadCache()[33];
      Vector4 place4 = _detector.UpdatePostReadCache()[133];
      Vector4 place5 = _detector.UpdatePostReadCache()[263];
      Vector4 place6 = _detector.UpdatePostReadCache()[362];
      Vector4 place7 = _detector.UpdatePostReadCache()[168];
      Vector4 place8 = _detector.UpdatePostReadCache()[78];
      Vector4 place9 = _detector.UpdatePostReadCache()[13];
      Vector4 place10 = _detector.UpdatePostReadCache()[308];
      Vector4 place11 = _detector.UpdatePostReadCache()[14];
      Vector4 place12 = _detector.UpdatePostReadCache()[70];
      Vector4 place13 = _detector.UpdatePostReadCache()[55];
      Vector4 place14 = _detector.UpdatePostReadCache()[300];
      Vector4 place15 = _detector.UpdatePostReadCache()[285];

      targetFace[0].rectTransform.position = new Vector3(place.x - 0.5f, place.y - 0.5f, 0);
      targetFace[1].rectTransform.position = new Vector3(place1.x - 0.5f, place1.y - 0.5f, 0);
      targetFace[2].rectTransform.position = new Vector3(place2.x - 0.5f, place2.y - 0.5f, 0);
      targetFace[3].rectTransform.position = new Vector3(place3.x - 0.5f, place3.y - 0.5f, 0);
      targetFace[4].rectTransform.position = new Vector3(place4.x - 0.5f, place4.y - 0.5f, 0);
      targetFace[5].rectTransform.position = new Vector3(place5.x - 0.5f, place5.y - 0.5f, 0);
      targetFace[6].rectTransform.position = new Vector3(place6.x - 0.5f, place6.y - 0.5f, 0);
      targetFace[7].rectTransform.position = new Vector3(place7.x - 0.5f, place7.y - 0.5f, 0);
      targetFace[8].rectTransform.position = new Vector3(place8.x - 0.5f, place8.y - 0.5f, 0);
      targetFace[9].rectTransform.position = new Vector3(place9.x - 0.5f, place9.y - 0.5f, 0);
      targetFace[10].rectTransform.position = new Vector3(place10.x - 0.5f, place10.y - 0.5f, 0);
      targetFace[11].rectTransform.position = new Vector3(place11.x - 0.5f, place11.y - 0.5f, 0);
      targetFace[12].rectTransform.position = new Vector3(place12.x - 0.5f, place12.y - 0.5f, 0);
      targetFace[13].rectTransform.position = new Vector3(place13.x - 0.5f, place13.y - 0.5f, 0);
      targetFace[14].rectTransform.position = new Vector3(place14.x - 0.5f, place14.y - 0.5f, 0);
      targetFace[15].rectTransform.position = new Vector3(place15.x - 0.5f, place15.y - 0.5f, 0);
      //Debug.Log("VertexBuffer[0]:" + _detector.UpdatePostReadCache()[0]);

      
      for(int i=0;i<16;i++){
          diff[i]=(faceCount.DiffFaceScore(tmpPlace[i],targetFace[i].rectTransform.position));
          
      }
      faceCount.CalcFaceScore(diff);








      tmpPlace[0]=targetFace[0].rectTransform.position;
      tmpPlace[1]=targetFace[1].rectTransform.position;
      tmpPlace[2]=targetFace[2].rectTransform.position;
      tmpPlace[3]=targetFace[3].rectTransform.position;
      tmpPlace[4]=targetFace[4].rectTransform.position;
      tmpPlace[5]=targetFace[5].rectTransform.position;
      tmpPlace[6]=targetFace[6].rectTransform.position;
      tmpPlace[7]=targetFace[7].rectTransform.position;
      tmpPlace[8]=targetFace[8].rectTransform.position;
      tmpPlace[9]=targetFace[9].rectTransform.position;
      tmpPlace[10]=targetFace[10].rectTransform.position;
      tmpPlace[11]=targetFace[11].rectTransform.position;
      tmpPlace[12]=targetFace[12].rectTransform.position;
      tmpPlace[13]=targetFace[13].rectTransform.position;
      tmpPlace[14]=targetFace[14].rectTransform.position;
      tmpPlace[15]=targetFace[15].rectTransform.position;









    }
    //  public void OnRenderObject()
    // {
    //   var layer=gameObject.layer;
    //   // Wireframe mesh rendering
    //   _material.SetBuffer("_Vertices", _detector.VertexBuffer);
    //   _material.SetPass(0);
    //   Graphics.DrawMeshNow(_template, Matrix4x4.identity,layer);
    //   //Debug.Log("_material:"+_material);

    //   // Keypoint marking
    //   _material.SetBuffer("_Vertices", _detector.VertexBuffer);
    //   _material.SetPass(1);
    //   //Debug.Log("_material" + _material);
    //   Graphics.DrawProceduralNow(MeshTopology.Lines, 400, 1);
    // }

    #endregion
}

} // namespace MediaPipe.HandPose
