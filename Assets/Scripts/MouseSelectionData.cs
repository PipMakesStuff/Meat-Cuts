using System;
using UnityEngine;

public class MouseSelectionData : MonoBehaviour
{
    /// <summary>
    /// This Script goes on the object that follows the mouse/player touch input. 
    /// It holds the relevant data temporarily and checks if the input for where the player dragged the meat is correct or not.
    /// </summary>
    public static MouseSelectionData _instance;
    public GameObject selectedOverlay, correctWaypoint;
    public int selectedID;
    public float dis;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        GameStateTrigger._instance.onStateChange += ClearData;
    }

    private void OnDestroy()
    {
        GameStateTrigger._instance.onStateChange -= ClearData;
    }

    void ClearData()
    {
        if (GameStateTrigger.state == GameStateTrigger.GAMESTATE.MAINMENU)
        {
            selectedOverlay = null;
            correctWaypoint = null;
            selectedID = -1;
        }        
    }

    public event Action<int> onCorrect;
    public event Action onIncorrect;

    public void CorrectTrigger(int i)
    {
        if (onCorrect != null)
        {
            onCorrect(i);
        }
    }

    public void WrongTrigger()
    {
        if (onCorrect != null)
        {
            onIncorrect();
        }
    }


    void Update()
    {
        if (GameStateTrigger.state == GameStateTrigger.GAMESTATE.COW|| GameStateTrigger.state == GameStateTrigger.GAMESTATE.PIG)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (correctWaypoint!=null)
                {
                    if (Vector2.Distance(transform.position, correctWaypoint.transform.position) <= dis)
                    {
                        selectedOverlay.SetActive(true);
                        _instance.CorrectTrigger(selectedID);
                        SuccessTracker._instance.currentSuccesses++;

                        selectedOverlay = null;
                        correctWaypoint = null;
                        selectedID = -1;

                    }
                    else
                    {
                        _instance.WrongTrigger();

                        selectedOverlay = null;
                        correctWaypoint = null;
                        selectedID = -1;
                    }
                }                
            }
        }
        
    }

   
    
}
