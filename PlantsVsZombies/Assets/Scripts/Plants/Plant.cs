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

    [SerializeField] GameObject mainCamera;
    [SerializeField] public List<Element> containsElements;

    [HideInInspector] public enum Element { Light, Water, Poison };

    public void Awake()
    {
        SetRange(startRange);
    }
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera.GetComponent<ElementControl>().UpdateElements();
    }

    private void Update()
    {
        
    }

    protected virtual void SetRange(int width)
    {
        rangeHitBox.size = new Vector2(width, rangeHitBox.size.y);
        rangeHitBox.offset = new Vector2(width / 2, rangeHitBox.offset.y);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isInRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isInRange = false;
        }
    }
    public abstract void Attack(); 
    public virtual void StopAttack() { }
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
    }
    public abstract void Action();
    public abstract void Idle(); //Animation etc, do nothing
    public virtual void Die()
    {
        //Animation

        Destroy(gameObject);

        containsElements.Clear();
        mainCamera.GetComponent<ElementControl>().UpdateElements();
    }
}
