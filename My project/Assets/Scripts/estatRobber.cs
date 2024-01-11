using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estatRobber : MonoBehaviour
{
    public bool nestRobbed = false;

    public void robbed()
    {
        nestRobbed = true;
    }

    public void confiscated()
    {
        nestRobbed = false;
    }

}
