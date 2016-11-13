using UnityEngine;
using System.Collections;

public class SpecialEffect : MonoBehaviour {

    public static SpecialEffect instance;
    public ParticleSystem smoke;
    public ParticleSystem fire;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("special error");
        }
        instance = this;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void PlayParticle(Vector3 postion)
    {
        init(smoke, postion);
        init(fire, postion);

    }
    private ParticleSystem init(ParticleSystem particle, Vector3 pos)
    {
        ParticleSystem newPar = Instantiate(particle, pos,Quaternion.identity) as ParticleSystem;
        Destroy(newPar, particle.startLifetime);
        return newPar;
    }
}
