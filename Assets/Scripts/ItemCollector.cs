using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{   


    [SerializeField] private Text scoreText;
    private int pineapples = 0;
    private int zehners = 0;


    private void  OnTriggerEnter2D(Collider2D collision) {

               
        if(collision.gameObject.CompareTag("Pineapple")){

            Destroy(collision.gameObject);
            pineapples = pineapples + 1;
            
        }

        else if(collision.gameObject.CompareTag("10ner"))
        {
            Destroy(collision.gameObject);
            zehners = zehners + 10;
        }

        int resultScore = zehners + pineapples;
        scoreText.text = "Score: " + resultScore; 
    }

}
