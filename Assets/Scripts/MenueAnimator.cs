using UnityEngine;
public class MenueAnimator : MonoBehaviour
{
    public Transform[] rotationTargets;
    public Vector3 rotationVelocity;
    void Update()
    {
        Vector3 rot = rotationVelocity * Time.deltaTime;
        for (int i = 0; i < rotationTargets.Length; i++)
        {
            rotationTargets[i].Rotate(rot);
        }
    }
}
