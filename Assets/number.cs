using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class number : MonoBehaviour
{   //number�Ľű�����һ��Ҫʹ�õ�ͼƬsprite

    public Sprite[] sprites;
    protected Image itself;
    public GameSettings settings;
    // Start is called before the first frame update
    protected void Start()
    {
        itself = GetComponent<Image>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changenumber(int index)
    {
        itself.sprite = sprites[index];

    }
}
