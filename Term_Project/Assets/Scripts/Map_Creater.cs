using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Creater : MonoBehaviour
{
    public GameObject Map1;
    public GameObject Map2;
    public GameObject Map3;
    public GameObject Map4;
    public GameObject Map5;
    public GameObject Map6;
    public GameObject Map7;
    public GameObject Map8;
    public GameObject Map9;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            int mapNumber;
            mapNumber = Random.Range(1, 9);
            Vector3 nextMapPos = this.transform.position;
            nextMapPos.x = this.transform.position.x - 105;
                
            switch (mapNumber)
            {
                case 1:
                    Instantiate(Map1, nextMapPos, transform.rotation);
                    break;
                case 2:
                    Instantiate(Map2, nextMapPos, transform.rotation);
                    break;
                case 3:
                    Instantiate(Map3, nextMapPos, transform.rotation);
                    break;
                case 4:
                    Instantiate(Map4, nextMapPos, transform.rotation);
                    break;
                case 5:
                    Instantiate(Map5, nextMapPos, transform.rotation);
                    break;
                case 6:
                    Instantiate(Map6, nextMapPos, transform.rotation);
                    break;
                case 7:
                    Instantiate(Map7, nextMapPos, transform.rotation);
                    break;
                case 8:
                    Instantiate(Map8, nextMapPos, transform.rotation);
                    break;
                case 9:
                    Instantiate(Map9, nextMapPos, transform.rotation);
                    break;

            }

        }
    }
}
