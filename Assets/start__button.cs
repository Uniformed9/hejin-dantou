using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  UnityEngine.SceneManagement;
public class start__button : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void OnClick()
    {
        SceneManager.LoadScene("tutorial");
    }
}