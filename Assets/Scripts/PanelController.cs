using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    private Button button;
    public GameObject [] panels; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Open(GameObject p){
        
        if(p.active){
            p.SetActive(false);
             Camera.main.GetComponent<CameraBehavior>().startManualRotate();
        }
        else{
            DisablePanels();
            p.SetActive(true);
        }
    }
    public void SetButton(Button b){
        button = b;
    }

    public void DisablePanels(){
        foreach (var panel in panels)
        {
           
            panel.SetActive(false);
        }
    }
}
