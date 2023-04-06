using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCarClick : MonoBehaviour
{

    public Tray tray;
    public GameObject tray_obj;
    public AudioSource main_char_talking;
    public AudioSource main_char_talking2;

    public AudioSource mom_talking3;
    public AudioSource waitress_talking4;
    public GameObject menu;
    public GameObject mother;
    public GameObject waitress;

    Animator momAnimation;
    Animator waitressAnimation;




    public void ButtonClicked(){
        main_char_talking.Play();
        Invoke("removeMenu", 2.5f);
        Invoke("waitressTalking4", 6f);

        // move the waitress back into the restauarant
        Invoke("moveBackToRestaurant", 10f);

        // the waitress comes back


        // the tray then appears 
        // TODO: change time
        Invoke("moveTray", 6f);
        
        Invoke("Talking2", 8f);

        Invoke("momTalking", 12f);

    }

    private void moveBackToRestaurant(){
        waitressAnimation.SetBool("Walk", true);
        // waitressAnimation.SetTrigger("moveToKitchen");
    }

    private void removeMenu(){
        menu.SetActive(false);
    }

    private void moveTray(){
        tray_obj.SetActive(true);
        tray.shouldMove = true;
    }

    private void momTalking(){
        momAnimation = mother.GetComponent<Animator>();
        momAnimation.SetTrigger("talking");
        // mom_talking3.PlayDelayed(3f);
        mom_talking3.Play();
    }

    private void waitressTalking4(){
        waitressAnimation = waitress.GetComponent<Animator>();
        waitressAnimation.SetTrigger("talking1");
        // waitress_talking4.PlayDelayed(3f);
        waitress_talking4.Play();
    }




     private void momTalking2(){
        momAnimation = mother.GetComponent<Animator>();
        momAnimation.SetTrigger("talking");
        // mom_talking3.PlayDelayed(3f);
        mom_talking3.Play();
    }


    private void Talking2(){
        main_char_talking2.Play();

       
    }

            





}
