using UnityEngine;
public class MenueAnimator : MonoBehaviour
{
	public Transform[] rotationTargets;
	public Vector3 rotationVelocity;
    void Update()
    {
		Vector3 rot = rotationVelocity * Time.deltaTime;
		foreach(Transform obj in rotationTargets)
		{
			obj.Rotate(rot);
		}
    }
}
