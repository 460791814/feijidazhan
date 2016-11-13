using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    private WeaponScript[] weapons;
    private MoveScript moveScript;
    private bool isCreate;
    void Awake()
    {
        weapons = GetComponentsInChildren<WeaponScript>();
        moveScript = GetComponentInChildren<MoveScript>();
    }
    void Start()
    {
        IsRender(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (isCreate)
        {

            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i] != null && weapons[i].CanAttack)
                {
                    weapons[i].Attack(true);
                    SoundEffect.instance.EnemyAttackSound();
                }
            }
            if (renderer.IsVisibleFrom(Camera.main)==false)
            {
                if (transform != null)
                {
                    Destroy(transform.gameObject);
                }
            }

        }
        else
        {
            if (renderer.IsVisibleFrom(Camera.main))
            {
                IsRender(true);

            }

        }





    }

    void IsRender(bool isRender)
    {
        isCreate = isRender;
        moveScript.enabled = isRender;
        collider2D.enabled = isRender;
        foreach (var item in weapons)
        {
            item.enabled = isRender;
        }
    }
}
