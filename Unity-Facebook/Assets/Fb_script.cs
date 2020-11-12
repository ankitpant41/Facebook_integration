using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using System.ComponentModel;
using UnityEngine.UI;

public class Fb_script : MonoBehaviour
{
    public GameObject DialoggedIn;
    public GameObject DialoggedOut;
    public GameObject Dialogusername;
    public GameObject Dialprofilepic;


    void Awake()
    {
        FB.Init(SetInit, OnHideUnity);
    }

    void SetInit() {
        if (FB.IsLoggedIn) {
            Debug.Log("FB is looged in");
        }

        else
        {
            Debug.Log("FB is not looged in");

        }
        DealwithFBMenu(FB.IsLoggedIn);
    }

    void OnHideUnity(bool isGameShown) {

        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }

    public void FBlogin() {
        List<string> permissions= new List<string> () ;
        permissions.Add("public_profile"); 
        FB.LogInWithPublishPermissions(permissions, AuthCallBack); 
    }

  void AuthCallBack(IResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else {
            if (FB.IsLoggedIn)
            {

                Debug.Log("Fb is logged in");

            }
            else {
                Debug.Log("Fb is not logged in");
            }

            DealwithFBMenu(FB.IsLoggedIn);
        }
    }

    void DealwithFBMenu(bool isLoggedIn) {
        if (isLoggedIn)
        {
            DialoggedIn.SetActive(true);
            DialoggedOut.SetActive(false);
            FB.API("/me?fields=first_name",HttpMethod.GET, DisplayUsername);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilepic);
        }
        else {
            DialoggedIn.SetActive(false);
            DialoggedOut.SetActive(true);
        }
    
    }

    void DisplayUsername(IResult result) {
        Text UserName = Dialogusername.GetComponent<Text> ();
        if (result.Error == null) {
            UserName.text = "Hi there, " + result.ResultDictionary ["first_name"]; 
        }
        else
        {
            Debug.Log(result.Error);
        }

    }
    void DisplayProfilepic(IGraphResult result) {
        if (result.Texture != null) {
            Image Profilepic = Dialprofilepic.GetComponent<Image>();
            Profilepic.sprite = Sprite.Create (result.Texture,new Rect(0,0,128,128), new Vector2());


        }

    }
}
