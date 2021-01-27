using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Events; 
using UnityEngine.EventSystems; 

public class ChangeColor  : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      public void OnPointerEnter(PointerEventData eventData) {
          GetComponent<Text>().color = color; // Changes the colour of the text
    }
 
    public void OnPointerExit(PointerEventData eventData) {
          GetComponent<Text>().color = Color.white; // Changes the colour of the text
    }
}
