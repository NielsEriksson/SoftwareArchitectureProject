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

    [SerializeField] GameObject elementManager;
    [SerializeField] public List<Element> containsElements;

    Animator animator;

    [HideInInspector] public enum Element { Light, Water, Poison };

    public void Awake()
    {
        SetRange(startRange);
    }
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        elementManager.GetComponent<ElementControl>().UpdateElements();

        animator = GetComponent<Animator>();
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
    public virtual void Attack()
    {
        animator.SetInteger("AnimChange", 1);
    }
    public virtual void StopAttack() { }
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
    }
    public abstract void Action();
    public virtual void Idle()
    {
        animator.SetInteger("AnimChange", 0);
    }
    public virtual void Die()
    {
        animator.SetTrigger("Die");

        Destroy(gameObject, 1.0f);

        containsElements.Clear();
        elementManager.GetComponent<ElementControl>().UpdateElements();
    }
}
