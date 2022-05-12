using UnityEngine;
using TMPro;

// The localisation script essentially looks up the localization dictionary and compares its ID to the id sets found in the dictionary.
// Once it's found a match it sets itself according to the langauge. 
[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalisationScript : MonoBehaviour
{
    private TextMeshProUGUI text;
    
    localizationDictionary.DictionaryEntry[] dictionary;
    public int id;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        GameManager._instance.onLanguageChange += DisplayProperText;
        dictionary = localizationDictionary._instance.entries;
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
            for (int i = 0; i < dictionary.Length; i++)
            {
                if (dictionary[i].id == id)
                {
                    text.text = dictionary[i].English;
                }
            }
        }
        else
        {
            for (int i = 0; i < dictionary.Length; i++)
            {
                if (dictionary[i].id == id)
                {
                    text.text = dictionary[i].Maltese;
                }
            }
        }
    }


}
