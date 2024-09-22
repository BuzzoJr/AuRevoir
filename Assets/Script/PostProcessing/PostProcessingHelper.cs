using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using URPGlitch.Runtime.AnalogGlitch;
using URPGlitch.Runtime.DigitalGlitch;

namespace Assets.Script.PostProcessing
{
    public class PostProcessingHelper
    {
        // FLOAT
        public IEnumerator Lerp<T>(T effect, float duration, string propertyName, float targetValue) where T : VolumeComponent
        {
            if (effect == null) yield break;

            float startValue = GetFloat(effect, propertyName);

            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;

                // Lerp
                float newValue = Mathf.Lerp(startValue, targetValue, t);
                Set(effect, propertyName, newValue);

                yield return null;
            }

            Set(effect, propertyName, targetValue);
        }

        public float GetFloat<T>(T effect, string propertyName) where T : VolumeComponent
        {
            switch (propertyName)
            {
                case "threshold":
                    if (effect is Bloom bloomThreshold)
                        return bloomThreshold.threshold.value;
                    break;

                case "intensity":
                    if (effect is Bloom bloomIntensity)
                        return bloomIntensity.intensity.value;
                    if (effect is Vignette vignetteIntensity)
                        return vignetteIntensity.intensity.value;
                    if (effect is ChromaticAberration chromaticAberrationIntensity)
                        return chromaticAberrationIntensity.intensity.value;
                    if (effect is FilmGrain filmGrainIntensity)
                        return filmGrainIntensity.intensity.value;
                    if (effect is DigitalGlitchVolume digitalGlitchIntensity)
                        return digitalGlitchIntensity.intensity.value;
                    break;

                case "scatter":
                    if (effect is Bloom bloomScatter)
                        return bloomScatter.scatter.value;
                    break;

                case "clamp":
                    if (effect is Bloom bloomClamp)
                        return bloomClamp.clamp.value;
                    break;

                case "dirtIntensity":
                    if (effect is Bloom bloomDirtIntensity)
                        return bloomDirtIntensity.dirtIntensity.value;
                    break;

                case "smoothness":
                    if (effect is Vignette vignetteSmoothness)
                        return vignetteSmoothness.smoothness.value;
                    break;

                case "balance":
                    if (effect is SplitToning splitToningBalance)
                        return splitToningBalance.balance.value;
                    break;

                case "response":
                    if (effect is FilmGrain filmGrainResponse)
                        return filmGrainResponse.response.value;
                    break;

                case "scanLineJitter":
                    if (effect is AnalogGlitchVolume analogGlitchIntensity)
                        return analogGlitchIntensity.scanLineJitter.value;
                    break;

                case "verticalJump":
                    if (effect is AnalogGlitchVolume analogGlitchVerticalJump)
                        return analogGlitchVerticalJump.verticalJump.value;
                    break;

                case "horizontalShake":
                    if (effect is AnalogGlitchVolume analogGlitchHorizontalShake)
                        return analogGlitchHorizontalShake.horizontalShake.value;
                    break;

                case "colorDrift":
                    if (effect is AnalogGlitchVolume analogGlitchColorDrift)
                        return analogGlitchColorDrift.colorDrift.value;
                    break;
            }

            return 0f;
        }

        public void Set<T>(T effect, string propertyName, float value) where T : VolumeComponent
        {
            switch (propertyName)
            {
                case "threshold":
                    if (effect is Bloom bloomThreshold)
                        bloomThreshold.threshold.value = value;
                    break;

                case "intensity":
                    if (effect is Bloom bloom)
                        bloom.intensity.value = value;
                    if (effect is Vignette vignette)
                        vignette.intensity.value = value;
                    if (effect is ChromaticAberration chromaticAberrationIntensity)
                        chromaticAberrationIntensity.intensity.value = value;
                    if (effect is FilmGrain filmGrainIntensity)
                        filmGrainIntensity.intensity.value = value;
                    if (effect is DigitalGlitchVolume digitalGlitchIntensity)
                        digitalGlitchIntensity.intensity.value = value;
                    break;

                case "scatter":
                    if (effect is Bloom bloomScatter)
                        bloomScatter.scatter.value = value;
                    break;

                case "clamp":
                    if (effect is Bloom bloomClamp)
                        bloomClamp.clamp.value = value;
                    break;

                case "dirtIntensity":
                    if (effect is Bloom bloomDirtIntensity)
                        bloomDirtIntensity.dirtIntensity.value = value;
                    break;

                case "smoothness":
                    if (effect is Vignette vignetteSmoothness)
                        vignetteSmoothness.smoothness.value = value;
                    break;

                case "balance":
                    if (effect is SplitToning splitToningBalance)
                        splitToningBalance.balance.value = value;
                    break;

                case "response":
                    if (effect is FilmGrain filmGrainResponse)
                        filmGrainResponse.response.value = value;
                    break;

                case "scanLineJitter":
                    if (effect is AnalogGlitchVolume analogGlitchIntensity)
                        analogGlitchIntensity.scanLineJitter.value = value;
                    break;

                case "verticalJump":
                    if (effect is AnalogGlitchVolume analogGlitchVerticalJump)
                        analogGlitchVerticalJump.verticalJump.value = value;
                    break;

                case "horizontalShake":
                    if (effect is AnalogGlitchVolume analogGlitchHorizontalShake)
                        analogGlitchHorizontalShake.horizontalShake.value = value;
                    break;

                case "colorDrift":
                    if (effect is AnalogGlitchVolume analogGlitchColorDrift)
                        analogGlitchColorDrift.colorDrift.value = value;
                    break;
            }
        }

