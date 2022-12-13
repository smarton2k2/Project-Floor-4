using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DoorScript : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
 
    private bool opened = false;
    private bool right = false;
    private bool run = false;
    private int posit = 0;
    private bool move = false;
    private  Animator anim;
    private bool fwds;
 
 
 
    void Update()
    {
        //This will tell if the player press F on the Keyboard. P.S. You can change the key if you want.
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pressed();
            PressedWindow();
            PressedWhiteboard();
            PressedFans();

            //Delete if you dont want Text in the Console saying that You Press F.
            Debug.Log("You Press F");
        }
    }
 
    void Pressed()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit doorhit;
 
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {
            if (doorhit.transform.tag == "Door")
            {
                anim = doorhit.transform.GetComponentInParent<Animator>();
 
                //This will set the bool the opposite of what it is.
                opened = !opened;
 
                //This line will set the bool true so it will play the animation.
                anim.SetBool("Opened", !opened);
            }
        }
    }

    void PressedWindow()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit windowhit;
 
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out windowhit, MaxDistance))
        {
            if (windowhit.transform.tag == "Window")
            {
                anim = windowhit.transform.GetComponentInParent<Animator>();
 
                //This will set the bool the opposite of what it is.
                opened = !opened;
 
                //This line will set the bool true so it will play the animation.
                anim.SetBool("Opened", !opened);
            }
        }
    }
    
    void PressedWhiteboard()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit whitehit;
 
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out whitehit, MaxDistance))
        {
            if (whitehit.transform.tag == "WhiteBoard")
            {
                anim = whitehit.transform.GetComponentInParent<Animator>();
                right = !right;
 
                //This line will set the bool true so it will play the animation.
                anim.SetBool("right", right);
            }
        }
        move = false;
    }

    void PressedFans()
    {
        RaycastHit fanshit;
 
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out fanshit, MaxDistance))
        {
            if (fanshit.transform.tag == "Fans")
            {
                anim = fanshit.transform.GetComponentInParent<Animator>();
 
                //This will set the bool the opposite of what it is.
                run = !run;
 
                //This line will set the bool true so it will play the animation.
                anim.SetBool("Run", !run);
            }
        }
    }
}