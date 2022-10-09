using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class back_to_menu : MonoBehaviour
{
    // Start is called before the first frame update
   public void OnClick()
    {
        SceneManager.LoadScene("New Scene");
    }
}
