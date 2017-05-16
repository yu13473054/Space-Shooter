using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByTime : MonoBehaviour {
    public float life;

    void Start () {
        Destroy(gameObject, life);
	}
}
