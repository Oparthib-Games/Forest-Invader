﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

    public GameObject player;

	void Update () {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
	}
}
