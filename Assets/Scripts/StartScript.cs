using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {
    public int buttunWith = 80;
    public int buttunHeight = 50;


    void OnGUI()
    {
        if(GUI.Button(new Rect(Screen.width / 2 - buttunWith / 2, Screen.height / 3*2  - buttunHeight / 2, buttunWith, buttunHeight), "Start"))
        {
           Application.LoadLevel("FirstPass");
        }

    }
}
