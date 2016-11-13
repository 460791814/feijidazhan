using UnityEngine;
using System.Collections;

public class OverScript : MonoBehaviour {
    public int buttunWith = 80;
    public int buttunHeight = 40;

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - buttunWith / 2, Screen.height / 2 - buttunHeight / 2, buttunWith, buttunHeight), "重玩"))
        {
            Application.LoadLevel("FirstPass");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - buttunWith / 2, Screen.height / 3 * 2 - buttunHeight / 2, buttunWith, buttunHeight), "返回"))
        {
            Application.LoadLevel("HomePass");
        }

    }
}
