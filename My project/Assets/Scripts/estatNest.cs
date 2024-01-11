using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estatNest : MonoBehaviour
{
    public bool visible = true;

    public void amaga()
    {
        Debug.Log("amagat");
        visible = false;
    }

    public void mostra()
    {
        visible = true;
    }

}
