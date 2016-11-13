using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class ScrollingScript : MonoBehaviour {

    public Vector2 speed = new Vector2(1,1);
    public Vector2 direction = new Vector2(-1, 0);
    public bool isLinkCamera;
    public bool IsLoop=true;
    public List<Transform> list;
	// Use this for initialization
	void Start () {
        list = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
          if (transform.GetChild(i).gameObject.tag=="back")
          //  if(transform.GetChild(i).renderer!=null)
            {
                list.Add(transform.GetChild(i));
            }
        }
        //按X轴进行排序
        list = list.OrderBy(t => t.position.x).ToList();
      //  print(transform.childCount);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vector = new Vector3(speed.x*direction.x,speed.y*direction.y,0);

        var vect=vector * Time.deltaTime;
        transform.Translate(vect);
        if (isLinkCamera)
        {
            Camera.main.transform.Translate(vect);
        }

        //背景滚动、
        if (IsLoop)
        {
            Transform firstBack = list.FirstOrDefault();
            if (firstBack != null)
            {
                if (firstBack.position.x < Camera.main.transform.position.x)
                {

                    if (firstBack.renderer.IsVisibleFrom(Camera.main) == false)
                    {
                        Transform lastBack = list[1];
                        float f = (firstBack.renderer.bounds.max - firstBack.renderer.bounds.min).x;
                        float e = (lastBack.renderer.bounds.max - lastBack.renderer.bounds.min).x;

                        firstBack.transform.position = new Vector3(lastBack.position.x + f / 2 + e / 2, firstBack.position.y, firstBack.position.z);
                        list.Remove(firstBack);
                        list.Add(firstBack);
                    }
                }
            }
        }
	}


}
