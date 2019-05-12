using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class DollyZoom : MonoBehaviour
{
    public Transform target;
    public float screenWidth = 4;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.LookAt(target);
        UpdateFov();
    }

    void UpdateFov()
    {
        var distance = Vector3.Distance(target.position, transform.position);
        float fov = Mathf.Atan(screenWidth / 2 / distance) * 2 * Mathf.Rad2Deg;
        cam.fieldOfView = fov;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
