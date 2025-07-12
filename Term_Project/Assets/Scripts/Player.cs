using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float spped;
    public bool move = false;

    public GameObject button;
    public GameObject title;

    // Update is called once per frame
    void Update()
    {
       if(move)
        {
            this.transform.Translate(0, 0, spped * Time.deltaTime);
        }
    }

    public void GameStart()
    {
        move = true;
        Destroy(button);
        Destroy(title);
    }
}
