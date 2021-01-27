using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{   
    public int timeToAutoRotate= 30;
    public Transform prev;
    private Transform next;
    private float speed = 3.5f;
    private const float V = 0.04f;
    private bool manualRotate = true;  
    private bool autoRotate = true;


    public void Start(){
        StartCoroutine("rotate");
    }

    IEnumerator rotate()
    {
        yield return new WaitForSeconds(timeToAutoRotate);
        Quaternion temp = Camera.main.transform.rotation;
        while (true)
        {
            Vector3 v;
            v.x = temp.x;
            v.y = Camera.main.transform.rotation.eulerAngles.y;
            v.z = 0;
            for (float i = 0; i < 720; i++)
            {
                v.y += 0.5f;
                yield return new WaitForSeconds(V);
                Camera.main.transform.rotation = Quaternion.Euler(v);
            }
        }
    }

    IEnumerator teleporter(Transform destination)
    {
		Camera.main.fieldOfView = 85;
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds((float)V);
            Camera.main.fieldOfView -= 1;
        }        
        //transform.position = destination.position;
        // destination.gameObject.SetActive(true);
       
       //Camera.main.fieldOfView = 52;
       /*for (int i = 0; i < 8; i++)
       {
            yield return new WaitForSeconds((float)V);
            Camera.main.fieldOfView += 1;
           
        }*/
        prev = destination;
    }

    void Update() {
         if(Input.GetMouseButton(0) && manualRotate) { 
            StopCoroutine("rotate");
            autoRotate = false;
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            float X = transform.rotation.eulerAngles.x;
            float Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
         }
         else if(!Input.GetMouseButton(0) && !autoRotate){
            autoRotate = true;
            StartCoroutine("rotate");
         }

     }

    public void rotateCamera(string xy)
    {
        string[] ar = xy.Split(',');
        int x = Int32.Parse(ar[0]);
        int y = Int32.Parse(ar[1]);
        Vector3 v;
        v.x = x;
        v.y = y;
        v.z = 0;
        
        Camera.main.transform.rotation = Quaternion.Euler(v);
    }


    public void GoTo(Transform destination)
    {
        if(prev == destination)return;
        next = destination;
        StartCoroutine("teleporter", destination);
        destination.gameObject.SetActive(true);
        prev.gameObject.SetActive(false);
        transform.position = (destination.position);
        
    }
    public void stopManualRotate()
    {
        manualRotate = false;
    }
    public void startManualRotate(){
        manualRotate = true;
    }
}
