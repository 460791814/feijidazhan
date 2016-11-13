using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{

    private Animator animator;
    private MoveScript move;
    private Vector2 movePostion;
    private WeaponScript[] weapons;

    private float minCoolDown = 0.2f;
    private float maxCoolDown = 2f;
    public  SpriteRenderer body;
    private float CoolDown = 2;

    private bool isAttack = false;
    void Awake()
    {
        animator = GetComponent<Animator>();
        move = GetComponent<MoveScript>();
        weapons = GetComponentsInChildren<WeaponScript>();
     
    }


    // Update is called once per frame
    void Update()
    {

        if (isCreate)
        {
            CoolDown -= Time.deltaTime;
            if (CoolDown < 0)
            {
                CoolDown = Random.Range(minCoolDown, maxCoolDown);
                isAttack = !isAttack;
                animator.SetBool("Attack", isAttack);
                movePostion = Vector3.zero;
            }
            if (isAttack)
            {
                Attack();
            }
            else
            {
                Move();
            }
        }
        else
        {
            if (body.renderer.IsVisibleFrom(Camera.main))
            {
                IsRender(true);
                foreach (ScrollingScript item in FindObjectsOfType<ScrollingScript>())
                {
                    
                        item.speed = Vector2.zero;
                    
                }

            }

        }
    }

    void Move()
    {
        //如果在位置0也就是起始位置
        if (movePostion == Vector2.zero)
        {
            //当前窗口坐标  左下角00 右上角11
            Vector2 randomPostion = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
            //当前坐标转换成世界坐标
            movePostion = Camera.main.ViewportToWorldPoint(randomPostion);
        }
        //如果生成的目标点跟当前点重合则重新生成
        if (collider2D.OverlapPoint(movePostion))
        {
            movePostion = Vector2.zero;
        }

        Vector3 direction = (Vector3)movePostion - transform.position;

        move.direct = Vector3.Normalize(direction);
    }

    void OnDrawGizmos()
    {

        Gizmos.DrawSphere(movePostion, 0.2f);
    }



    private bool isCreate;

    void Start()
    {
        IsRender(false);
    }
    // Update is called once per frame
    void Attack()
    {


        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] != null && weapons[i].CanAttack)
            {
                weapons[i].Attack(true);
                SoundEffect.instance.EnemyAttackSound();
            }
        }




    }

    void IsRender(bool isRender)
    {
        isCreate = isRender;
        move.enabled = isRender;
        collider2D.enabled = isRender;
        foreach (var item in weapons)
        {
            item.enabled = isRender;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        ShotScript shot = other.gameObject.transform.GetComponent<ShotScript>();

        if (shot != null)
        {
            //是玩家或者玩家子弹
            if (shot.IsEnemy == false)
            {
            
                CoolDown = Random.Range(minCoolDown, maxCoolDown);
                isAttack = false;
                animator.SetTrigger("Hit");

            }
        }
    }
    // 当游戏销毁时触发
    void OnDestroy()
    {

        GameObject.Find("Render").AddComponent<OverScript>();
     
    }
}
