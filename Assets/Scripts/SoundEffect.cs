using UnityEngine;
using System.Collections;

public class SoundEffect : MonoBehaviour {

    public static SoundEffect instance;

    public AudioClip playAttackSound;
    public AudioClip bozha;
    public AudioClip enemyAttackSound;
	// Use this for initialization
	void Awake () {
        if (instance != null)
        {
            Debug.LogError("soundeffect is not null");
           
        }
        instance = this;
	}
    public void PlayAttackSound()
    {
        PlaySound(playAttackSound);
    }
    public void EnemyAttackSound()
    {
        PlaySound(enemyAttackSound);
    }
    public void DestrySound()
    {
        PlaySound(bozha);
    }
    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Vector3.zero);
    }
}
