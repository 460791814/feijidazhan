using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    public Vector2 speed = new Vector2(20,20);
    private Vector3 move;
    private Transform MyTranform;

    private Vector3 destinationPoint;

    void Start()
    {
        MyTranform = transform;
    }
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        move =new  Vector3(inputX*speed.x,inputY*speed.y,0);

        bool shoot = Input.GetButton("Fire1");
        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>() as WeaponScript;
 
            weapon.Attack(false);
            SoundEffect.instance.PlayAttackSound();
        }
        destinationPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);//获取鼠标的位置
	}
    void LateUpdate()
    {
        Vector3 temp = MyTranform.position;
        temp = Vector3.Lerp(temp, destinationPoint, 0.1f);
        temp.z = MyTranform.position.z;
        MyTranform.position = temp;
        ClampPlayer();
    }
    void FixedUpdate()
    {
        rigidbody2D.velocity = move;
    }
    /// <summary>
    /// 碰撞
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D col)
    {

        EnemyScript enemy = col.gameObject.GetComponent<EnemyScript>();
        if (enemy!=null)
        {
            HeathScript health = enemy.GetComponent<HeathScript>();
            //敌人受到一点伤害
            health.Danage(1);
            HeathScript play = gameObject.GetComponent<HeathScript>();
            //玩家也同样受到一点伤害
            play.Danage(1);
        }
    }

    void ClampPlayer()
    {
        float dist = transform.position.z - Camera.main.transform.position.z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1, dist)).y;
        transform.position = new Vector3(Mathf.Clamp(MyTranform.position.x,leftBorder,rightBorder)
            , Mathf.Clamp(MyTranform.position.y, topBorder, bottomBorder)
            ,MyTranform.position.z
            );
    }

  
    // 当游戏销毁时触发
    void OnDestroy()
    {

        GameObject.Find("Render").AddComponent<OverScript>();
        GetComponent<HeathScript>().slider.value = 0;
    }

}
