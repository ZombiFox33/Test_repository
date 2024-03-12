using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class dialogScript : MonoBehaviour
{
    public string[] Dialoguie;
    public int count;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        text.text = Dialoguie[count];
    }

    public void Next()
    { 
        count++;
    }

    public void Pred()
    {
        count--;
    }
}
