using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textcontroll : MonoBehaviour
{
    
    public GameObject text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
    
         score = GameObject.Find("GameManager").GetComponent<GameManager>().param;
        text.GetComponent<TMP_Text>().text = ("Your Score:"+score);
       
        
        
    }

    // Update is called once per frame
    
}
