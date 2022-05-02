using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
     public void ReloadGame(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }    public void QuitGame(){
        //Application.Quit();
        print("you quited");
    }    void Start()
    {    }    // Update is called once per frame
    void Update()
    {    }
}