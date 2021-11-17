using UnityEngine;
using UnityEngine.UI;
using MediaPipe.FaceLandmark;
using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;

namespace MediaPipe
{

  public sealed class Visualizer : MonoBehaviour
  {
    #region Editable attributes

    [SerializeField] WebcamInput _webcam = null;
    [SerializeField] RawImage _previewUI = null;
    [Space]
    [SerializeField] ResourceSetFace _resources = null;
    [SerializeField] Mesh _template = null;
    [SerializeField] Shader _shader = null;
    public List<Image> targetFace = new List<Image>();

    #endregion

    #region Private members

    FaceLandmarkDetector _detector;
    Material _material;

    #endregion

    #region MonoBehaviour implementation

    void Start()
    {
      _detector = new FaceLandmarkDetector(_resources);
      _material = new Material(_shader);
      Debug.Log("Material:" + _material);
    }

    void OnDestroy()
    {
      _detector.Dispose();
      Destroy(_material);
    }

    void LateUpdate()
    {
      // Face landmark detection
      _detector.ProcessImage(_webcam.Texture);

      // UI update
      _previewUI.texture = _webcam.Texture;
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
      Debug.Log("VertexBuffer[0]:" + _detector.UpdatePostReadCache()[0]);






      //Debug.Log(_detector.UpdatePostReadCache().Length);
      // for (int i = 0; i < _detector.UpdatePostReadCache().Length; i++)
      // {
      //   Debug.Log("VertexBuffer[i]:" + _detector.UpdatePostReadCache()[i]);
      // }
    }

    public void OnRenderObject()
    {
      var layer=gameObject.layer;
      // Wireframe mesh rendering
      _material.SetBuffer("_Vertices", _detector.VertexBuffer);
      _material.SetPass(0);
      Graphics.DrawMeshNow(_template, Matrix4x4.identity,layer);
      //Debug.Log("_material:"+_material);

      // Keypoint marking
      _material.SetBuffer("_Vertices", _detector.VertexBuffer);
      _material.SetPass(1);
      //Debug.Log("_material" + _material);
      Graphics.DrawProceduralNow(MeshTopology.Lines, 400, 1);
    }

    #endregion
  }

} // namespace MediaPipe
