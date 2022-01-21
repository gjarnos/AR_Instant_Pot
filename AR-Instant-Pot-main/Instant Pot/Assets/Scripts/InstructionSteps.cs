using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionSteps : MonoBehaviour
{
    [SerializeField]
    GameObject progressBar, fill, instantPotModel, nextButton, backButton, ring;
    [SerializeField]
    GameObject[] stepsAnimation, stepsText;
    [SerializeField]
    Material invisibleMaterial;
    [SerializeField]
    int counter;
    Slider slider;

    // Start at step 0.
    void Start()
    {
        stepsAnimation[counter].SetActive(true);
        stepsText[counter].SetActive(true);
    }

    public void Next()
    {
        // Check to see if we're at the end of the array.
        if (counter != stepsAnimation.Length - 1)
        {
            stepsAnimation[counter].SetActive(false);
            stepsAnimation[counter + 1].SetActive(true);

            stepsText[counter].SetActive(false);
            stepsText[counter + 1].SetActive(true);

            counter++;
            
            slider = progressBar.GetComponent<Slider>();
            slider.value = counter;
        }

        // Make the pot disappear after the first step.
        if (counter != 0)
        {
            backButton.SetActive(true);

            // This code below can be used if you want the 3D model to appear on screen at any point
            // and then disappear later on. You'll need to set a material that is opaque on the model first.
            // We don't need it now because we want it invisible the whole time.
            // Go through all the Renderer components from the all the children of the instant pot 
            // and set all the materials to invisible.

            /*Renderer[] children;
            children = instantPotModel.GetComponentsInChildren<Renderer>();

            foreach (Renderer rend in children)
            {
                var mats = new Material[rend.materials.Length];
                for (var j = 0; j < rend.materials.Length; j++)
                {
                    mats[j] = invisibleMaterial;
                }
                rend.materials = mats;
            }*/
        }

        // End of the steps so disable the next button.
        if (counter == stepsAnimation.Length - 1)
        {
            nextButton.SetActive(false);
        }

        // We moved from step 0 to step 1 so display the progress bar.
        if (counter == 1)
        {
            fill.SetActive(true);

            // Fade out the ring after moving to step 1 from 0.
            ParticleSystem myParticleSystem = ring.GetComponent<ParticleSystem>();
            ParticleSystem.ColorOverLifetimeModule colorModule = myParticleSystem.colorOverLifetime;

            Gradient ourGradient = new Gradient();

            StartCoroutine(FadeOut(ourGradient, colorModule));
        }
    }

    public void Previous()
    {
        // End of the steps so re-enable the next button.
        if (counter == stepsAnimation.Length - 1)
        {
            nextButton.SetActive(true);
        }

        // Deactivate latest step accessed and re-enable the one before.
        if (counter != 0)
        {
            stepsAnimation[counter].SetActive(false);
            stepsAnimation[counter - 1].SetActive(true);

            stepsText[counter].SetActive(false);
            stepsText[counter - 1].SetActive(true);

            counter--;

            slider = progressBar.GetComponent<Slider>();
            slider.value = counter;
        }

        // Back at the first step.
        if (counter == 0)
        {
            instantPotModel.SetActive(true);
            backButton.SetActive(false);

            // Have the ring reappear by setting the gradient alpha to 1f.
            ParticleSystem myParticleSystem = ring.GetComponent<ParticleSystem>();
            ParticleSystem.ColorOverLifetimeModule colorModule = myParticleSystem.colorOverLifetime;

            Gradient ourGradient = new Gradient();
            ourGradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.red, .125f), new GradientColorKey(Color.red, .832f), new GradientColorKey(Color.white, .855f), new GradientColorKey(Color.red, .938f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(1f, 0.0f) }
            );

            colorModule.color = ourGradient;
        }
    }

    private IEnumerator FadeOut(Gradient ourGradient, ParticleSystem.ColorOverLifetimeModule colorModule)
    {
        float alpha = 1f;
        float timeToWait = .05f;
        
        // Decrease the alpha value by .05 each loop starting at 1 until it gets to -.05.
        // Wait .05 between each loop.
        while (alpha > (-1 * timeToWait))
        {
            alpha -= timeToWait;
            yield return new WaitForSeconds(timeToWait);

            ourGradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.red, .125f), new GradientColorKey(Color.red, .832f), new GradientColorKey(Color.white, .855f), new GradientColorKey(Color.red, .938f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 0.0f) }
            );

            colorModule.color = ourGradient;
        }

        StopCoroutine("FadeOut");
    }
}
