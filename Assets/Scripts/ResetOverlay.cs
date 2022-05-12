using UnityEngine;

//This script is attached to all the overlay visuals, and resets them whenever the player leaves the relevant area to go to the menu. 
public class ResetOverlay : MonoBehaviour
{
    void Start()
    {
        
        GameStateTrigger._instance.onStateChange += DisableOverlay;
    }

    private void OnDestroy()
    {
        GameStateTrigger._instance.onStateChange -= DisableOverlay;
    }
    private void DisableOverlay()
    {
        if (GameStateTrigger.state == GameStateTrigger.GAMESTATE.MAINMENU)
        {
            this.gameObject.SetActive(false);
        }
    }
}
