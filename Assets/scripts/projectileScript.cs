﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {

	
	void Update () {
        transform.Translate(Vector3.right * 0.5f);	
	}
}
