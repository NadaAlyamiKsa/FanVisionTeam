using UnityEngine;

public class Camera360Look : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public float smoothing = 2.0f;
    public bool invertY = true;

    private Vector2 smoothedVelocity;
    private Vector2 currentLookingDirection;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            if (invertY)
                mouseDelta.y = -mouseDelta.y;

            mouseDelta *= sensitivity;
            smoothedVelocity = Vector2.Lerp(smoothedVelocity, mouseDelta, 1f / smoothing);
            currentLookingDirection += smoothedVelocity;

            transform.localRotation = Quaternion.Euler(currentLookingDirection.y, currentLookingDirection.x, 0);
        }
    }
}
