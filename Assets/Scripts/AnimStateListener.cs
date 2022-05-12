using UnityEngine;


//This script listens to the game state changes with up to 3 triggers being hooked to any one action. 
//It will execute the trigger depending on the button clicked, what element coresponds to what button is listed below. 
[RequireComponent(typeof(Animator))]
public class AnimStateListener : MonoBehaviour
{
    [Tooltip("0 for Main menu, 1 for cow, and 2 for pig.")]
    public string[] stateTriggers;
    //
    // Main Menu is [0]
    // Cow is [1]
    // Pig is [2]
    //

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        GameStateTrigger._instance.onStateChange += TriggerAnim;
    }

    private void OnDestroy()
    {
        GameStateTrigger._instance.onStateChange -= TriggerAnim;
    }

    void TriggerAnim()
    {
        switch (GameStateTrigger.state)
        {
            case GameStateTrigger.GAMESTATE.MAINMENU:
                anim.SetTrigger(stateTriggers[0]);                
                break;

            case GameStateTrigger.GAMESTATE.COW:
                anim.SetTrigger(stateTriggers[1]);
                break;

            case GameStateTrigger.GAMESTATE.PIG:
                anim.SetTrigger(stateTriggers[2]);                
                break;

            default:
                anim.SetTrigger(stateTriggers[0]);
                
                break;
        }
        
    }
}
