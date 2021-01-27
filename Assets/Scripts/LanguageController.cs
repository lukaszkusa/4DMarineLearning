using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LanguageController : MonoBehaviour
{

    public Dropdown dropDown;

    public Sprite[] flags;

    private bool isOn = false;

    public static Dictionary<String, String> Fields { get; private set; }

    private static List<string> gallerySublines = new List<string>();
    private static List<string> infoSublines = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        LoadLanguage("PL");
        dropDown.ClearOptions();
        List<Dropdown.OptionData>flagItems = new List<Dropdown.OptionData>();

        foreach (var flag in  flags)
        {
            string flagName = flag.name;
            int dot = flag.name.IndexOf('.');

            if(dot >=0){
                flagName = flagName.Substring(dot+1);
            }

            var flagOption = new Dropdown.OptionData(flagName, flag);
            flagItems.Add(flagOption);
        }

        dropDown.AddOptions(flagItems);
        //Fields.Add("info", subLines[0]);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeLanguage()
    {
        LoadLanguage(dropDown.captionText.text);
    }

   private static void LoadLanguage( string lang)
    {    
        Fields = new Dictionary<string, string>();
                Fields.Clear();
        var textAsset = Resources.Load(@"Languages/" + lang.ToLower());
        string allTexts = "";
        if (textAsset == null)
            Debug.LogError("File not found for I18n: Assets/Resources/Languages/" + lang + ".txt");
        allTexts = (textAsset as TextAsset).text;
        string[] lines = allTexts.Split(new string[] { "\r\n", "\n" },
            StringSplitOptions.None);
        string key, value;

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].IndexOf("=") >= 0 && !lines[i].StartsWith("#"))
            {
                key = lines[i].Substring(0, lines[i].IndexOf("="));
                value = lines[i].Substring(lines[i].IndexOf("=") + 1,
                        lines[i].Length - lines[i].IndexOf("=") - 1).Replace("\\n", Environment.NewLine);
            
                if(key == "info"){
                    infoSublines.Add(value);
                }
                else if(key =="gallery"){
                    gallerySublines.Add(value);
                }
                else Fields.Add(key, value);
            }
        } 
        Fields.Add("gallery", gallerySublines[0]);
    
    }
    
    public void SetSubGallery(int i){
         if(Fields.ContainsKey("gallery"))Fields.Remove("gallery");
         Fields.Add("gallery", gallerySublines[i] );
    }
   
}
