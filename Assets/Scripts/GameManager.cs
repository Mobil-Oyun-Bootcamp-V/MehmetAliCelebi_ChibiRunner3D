using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int level;
    // Start is called before the first frame update
    void Awake()
    {
        level=SceneManager.GetActiveScene().buildIndex+1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void StartGame(){
        // SceneManager.LoadScene(0);
        // _isGameStarted=true;
    }
    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        // _isGameStarted=true;
    }
    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // _isGameStarted=true;
    }
}
