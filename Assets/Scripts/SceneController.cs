using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;
    // Start is called before the first frame update
    public void loadScene(){
        SceneManager.LoadScene(index);
    }
   
}
