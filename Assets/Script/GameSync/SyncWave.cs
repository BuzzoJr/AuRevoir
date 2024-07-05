using UnityEngine;

public class SyncWave : MonoBehaviour
{
    public LineRenderer myLineRenderer;
    public Vector2 xLimits = new Vector2(0, 1);
    public float frequency;
    public float amplitude;
    public float position;
    public int points;

    void Update()
    {
        DrawLine();
    }

    void DrawLine()
    {
        float startX = xLimits.x;
        float Tau = 2 * Mathf.PI;
        float finishX = xLimits.y;

        myLineRenderer.positionCount = points;

        for (int i = 0; i < points; i++)
        {
            float progress = (float)i / (points - 1);
            float x = Mathf.Lerp(startX, finishX, progress);
            float y = amplitude * Mathf.Sin(((x + position) * Tau * frequency) + (Time.timeSinceLevelLoad * 3.5f));
            myLineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
