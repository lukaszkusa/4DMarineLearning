using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProceduraLangController : MonoBehaviour
{
     public Dropdown dropDown;

    public Sprite[] flags;

    public GameObject subtittlePanel;

    private bool isOn = true;

    public static Dictionary<String, String> Fields { get; private set; }

    private static List<string> subLines = new List<string>();
    private static List<string> gallerySublines = new List<string>();
    private static List<string> progLines = new List<string>();


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
    public void showOrCloseSub(){
        if(isOn){
            subtittlePanel.gameObject.SetActive(false);
            isOn = false;
        }
        else if(!isOn){
            subtittlePanel.gameObject.SetActive(true);
            isOn = true;
        }

    }
    public void changeLanguage()
    {
        LoadLanguage(dropDown.captionText.text);
    }

    private static void LoadLanguage( string lang)
    {    
        Fields = new Dictionary<string, string>();
        subLines = new List<string>();
        Fields.Clear();
        var textAsset = Resources.Load(@"Languages/" + lang.ToLower());
        string allTexts = "";
        if (textAsset == null)
            Debug.LogError("File not found for I18n: Assets/Resources/" + lang + ".txt");
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
                if(key == "info" ){
                    subLines.Add(value);
                }
                else if(key =="gallery"){
                    gallerySublines.Add(value);
                }
                else Fields.Add(key, value);
            }
        } 
         GameObject thePlayer = GameObject.Find("Procedura");
        if(thePlayer) {
            ProderController proderController = thePlayer.GetComponent<ProderController>();
            LektorController lektorController = thePlayer.GetComponent<LektorController>();
            lektorController.setLanguage(lang);
            lektorController.Play(proderController.CountSteps);
            Fields.Add("info", subLines[proderController.CountSteps]);
            
        }
        Fields.Add("gallery", gallerySublines[0]);
    
    }

    public void SetSub(int i){
        if(Fields.ContainsKey("info"))Fields.Remove("info");
        Fields.Add("info", subLines[i]);
    }
    
    public void SetSubGallery(int i){
         if(Fields.ContainsKey("gallery"))Fields.Remove("gallery");
         Fields.Add("gallery", gallerySublines[i] );
    }

    
}
