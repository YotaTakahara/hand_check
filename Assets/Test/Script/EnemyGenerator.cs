using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MediaPipe.HandPose;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject animatorVir;
    [SerializeField] private HandAnimator handAnimator;  
    [SerializeField] private GameObject enemy;
    [SerializeField] private Image cube;
    [SerializeField] private RectTransform rectTra;


    // Start is called before the first frame update
    void Start()
    {
        animatorVir=GameObject.Find("AnimatorVir");
        handAnimator=animatorVir.GetComponent<HandAnimator>();
        rectTra=GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void GenerateEne(){
        float tmpX=Random.Range(-0.5f,0.5f);
        float tmpY=Random.Range(-0.25f,0.15f);
        Vector3 where=new Vector3(tmpX,tmpY,-1);
        Instantiate(enemy,where,Quaternion.identity);
        Instantiate(cube);
        cube.GetComponent<UIFollowTarget>().target=enemy.transform;
        cube.transform.SetParent(this.gameObject.transform);


    }
}
