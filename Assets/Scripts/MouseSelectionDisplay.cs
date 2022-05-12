using UnityEngine;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(SpriteLibrary))]
[RequireComponent(typeof(SpriteRenderer))]
public class MouseSelectionDisplay : MonoBehaviour
{
    /// <summary>
    /// This script handles the meat display, for dragging the different meat cuts around. It ensures that the image you clicked
    /// on is the image you're dragging around by having its SetDisplay function used in MeatCutSelection Script
    /// </summary>
    private SpriteRenderer display;
    private SpriteLibrary library; //A Sprite library is used as just a pre-made convinent method of refering to spesific sprites.

    private void Awake()
    {
        display = GetComponent<SpriteRenderer>();
        library = GetComponent<SpriteLibrary>();
    }
    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        transform.position = worldPosition;

    }
    public void SetDisplay(string input)
    {
        if (GameStateTrigger.state == GameStateTrigger.GAMESTATE.COW)
        {
            display.sprite = library.GetSprite("Cow", input);
        }
        if (GameStateTrigger.state == GameStateTrigger.GAMESTATE.PIG)
        {
            display.sprite = library.GetSprite("Pig", input);
        }
    }
    public void Clear()
    {
        display.sprite = null;
    }
}
