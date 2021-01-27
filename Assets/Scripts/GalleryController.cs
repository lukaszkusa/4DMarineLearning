using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GalleryController : MonoBehaviour
{
    public Camera camera;
    public Texture[] ar;
    public Button prev;
    public Button next;
    public RawImage raw;
    public GameObject panel;

    private bool isOpen = false;
    public Sprite a;
    public Sprite b;

    private ProceduraLangController languageController;

    private int count = 0;
    void Start()
    {
        raw.texture = ar[0];
        count = 0;
        next.gameObject.SetActive(true);
        prev.gameObject.SetActive(false);
        GameObject language = GameObject.Find("Language");
        if(language)  languageController = language.GetComponent<ProceduraLangController>();
    }

    // Update is called once per frame
    void Update()
    {
   
        if (count > 0) prev.gameObject.SetActive(true);
        if (count >= 0 && count < ar.Length-1) next.gameObject.SetActive(true);

    }
    // public void prepare()
    // {
    //     if(open == false)
    //     {
    //         open = true;
    //         button.sprite = b;
    //     }
    //     else
    //     {
    //         open = false;
    //         button.sprite = a;
    //     }
       
    // }
    public void explore()
    {
        count++;
        if (count == ar.Length - 1)
        {
            next.gameObject.SetActive(false);
        }
        raw.texture = ar[count];
        languageController.SetSubGallery(count);
    }
    public void dexplore()
    {
        count--;
        if (count == 0)
        {
            prev.gameObject.SetActive(false);
        }
        raw.texture = ar[count];
         languageController.SetSubGallery(count);
    }

    public void OpenOrClose(){
        if(!isOpen){
            camera.GetComponent<CameraBehavior>().stopManualRotate();
            panel.gameObject.SetActive(true);
            isOpen = true;
        }
        else{
            panel.gameObject.SetActive(false);
            isOpen = false;
        }

    }

    
}
