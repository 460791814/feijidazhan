using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    public Transform ShotTransform;
    public float ShootingRate = 0.25f;
    public float ShootCoolDown;
    public bool CanAttack
    {
        get {
            return ShootCoolDown <= 0f;
        }
    }
	// Use this for initialization
	void Start () {
        ShootCoolDown = 0;
	}
	
	// Update is called once per frame
	void Update () {
        ShootCoolDown -= Time.deltaTime;
	}
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            Transform shotTransform = Instantiate(ShotTransform) as Transform;
            shotTransform.position = transform.position;
          
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.IsEnemy = isEnemy;
            }
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.direct = transform.right;
            }

            ShootCoolDown = ShootingRate;
        }
    }
}
