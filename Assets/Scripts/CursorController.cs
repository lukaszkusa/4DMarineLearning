using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

        public CursorMode cursorMode = CursorMode.Auto;
    public Texture2D doorTexture;
    public Texture2D defaultTexture;
    public Texture2D goTexture;
    public Texture2D upStairs;
    public Texture2D clickButton;
    public Texture2D dnStairs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
     }
     public void exit(){
           Cursor.SetCursor(null,  new Vector2(1, 1), cursorMode);
     }
     public void set(){
           Texture2D defaultTexture =  Camera.main.GetComponent<CursorController>().defaultTexture;
           UnityEngine.Cursor.SetCursor(defaultTexture,  Vector2.zero,CursorMode.ForceSoftware); 
     }

     public void setClickButton(){
           Texture2D defaultTexture =  Camera.main.GetComponent<CursorController>().clickButton;
           UnityEngine.Cursor.SetCursor(defaultTexture,  Vector2.zero,CursorMode.ForceSoftware); 
     }
}
