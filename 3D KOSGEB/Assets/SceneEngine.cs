using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneEngine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameScene()
    {

        SceneManager.LoadScene("GameScene");

    }

    public void MenuScene()
    {

        SceneManager.LoadScene("Menu");

    }


}
