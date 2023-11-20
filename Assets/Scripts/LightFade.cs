using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour
{
	public Light Mine;
	public float speed;
    void Update()
    {
        
		Mine.intensity -= Time.deltaTime * speed;
    }
}
