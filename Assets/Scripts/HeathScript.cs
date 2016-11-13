using UnityEngine;
using System.Collections;

public class HeathScript : MonoBehaviour {

    public UISlider slider;
    public int HP = 1;
    public bool IsEnemy = true;
    public int maxHp;
    public float to;
	// Use this for initialization
    void Start()
    {
        maxHp = HP;
        UpdateHealthSlider();
    }

    /// <summary>
    /// 伤害
    /// </summary>
    /// <param name="danage"></param>
    public  void Danage(int danage)
    {
       
        HP -= danage;
        UpdateHealthSlider();
        if (HP <= 0)
        {
            SpecialEffect.instance.PlayParticle(transform.position);
            if (gameObject != null)
            {
                Destroy(gameObject);
               SoundEffect.instance.DestrySound();
            }
           
        }
     
     }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        ShotScript shot = other.gameObject.transform.GetComponent<ShotScript>();

        if (shot != null)
        { 
            //是子弹且是敌人
            if (shot.IsEnemy != IsEnemy)
            {
                Danage(shot.Danage);
                Destroy(shot.gameObject);
                SoundEffect.instance.DestrySound();
               
            }
        }
    }
    void LateUpdate()
    {
        if (slider != null&& slider.value!=to)
        {
            slider.value = Mathf.Lerp(slider.value, to, 0.2f);
            //当slider.value的值无限接近to时 节省性能损耗
            if (Mathf.Abs(slider.value - to) < 0.01f)
            {
                slider.value = to;
            }
        }
    }
    void UpdateHealthSlider()
    {
        if (slider != null)
        {
           // slider.value = (float)HP / (float)maxHp;
            to = (float)HP / (float)maxHp;
        }
    }
  public   void UpdateUILable()
    {
      
        slider.GetComponentInChildren<UILabel>().text = HP + "/" + maxHp;
    }
}
