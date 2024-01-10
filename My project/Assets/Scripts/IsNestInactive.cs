using UnityEngine;
 
using Pada1.BBCore;
using Pada1.BBCore.Framework; 

[Condition("MyConditions/Is Nest Inactive?")]
[Help("Checks whether the Nest is Inactive.")]
public class IsNestInactive : ConditionBase
{
    public override bool Check()
    {
        GameObject nest = GameObject.Find("BeeNest");
        //Debug.Log(nest.GetComponent<Renderer>().isVisible);
        Debug.Log(nest.activeInHierarchy);
        return !nest.activeInHierarchy;
    }
} 
