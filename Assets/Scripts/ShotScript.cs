using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {


    public int Danage=1;
    public bool IsEnemy = false;
	// Use this for initialization
	void Start () {
      gameObject.hideFlags= HideFlags.HideInHierarchy;
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
