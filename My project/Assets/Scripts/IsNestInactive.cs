using UnityEngine;
 
using Pada1.BBCore;
using Pada1.BBCore.Framework; 

[Condition("MyConditions/Is Nest Inactive?")]
[Help("Checks whether the Nest is Inactive.")]
public class IsNestInactive : ConditionBase
{
    [InParam("game object")]
    [Help("Game object to add the component, if no assigned the component is added to the game object of this behavior")]
    public GameObject robber;

    public override bool Check()
    {
        //Debug.Log(robber);
        //Debug.Log(robber.GetComponent<estatNest>().visible);
        if (!robber.GetComponent<estatNest>().visible)
            Debug.Log("Ara!!!");
        return !robber.GetComponent<estatNest>().visible;
    }
} 
