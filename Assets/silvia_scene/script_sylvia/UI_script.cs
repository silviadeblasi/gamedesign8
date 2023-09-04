using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_script : MonoBehaviour {
    public bool fine_ui = false;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Z)){
            fine_ui = true;
            gameObject.SetActive(false);
        }
    }
}