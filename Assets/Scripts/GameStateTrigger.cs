using System;
using UnityEngine;

//This script tracks the three different game states and contains an action which is triggered by moving to different menus. 
public class GameStateTrigger : MonoBehaviour
{
    public static GameStateTrigger _instance;

    public enum GAMESTATE { MAINMENU, COW, PIG };
    public static GAMESTATE state; //This can be used to get a reference to the current language for localisation.

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            state = GAMESTATE.MAINMENU;
            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        StateChangeTrigger();
    }

    public event Action onStateChange;

    public void StateChangeTrigger()
    {
        if (onStateChange != null)
        {
            onStateChange();
        }
    }
}
