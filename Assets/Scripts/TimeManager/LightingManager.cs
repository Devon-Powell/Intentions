using UnityEngine;

//[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPresets preset;
    public TimeManager timeManager;

    [SerializeField, Range(0, 24)] private float timeOfDay;

    [SerializeField] AnimationCurve intensity;

    private void Update()
    {
        if (preset == null)
            return;
        float dayTime = timeManager.counter;
        UpdateLighting(dayTime / 86400f);
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);

        if (directionalLight != null)
        {
            directionalLight.color = preset.directionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 45f, 45, 0));
        }
    }

    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light lightSource in lights)
            {
                if (lightSource.type == LightType.Directional)
                {
                    directionalLight = lightSource;
                    return;
                }
            }
        }
    }
}
