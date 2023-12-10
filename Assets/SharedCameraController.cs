using UnityEngine;

public class SharedCameraController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float minZoom = 5f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    public float FollowSpeed = 3f;

    private Vector3 offset;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        offset = cam.transform.position - ((player1.position + player2.position) / 2f);
    }

    void LateUpdate()
    {
        if (player1 == null || player2 == null)
        {
            Debug.LogError("Player references are not set in the SharedCameraController.");
            return;
        }

        Move();
        Zoom();
    }

    void Move()
    {
        Vector3 midpoint = (player1.position + player2.position) / 2f;
        Vector3 newCameraPosition = midpoint + offset;

        // Use MoveTowards for a more consistent follow speed regardless of framerate
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, newCameraPosition, FollowSpeed * Time.deltaTime);
    }


    void Zoom()
    {
        float largestDimension = GetGreatestDistance();
        // Considering the aspect ratio to ensure the zoom is consistent for both axes.
        largestDimension *= Mathf.Max(1f, cam.aspect);

        // Assuming zoomLimiter is the max expected distance for full zoom out,
        // the ratio should be 0 when players are at a distance of 0, and 1 when at or beyond zoomLimiter.
        float ratio = Mathf.Clamp(largestDimension / zoomLimiter, 0f, 1f);

        // Interpolate between minZoom (when players are close) and maxZoom (when players are far).
        // If ratio is 0 (players are close), zoom is minZoom. If ratio is 1 (players are far), zoom is maxZoom.
        float newZoom = Mathf.Lerp(minZoom, maxZoom, ratio);
        cam.orthographicSize = Mathf.Clamp(newZoom, minZoom, maxZoom);
    }




    float GetGreatestDistance()
    {
        var bounds = new Bounds(player1.position, Vector3.zero);
        bounds.Encapsulate(player2.position);
        return bounds.size.x;
    }
}
