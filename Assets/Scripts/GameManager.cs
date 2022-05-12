using System;
using UnityEngine;

/// <summary>
/// Game manager would original handle both language and gamestate, but a decision was made to split those two scripts up to
/// allow for better code readability. GameManager manages the language states of the game. 
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public enum LANGUAGE {ENGLISH, MALTESE};
    public static LANGUAGE language; //This can be used to get a reference to the current language for localisation.
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            language = LANGUAGE.ENGLISH;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    

    public event Action onLanguageChange;

    public void LanguageChangeTrigger()
    {
        if (onLanguageChange!=null)
        {
            onLanguageChange();
        }
    }

    public void ChangeLanguage(int _language)
    {
        if (_language == 0)
        {
            language = LANGUAGE.ENGLISH;
        }
        else
        {
            language = LANGUAGE.MALTESE;
        }
        
        _instance.LanguageChangeTrigger();
    }

}
