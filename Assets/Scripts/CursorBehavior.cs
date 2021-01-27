using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Cursor = UnityEngine.Cursor;

public class CursorBehavior :MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
   private CursorMode curMode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;
    

    private Text label;
    private Button button;

    void Start()
    {


    }
   
    // Update is called once per frame
    void Update()
    {
     
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Button button = this.GetComponent<Button>();
        Enter(button);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       Exit();
    }
     public void OnPointerClick(PointerEventData pointerEventData){
         Exit();
     }



    private void Enter(Button b1)
    {

        if (b1.tag == "door")
        {
             Texture2D texture =  Camera.main.GetComponent<CursorController>().doorTexture;

            UnityEngine.Cursor.SetCursor(texture, new Vector2(1, 1), curMode);
           
        }
        else if(b1.tag == "GoHead")
        {
            Texture2D texture =  Camera.main.GetComponent<CursorController>().goTexture;

            UnityEngine.Cursor.SetCursor(texture, new Vector2(5, 5), curMode);

        }
        else if (b1.tag == "UpStairs")
        {
            Texture2D texture =  Camera.main.GetComponent<CursorController>().upStairs;
            UnityEngine.Cursor.SetCursor(texture, new Vector2(1, 1), curMode);
        }
         else if (b1.tag == "click")
        {
            Texture2D texture = Camera.main.GetComponent<CursorController>().clickButton;
            UnityEngine.Cursor.SetCursor(texture, new Vector2(5, 5), curMode);
        }
        else if (b1.tag == "dnStairs")
        {
            Texture2D texture =  Camera.main.GetComponent<CursorController>().dnStairs;
            UnityEngine.Cursor.SetCursor(texture, new Vector2(1, 1), curMode);
        }
    }
  
    public void Exit()
    {
       Texture2D defaultTexture =  Camera.main.GetComponent<CursorController>().defaultTexture;
       UnityEngine.Cursor.SetCursor(defaultTexture,  Vector2.zero,curMode); 
        
    }
    public void setClickCursor(){
        Texture2D texture = Camera.main.GetComponent<CursorController>().clickButton;
            UnityEngine.Cursor.SetCursor(texture, new Vector2(5, 5), curMode);
    }
}
