using UnityEngine;
using System.Collections;

public class ManaTest : MonoBehaviour {
    public ManaScript manaScript;


    void Update() {

        //mana used test
        if (Input.GetButtonDown("Fire1")) {
            manaScript.UseMana(5);
        }

        //mana gain test
        if (Input.GetButtonDown("Fire2")) {
            manaScript.GainMana(5);
        }

    }
}
