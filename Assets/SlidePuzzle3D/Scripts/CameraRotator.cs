using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float rotationAngle = 45f;



    private Quaternion targetRotation;
    private bool isRotating = false;

    private void Update()
    {

       

        if (isRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
            {
                isRotating = false;
            }
        }
    }

    public void RotateRight()
    {
        if (!isRotating)
        {
            targetRotation = transform.rotation * Quaternion.Euler(0f, -rotationAngle, 0f);
            isRotating = true;
        }
    }

    public void RotateLeft()
    {
        if (!isRotating)
        {
            targetRotation = transform.rotation * Quaternion.Euler(0f, rotationAngle, 0f);
            isRotating = true;
        }
    }

}


/*  LOLS
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private Transform target; // Reference to camerarotatorMainscriptHere object
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float rotationEdgeThreshold = 20f; // Edge threshold for faster rotation
    [SerializeField] private float maxVerticalAngle = 60f; // Upper limit for vertical rotation
    [SerializeField] private float minVerticalAngle = -30f; // Lower limit for vertical rotation

    private void Update()
    {
        // Calculate rotation based on mouse input
        float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float verticalRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Calculate vertical rotation based on limits
        float newVerticalRotation = Mathf.Clamp(
            transform.localEulerAngles.x - verticalRotation,
            minVerticalAngle,
            maxVerticalAngle
        );

        // Apply rotations
        transform.localEulerAngles = new Vector3(newVerticalRotation, transform.localEulerAngles.y + horizontalRotation, 0f);

        // Continuous horizontal rotation
        float continuousHorizontalRotation = Input.GetAxis("Horizontal") * rotationSpeed;
        target.Rotate(Vector3.up, continuousHorizontalRotation * Time.deltaTime);
    }
}
*/