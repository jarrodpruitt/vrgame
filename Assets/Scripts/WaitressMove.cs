using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitressMove : MonoBehaviour
{
    private bool walk = false;
    private float speed = 0.02f;

    public GameObject openMenu;

    public AudioSource firstDialogue;
    public AudioSource sDialogue;


    private Animator myAnimator;
    Vector3 pos;

    void Start()
    {   
        myAnimator = this.GetComponent<Animator>();
        walk = true;
        pos = transform.position;
    }

    void Update()
    {
        // print(Time.time);
        
        if(walk == false)
            return;
        
        mainMovement();
    }

    // main movement will always call the last movement.
    void mainMovement(){
        


        secondMovement();
    }
 
    bool rotateMovement(){
        if(firstMovement() == false)
            return false;
        if(transform.rotation.y < -0.7f){
            transform.Rotate(new Vector3(0,-3,0));
            return false;
        }
        return true;
    }

    bool firstMovement(){
        if(pos.z > 9.5f){
            pos.z -= speed;
            transform.position = pos;
            return false;
        }
        return true;
    }


    private bool hasRan = false;
    private bool hasTalked1 = false;

    bool secondMovement(){
        // checks if previous movement is complete
        if(rotateMovement() == false){
            return false;
        }
        //checks if it has reached its destination
        if(pos.x < 3f){
            pos.x += speed;
            transform.position = pos;
            return false;
        }


        //otherwise this is complete, so return true
        if(hasRan == false){
            myAnimator.SetBool("Walk", false);
            Invoke("delayedMenu", 7f);
            hasRan = true;
        }
        
        if(hasTalked1 == false){

            Invoke("talk1", 2f);
            Invoke("stopTalkingAnimationPlay", 2.1f);
            print("bruh");
            hasTalked1 = true;
        }

        // Then, the menu should appear.
        return true;
    }

    void stopTalkingAnimationPlay(){
        myAnimator.SetBool("Talking", false);
    }

    void end(){
        walk = false;
    }

    void talk1(){
        myAnimator.SetBool("Talking", true);
        firstDialogue.Play();
    }



 


    void delayedMenu(){
        openMenu.SetActive(true);
    }
}



/*
* waitress is initally at -22.5, x, 0
* waitress will move to -22.5, x, -5.0
* then rotate
* then waitress will move to -20.5, x, -5.0
* stop
*/


