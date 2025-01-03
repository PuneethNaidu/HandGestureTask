using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ScaleDownAnimation : MonoBehaviour
{
    public GameObject[] arrayToScaleDown; // First array to scale down and disable
    public GameObject[] arrayToActivate;  // Second array to activate

    public float scaleDownDuration = 0.5f; // Duration for scaling down each GameObject

    void Start()
    {
        StartCoroutine(HandleGameObjects());
    }

    private IEnumerator HandleGameObjects()
    {
        yield return new WaitForSeconds(1f);
        // Scale down and disable objects in the first array
        foreach (GameObject obj in arrayToScaleDown)
        {
            if (obj != null)
            {
                yield return ScaleDownAndDisable(obj);
            }
        }

        // Activate objects in the second array
        foreach (GameObject obj in arrayToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    private IEnumerator ScaleDownAndDisable(GameObject obj)
    {
        // Scale the GameObject to zero over the given duration
        obj.transform.DOScale(Vector3.zero, scaleDownDuration);

        // Wait for the scaling to complete
        yield return new WaitForSeconds(scaleDownDuration);

        // Disable the GameObject after scaling down
        obj.SetActive(false);
    }
}
