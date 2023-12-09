using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HueBeat : MonoBehaviour
{
    public PostProcessProfile profile;

    public float beatTime;
    public float onBrightness;
    public float offBrightness;

    private bool onState;
    private float lastBeat = 0;

    private void Update()
    {
        lastBeat += Time.deltaTime;
        if (lastBeat >= beatTime)
        {
            lastBeat -= beatTime;
            profile.GetSetting<ColorGrading>().hueShift.value = Random.Range(-180, 190);
            float newBrightnes = onBrightness;
            if (onState == true)
            {
                newBrightnes = offBrightness;
            }
            onState = !onState;
            profile.GetSetting<ColorGrading>().brightness.value = newBrightnes;
        }
    }
}
