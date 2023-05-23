using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] public BoxCollider2D rangeHitBox;
    [SerializeField] protected int startRange;
    [HideInInspector] public bool isInRange;
    [SerializeField] public int health;

    [SerializeField] GameObject elementManager;
    [SerializeField] public List<Element> containsElements;

    protected Animator animator;

    [HideInInspector] public enum Element { Light, Water, Poison };

    public bool isUpgraded = false;

    public void Awake()
    {
        SetRange(startRange);
    }
    public virtual void Start()
    {
        elementManager = FindObjectOfType<ElementControl>().gameObject;

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


    public virtual void Attack()
    {
        animator.SetInteger("FSMState", 1);
    }
    public virtual void StopAttack() { }
    public virtual void TakeDamage(int damage)
    {
        animator.SetTrigger("Hurt");
        health -= damage;
    }
    public abstract void Action();
    public virtual void Idle()
    {
        animator.SetInteger("FSMState", 0);
    }
    public virtual void Die()
    {
        StartCoroutine(AnimationThenDie());

        containsElements.Clear();
        elementManager.GetComponent<ElementControl>().UpdateElements();
    }
    public IEnumerator AnimationThenDie()
    {
        while (true)
        {
            if (animator == null)
            {
                Destroy(gameObject);
            }
            else
            {
                animator.SetTrigger("Die");

                yield return new WaitForSeconds(1);

                Destroy(gameObject);
            }
            break;
        }
    }
}
