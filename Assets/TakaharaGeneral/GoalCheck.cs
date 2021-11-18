using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCheck : MonoBehaviour
{
    
    [SerializeField] private GameController gameController;
    [SerializeField] private EnemyList enemyList;
    public int sceneState=0;
    void Start()
    {
        GameObject tmpCon=GameObject.Find("GameController");
        gameController=tmpCon.GetComponent<GameController>();
        sceneState=gameController.sceneState;
        GameObject enelistTmp;
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneState=gameController.sceneState;
        
    }
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="MainCharacter"){
            Debug.Log("You did it !!!!!!!!!!!!!!!!!");
            gameController.sceneState+=1;
            gameController.StateChange();
            SceneManager.LoadScene("Tmp");

            
        }
        
    }
}
