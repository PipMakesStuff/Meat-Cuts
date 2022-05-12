using UnityEngine;

//This script is used by the selection buttons for the Menu, Cow, and Pig. It triggers a game state change. 
public class SelectionScript : MonoBehaviour
{
    public GameStateTrigger.GAMESTATE disirableState;
    public void Select()
    {
        //Debug.Log("Selected");
        GameStateTrigger.state = disirableState;
        GameStateTrigger._instance.StateChangeTrigger();
    }
}
