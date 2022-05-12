using System;
using UnityEngine;

//A singleton instance of a dictionary holding a set of english and maltese words with an ID to link them together.
//These values are read by the localisationScript.
public class localizationDictionary : MonoBehaviour
{
    public static localizationDictionary _instance;
    public DictionaryEntry[] entries;
    [Serializable]
    public struct DictionaryEntry
    {
        //Whatever string value is first determines the name within the inspector for the entry. 
        public string English;
        public string Maltese;
        
        public int id;
        
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
}
