using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    // Start is called before the first frame update
    protected Rigidbody2D rb;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public virtual void Attack()
    {
        
    }
    public virtual void Action()
    {

    }
    public virtual void Idle()
    {
        //In case of animation
    }
}
