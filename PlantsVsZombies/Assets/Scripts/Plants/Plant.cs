using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    // Start is called before the first frame update
    protected Rigidbody2D rb;
    [SerializeField] public BoxCollider2D rangeHitBox;
    [SerializeField] protected int startRange;
    [HideInInspector] public bool isInRange;
    [SerializeField] public int health;
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRange(startRange);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            health--;
        }
    }

    protected virtual void SetRange(int width)
    {
        rangeHitBox.size = new Vector2(width, rangeHitBox.size.y);
        rangeHitBox.offset = new Vector2(width / 2, rangeHitBox.offset.y);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("COLLIDING!!!!");
        if (other.gameObject.tag == "Enemy")
        {
            isInRange = true;
        }
    }
    public abstract void Attack();
    public abstract void Action();
    public abstract void Idle(); //Animation etc, do nothing
    public virtual void Die()
    {
        //Animation

        Destroy(gameObject);
    }
}
