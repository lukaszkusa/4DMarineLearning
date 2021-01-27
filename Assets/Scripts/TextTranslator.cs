using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextTranslator : MonoBehaviour
{
     public string TextId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var text = GetComponent<Text>();
        if (text != null)
               try
               {
                   text.text = ProceduraLangController.Fields[TextId];
               }
               catch (System.Exception)
               {
                   
                
               } 
    }
}