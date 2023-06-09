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
    [SerializeField] Card card;

    protected Animator animator;

    [HideInInspector] public enum Element { Light, Water, Poison };

    public bool isUpgraded = false;

    [SerializeField] public float heightOffSet;

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

        isUpgraded = CheckElementCondition();

        Debug.Log(isUpgraded);
    }

    private void Update()
    {

    }

    protected virtual void SetRange(int width)
    {
        rangeHitBox.size = new Vector2(width, rangeHitBox.size.y);
        rangeHitBox.offset = new Vector2(width / 2, rangeHitBox.offset.y);
    }

    bool CheckElementCondition()
    {
        int tempWater = elementManager.GetComponent<ElementControl>().WaterNumber;
        int tempSun = elementManager.GetComponent<ElementControl>().SunNumber;
        int tempPoison = elementManager.GetComponent<ElementControl>().PoisonNumber;

        int waterCondition = 0;
        int sunCondition = 0;
        int poisonCondition = 0;

        foreach (var element in card.conditions)
        {
            switch (element)
            {
                case Element.Light:
                    sunCondition++;
                    break;
                case Element.Water:
                    waterCondition++;
                    break;
                case Element.Poison:
                    poisonCondition++;
                    break;
            }
        }

        Debug.Log("Water: " + waterCondition + " < " + tempWater + " Sun: " + sunCondition + " < " + tempSun + " Poison: " + poisonCondition + " < " + tempPoison);
        return (waterCondition <= tempWater && sunCondition <= tempSun && poisonCondition <= tempPoison);
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
