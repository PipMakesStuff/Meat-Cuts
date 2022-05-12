using UnityEngine;

//A small script which tracks the amount of correct answers the player has, and how many are needed to trigger the big success checkmark.
public class SuccessTracker : MonoBehaviour
{
    public GameObject greatSuccess;
    public int requiredSuccesses, currentSuccesses;
    public static SuccessTracker _instance;

    private void Awake()
    {
        if (_instance==null)
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
        GameStateTrigger._instance.onStateChange += ResetProgress;
        GameStateTrigger._instance.onStateChange += SetSuccess;
    }

    private void OnDestroy()
    {
        GameStateTrigger._instance.onStateChange -= ResetProgress;
        GameStateTrigger._instance.onStateChange -= SetSuccess;
    }
    void Update()
    {
        if (requiredSuccesses == currentSuccesses && !greatSuccess.active)
        {
            greatSuccess.SetActive(true);
        }
        else
        {
            if (requiredSuccesses != currentSuccesses && greatSuccess.active)
            {
                greatSuccess.SetActive(false);
            }
        }
    }

    public void ResetProgress()
    {
        currentSuccesses = 0;
    }

    public void SetSuccess()
    {
        switch (GameStateTrigger.state)
        {
            case GameStateTrigger.GAMESTATE.MAINMENU:
                requiredSuccesses = 1;
                break;

            case GameStateTrigger.GAMESTATE.COW:
                requiredSuccesses = 14;
                break;

            case GameStateTrigger.GAMESTATE.PIG:
                requiredSuccesses = 11;
                break;

            default:
                requiredSuccesses = 1;

                break;
        }
    }
}
