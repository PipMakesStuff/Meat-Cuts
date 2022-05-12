using UnityEngine;

/// <summary>
/// This takes two graphics, and switches them depending on the language mode. 
/// This is primarily used by the big header logo. 
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class GraphicLocalisation : MonoBehaviour
{
    private SpriteRenderer image;
    public Sprite[] content;

    private void Start()
    {
        GameManager._instance.onLanguageChange += DisplayProperText;
        image = GetComponent<SpriteRenderer>();
        DisplayProperText();
    }

    private void OnDestroy()
    {
        GameManager._instance.onLanguageChange -= DisplayProperText;
    }
    void DisplayProperText()
    {
        if (GameManager.language == GameManager.LANGUAGE.ENGLISH)
        {
            image.sprite = content[0];
        }
        else
        {
            image.sprite = content[1];
        }
    }
}
