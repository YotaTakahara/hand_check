using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
namespace MediaPipe.HandPose {

public sealed class HandAnimator : MonoBehaviour
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


        #endregion

        #region Private members

        HandPipeline _pipeline;


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

        void Start()
        {
         _pipeline = new HandPipeline(_resources);
            for (int i = 0; i < target.Count;i++)
            {
            //    Debug.Log("target[i].GetComponent<Text>():" + target[i].GetComponentInChildren<Text>());
                // Text tmp = target[i].GetComponentInChildren<Text>();
                // targetText.Add(tmp);
            }
            //  Debug.Log("")
        }

        void OnDestroy()
      => _pipeline.Dispose();


    public int tmp=0;
    public int Pose(){
        if(tmp>50){
            Debug.Log("??????!!!!!!!!!!!!!!!!!!!!");
            return 1;
        }else{
            return 0;
        }
    }


    void LateUpdate()
    {
        int checkCount=0;
        // Feed the input image to the Hand pose pipeline.
        _pipeline.UseAsyncReadback = _useAsyncReadback;
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
                    target[i].GetComponentInChildren<Text>().text="" + i + "";
                 //  targetText[0].text =""+i+"";
               // Debug.Log("_pipeline.GetKeyPoint(i):" + _pipeline.GetKeyPoint(i));//RectTransformUtility.WorldToScreenPoint(Camera.main, target.position)
          //          Debug.Log(" target.rectTransform.position:" + target[i].rectTransform.position);
              if(_pipeline.GetKeyPoint(i).z<0){
                  checkCount+=1;
              }
                    
                

            }
            if(15<checkCount){
                this.tmp+=1;

            }else{
                this.tmp=0;
            }

           int tmp=Pose();

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

    #endregion
}

} // namespace MediaPipe.HandPose
