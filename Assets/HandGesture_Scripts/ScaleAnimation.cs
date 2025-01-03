using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameObjects; // Array of GameObjects to scale up

    [SerializeField]
    private Vector3[] targetScales; // Array of target scales for each GameObject

    [SerializeField]
    private float duration = 0.5f; // Duration of the scale-up animation for each GameObject

    private void Start()
    {
        // Ensure the arrays are properly set
        if (gameObjects.Length != targetScales.Length)
        {
            Debug.LogError("GameObjects and TargetScales arrays must have the same length.");
            return;
        }

        StartCoroutine(ScaleUpSequence());
    }

    private IEnumerator ScaleUpSequence()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < gameObjects.Length; i++)
        {
            GameObject obj = gameObjects[i];
            if (obj != null)
            {
                // Start from scale zero
                obj.transform.localScale = Vector3.zero;

                // Animate to the assigned scale from the targetScales array
                yield return obj.transform.DOScale(targetScales[i], duration).WaitForCompletion();
            }
        }
    }
}
