using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ProderController : MonoBehaviour
{

    public List<Transform> Steps = new List<Transform>();
    public Transform maszynownia;
    public Button nextButton;
    public Button prevButton;
    public Button endButton;
    public Canvas oilButton;
    public Canvas oilPanel;
    public int CountSteps = 0;
    private int lektorStep = 0;
    private bool isPause = false;
    public int timeToActive= 3;
    
    
    void Start()
    {
        gameObject.GetComponent<LektorController>().Play(0);
    }
    public void Restart(){
        CountSteps = 0;
        lektorStep = 0;
        foreach (var step in Steps)
        {
            step.gameObject.SetActive(false);
        }
        Steps[0].gameObject.SetActive(true);
        endButton.gameObject.SetActive(false);
        gameObject.GetComponent<ProceduraLangController>().SetSub(lektorStep);
        gameObject.GetComponent<LektorController>().Play(lektorStep);
    }

    IEnumerator TheSequence(){
        yield return new WaitForSeconds(timeToActive);
        nextButton.gameObject.SetActive(true);
    }



    void Update()
    {
        if(CountSteps == 1 || CountSteps == 4 || CountSteps == 9 || CountSteps == 11){
            StartCoroutine(TheSequence());
            prevButton.gameObject.SetActive(true);
        }
        else if(CountSteps == 0 )
        {
            prevButton.gameObject.SetActive(false);
        }

        if(CountSteps ==2 || CountSteps ==5 || CountSteps == 10 || CountSteps ==12){
                nextButton.gameObject.SetActive(false);
        }
        if(CountSteps == 3){
            oilButton.gameObject.SetActive(true);
        }
        if(CountSteps == 8){
            oilPanel.gameObject.SetActive(true);
        }
      
        if(CountSteps == 14){
            endButton.gameObject.SetActive(true);
        }
    }
    public void NextSubtitle(){
        if(!isPause){
            lektorStep++;
            gameObject.GetComponent<ProceduraLangController>().SetSub(lektorStep);
            gameObject.GetComponent<LektorController>().Play(lektorStep);
        }
    }

      public void PrevSubtitle(){
        if(!isPause){
            lektorStep--;
            gameObject.GetComponent<ProceduraLangController>().SetSub(lektorStep);
            gameObject.GetComponent<LektorController>().Play(lektorStep);
        }
    }
    public void nextAction(){
        if(Steps[CountSteps].tag != "Sphera" && Steps[CountSteps].tag != "child")Steps[CountSteps].gameObject.SetActive(false);
        CountSteps++;
        Steps[CountSteps].gameObject.SetActive(true);
        if(Steps[CountSteps].tag == "Sphera")Camera.main.GetComponent<CameraBehavior>().GoTo(Steps[CountSteps]);
        
       NextSubtitle();
    }
    public void prevAction(){
        if(CountSteps == 13){
            Camera.main.GetComponent<CameraBehavior>().GoTo(Steps[getLastSphera()]);
            Steps[CountSteps].gameObject.SetActive(false);
             CountSteps--;
             Steps[CountSteps].gameObject.SetActive(true);
            Steps[CountSteps-1].gameObject.SetActive(true);
        }
        else if(CountSteps == 6){
            Camera.main.GetComponent<CameraBehavior>().GoTo(Steps[getLastSphera()]);
            Steps[CountSteps].gameObject.SetActive(false);
            CountSteps--;
            Steps[CountSteps].gameObject.SetActive(true);
        }
       else if(CountSteps == 8){
            Steps[CountSteps-2].gameObject.SetActive(true);
            Steps[CountSteps].gameObject.SetActive(false);
            CountSteps-=2;
            lektorStep--;
        }
        else if(CountSteps == 10){
            if(!maszynownia.gameObject.activeSelf){
                 Steps[CountSteps].gameObject.SetActive(false);
                CountSteps-=2;
                Steps[CountSteps].gameObject.SetActive(true);
            }
            else{
                maszynownia.gameObject.SetActive(false);
                Camera.main.GetComponent<CameraBehavior>().GoTo(Steps[getLastSphera()]);
                lektorStep++;
            }

        }
        else {
             if(Steps[CountSteps].tag == "Sphera" )Camera.main.GetComponent<CameraBehavior>().GoTo(Steps[getLastSphera()]);
            Steps[CountSteps].gameObject.SetActive(false);
            CountSteps--;
            Steps[CountSteps].gameObject.SetActive(true);    
        }
       
        PrevSubtitle(); 
    }
    public void pauseLektor(){
        isPause = true;
    }
    public void startLektor(){
        isPause = false;
    }
    private int getLastSphera(){
        for(int i = CountSteps-1; i > 0; i--){
            if(Steps[i].tag == "Sphera")return i;
        }
        return 0;
    }
}
