using UnityEngine;
using UnityEngine.UI;


//This script ensures that whatever language is selected, the button for said language becomes unavailable.
//Then if another language is selected it becomes available once more. 
public class FlagButtonPolish : MonoBehaviour
{
    Button button;
    public GameManager.LANGUAGE lang;
    void Start()
    {
        button = GetComponent<Button>();
    }


    void Update()
    {
        if (button.interactable)
        {
            if (GameManager.language == lang)
            {
                button.interactable = false;
            }
        }
        else
        {

            if (GameManager.language != lang)
            {
                button.interactable = true;
            }
        }
    }
}
