using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogStart : MonoBehaviour
{
    public GameObject player;
    public GameObject serah;
    public GameObject serahCanvas;
    public GameObject dialogCanvas;
    public Transform playerPositionAtDialog;
    public GameObject dialogCamera;
    // Start is called before the first frame update
    public void DialogOnStart()
    {
        
        
        player.GetComponent<PlayerInput>().enabled = false;
        player.transform.position = playerPositionAtDialog.transform.position;
        player.transform.LookAt(serah.transform.position);

        Animator serahAnim = serah.GetComponent<Animator>();
        serah.transform.LookAt(player.transform.position);
        serahAnim.SetBool("Dialog", true);
        serahCanvas.SetActive(false);

        dialogCamera.GetComponent<CinemachineVirtualCamera>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        dialogCanvas.SetActive(true);
        

    }
    public void DialogOnFinish()
    {


        player.GetComponent<PlayerInput>().enabled = true;
        
        

        Animator serahAnim = serah.GetComponent<Animator>();
        
        serahAnim.SetBool("Dialog", false);
        serahCanvas.SetActive(true);

        dialogCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        dialogCanvas.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
