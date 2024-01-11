using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Has Robber robbed?")]
[Help("Checks whether the Robber has robbed the nest.")]
public class HasRobberRobbed : ConditionBase
{
    [InParam("game object")]
    [Help("Game object to add the component, if no assigned the component is added to the game object of this behavior")]
    public GameObject cop;

    public override bool Check()
    {
        return cop.GetComponent<estatRobber>().nestRobbed;
    }
}
