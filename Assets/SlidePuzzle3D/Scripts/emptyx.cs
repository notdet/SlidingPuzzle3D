/*
using UnityEngine;

public class emptyx : MonoBehaviour
{
    public void FindAndMoveChild(string childName, Vector3 targetPosition)
    {
        Transform child = transform.Find(childName);
        if (child != null)
        {
            if (childName == "greencube")
            {
                targetPosition += new Vector3(0f, 4f, 0f); // Adjust the Y position
            }

            child.position = targetPosition;
        }
        else
        {
            Debug.LogWarning($"Child with name '{childName}' not found.");
        }
    }
}
*/