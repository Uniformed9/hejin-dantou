using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    // Start is called before the first frame update
    public GameSettings gameSettings;
    Image itself;
    
    public Sprite []a;
    void Start()
    {
        itself=GetComponent<Image>();
    }

    // Update is called once per frame
  
    public void changenumber(int index)
    {
        itself.sprite = a[index]   ;
        
    }
}
