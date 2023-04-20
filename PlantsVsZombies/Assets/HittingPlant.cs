using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingPlant : Plant
{
    public override void Attack()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    public override void Action()
    {
        throw new System.NotImplementedException();
    }
    public override void Idle()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
