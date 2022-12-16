using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationsstore : MonoBehaviour
{
    public GameObject shopdown;
    public GameObject shopup;

    public void OnClickPlaydown()
    {
        if (!shopdown.GetComponent<Animator>().enabled) shopdown.GetComponent<Animator>().enabled = true;
        else shopdown.GetComponent<Animator>().SetTrigger("In7");
    }
    public void OnClickPlayup()
    {
        if (!shopup.GetComponent<Animator>().enabled) shopup.GetComponent<Animator>().enabled = true;
        else shopup.GetComponent<Animator>().SetTrigger("In8");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
