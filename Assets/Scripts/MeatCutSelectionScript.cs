using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MeatCutSelectionScript : MonoBehaviour
{
    /// <summary>
    /// This scrip is located on each instance of the dragable meat image.
    /// They store the data for the correct waypoint/answer and the overlay that should trigger for their relevent meat cut
    /// They also have an ID which allows them to be locked via an event.
    /// </summary>

    MouseSelectionDisplay msd;
    Image image;
    public float distance;
    public string input;
    bool selected;
    public Color blackedOut;
    public bool locked;

    public int ID;
    public GameObject selectedOverlay, correctWaypoint;

    private GameObject checkMark;
    void Start()
    {
        msd = FindObjectOfType<MouseSelectionDisplay>();
        image = GetComponent<Image>();
        MouseSelectionData._instance.onCorrect += LockedState;
        GameStateTrigger._instance.onStateChange += ResetProgress;
        checkMark = transform.GetChild(0).gameObject;
        checkMark.SetActive(false);

    }
    
    private void OnDestroy()
    {
        MouseSelectionData._instance.onCorrect -= LockedState;
        GameStateTrigger._instance.onStateChange -= ResetProgress;
    }
    // Update is called once per frame
    void Update()
    {
        if (locked!=true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Vector2.Distance(msd.transform.position, transform.position) < distance)
                {
                    msd.SetDisplay(input);
                    selected = true;
                    SetDisplay(blackedOut);
                    MouseSelectionData._instance.selectedID = ID;
                    MouseSelectionData._instance.selectedOverlay = selectedOverlay;
                    MouseSelectionData._instance.correctWaypoint = correctWaypoint;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                msd.Clear();
                if (selected == true)
                {
                    selected = false;
                    SetDisplay(Vector4.one);
                }
            }
        }
        
    }

    public void LockedState(int _id)
    {
        if (_id == ID)
        {
            locked = true;
            SetDisplay(blackedOut);
            msd.Clear();
            checkMark.SetActive(true);
        }
    }

    void SetDisplay(Color color)
    {
        image.color = color;
    }

    void ResetProgress()
    {
        locked = false;
        SetDisplay(Vector4.one);
        checkMark.SetActive(false);
    }
}
