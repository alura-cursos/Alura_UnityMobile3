using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaoDestruir : MonoBehaviour {
	private void Start () {
        GameObject.DontDestroyOnLoad(this.gameObject);	
	}
}
