using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class AnimationsWin : MonoBehaviour
{

    public GameObject Obj;
    public string NameAnimation;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Obj.GetComponent<Animator>().Play(NameAnimation);
        }
    }
}




