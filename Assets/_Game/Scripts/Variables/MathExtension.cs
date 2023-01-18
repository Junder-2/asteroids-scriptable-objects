using UnityEngine;

public static class MathExtension
{
    public static void ClampCurve(ref AnimationCurve curve, Rect bounds)
    {
        if (curve.length == 0) return;
        var start = curve.keys[0];
        var end = curve.keys[curve.length - 1];

        curve.keys[0].time = Mathf.Max(start.time, bounds.xMin);
        curve.keys[0].value = Mathf.Max(start.value, bounds.yMin);

        curve.keys[curve.length - 1].time = Mathf.Min(end.time, bounds.xMax);
        curve.keys[curve.length - 1].value = Mathf.Min(end.value, bounds.yMax);
    }

    public static void ClampZero(ref this float value) => value = Mathf.Max(value, 0);

    public static void ClampZero(ref this int value) => value = Mathf.Max(value, 0);
}
