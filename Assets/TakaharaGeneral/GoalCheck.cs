using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    
    [SerializeField] private GameController gameController;
    public int sceneState=0;
    void Start()
    {
        GameObject tmpCon=GameObject.Find("GameController");
        gameController=tmpCon.GetComponent<GameController>();
        sceneState=gameController.sceneState;
        
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

            
        }
        
    }
}
