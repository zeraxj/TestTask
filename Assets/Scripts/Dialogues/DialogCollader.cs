using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCollader : MonoBehaviour
{
    public GameObject canvas;
    public GameObject dialogstart;

    private void OnTriggerEnter(Collider other)
    {
        
       
        if (other.tag == "Player")
        {

            canvas.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<StarterAssetsInputs>().use)
        {
            Debug.Log("E");
            dialogstart.GetComponent<DialogStart>().DialogOnStart();
            other.GetComponent<StarterAssetsInputs>().use = false;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "Player")
        {

            canvas.SetActive(false);
        }
    }
}
