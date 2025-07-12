using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameDirector : MonoBehaviour
{
    public int score = 0;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = ("Score : " + score);
    }
    public void GameEnd()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