        // INT
        public IEnumerator Lerp<T>(T effect, float duration, string propertyName, int targetValue) where T : VolumeComponent
        {
            if (effect == null) yield break;

            int startValue = GetInt(effect, propertyName);

            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;

                // Lerp
                int newValue = Mathf.RoundToInt(Mathf.Lerp(startValue, targetValue, t));
                Set(effect, propertyName, newValue);

                yield return null;
            }

            Set(effect, propertyName, targetValue);
        }

        public int GetInt<T>(T effect, string propertyName) where T : VolumeComponent
        {
            switch (propertyName)
            {
                case "skipIterations":
                    if (effect is Bloom bloodSkipIterations)
                        return bloodSkipIterations.skipIterations.value;
                    break;
            }

            return 0;
        }

        public void Set<T>(T effect, string propertyName, int value) where T : VolumeComponent
        {
            switch (propertyName)
            {
                case "skipIterations":
                    if (effect is Bloom bloodSkipIterations)
                        bloodSkipIterations.skipIterations.value = value;
                    break;
            }
        }

        // COLOR
        public IEnumerator Lerp<T>(T effect, float duration, string propertyName, Color targetValue) where T : VolumeComponent
        {
            if (effect == null) yield break;

            Color startValue = GetColor(effect, propertyName);

            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;

                // Lerp
                Color newValue = Color.Lerp(startValue, targetValue, t);
                Set(effect, propertyName, newValue);

                yield return null;
            }

            Set(effect, propertyName, targetValue);
        }

        public Color GetColor<T>(T effect, string propertyName) where T : VolumeComponent
        {
            switch (propertyName)
            {
                case "tint":
                    if (effect is Bloom bloodTint)
                        return bloodTint.tint.value;
                    break;

                case "color":
                    if (effect is Vignette vignetteColor)
                        return vignetteColor.color.value;
                    break;

                case "shadows":
                    if (effect is SplitToning splitToningShadows)
                        return splitToningShadows.shadows.value;
                    break;

                case "highlights":
                    if (effect is SplitToning splitToningHighlights)
                        return splitToningHighlights.highlights.value;
                    break;
            }

            return new Color();
        }

        public void Set<T>(T effect, string propertyName, Color value) where T : VolumeComponent
        {
            switch (propertyName)
            {
                case "tint":
                    if (effect is Bloom bloodTint)
                        bloodTint.tint.value = value;
                    break;

                case "color":
                    if (effect is Vignette vignetteColor)
                        vignetteColor.color.value = value;
                    break;

                case "shadows":
                    if (effect is SplitToning splitToningShadows)
                        splitToningShadows.shadows.value = value;
                    break;

                case "highlights":
                    if (effect is SplitToning splitToningHighlights)
                        splitToningHighlights.highlights.value = value;
                    break;
            }
        }

        // VECTOR2
        public IEnumerator Lerp<T>(T effect, float duration, string propertyName, Vector2 targetValue) where T : VolumeComponent
        {
            if (effect == null) yield break;

            Vector2 startValue = GetVector2(effect, propertyName);

            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;

                // Lerp
                Vector2 newValue = Vector2.Lerp(startValue, targetValue, t);
                Set(effect, propertyName, newValue);

                yield return null;
            }

            Set(effect, propertyName, targetValue);
        }

        public Vector2 GetVector2<T>(T effect, string propertyName) where T : VolumeComponent
        {
            switch (propertyName)
            {
                case "center":
                    if (effect is Vignette vignetteCenter)
                        return vignetteCenter.center.value;
                    break;
            }

            return new Vector2();
        }

        public void Set<T>(T effect, string propertyName, Vector2 value) where T : VolumeComponent
        {
            switch (propertyName)
            {
                case "center":
                    if (effect is Vignette vignetteCenter)
                        vignetteCenter.center.value = value;
                    break;
            }
        }
    }
}