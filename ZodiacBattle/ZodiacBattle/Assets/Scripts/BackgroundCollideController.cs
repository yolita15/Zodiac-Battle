using UnityEngine;


public class BackgroundCollideController : MonoBehaviour
{
    private int NumberOfBackgrounds;
    private float distanceBetweenBackgrounds;
    

    public void Start()
    {
        var backgrounds = GameObject.FindGameObjectsWithTag("Background");
        this.NumberOfBackgrounds = backgrounds.Length;
        this.distanceBetweenBackgrounds =
            Mathf.Abs(backgrounds[0].transform.position.y - backgrounds[1].transform.position.y);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Background") || collider.CompareTag("Enemy"))
        {
            var go = collider.gameObject;
            var originalPosition = go.transform.position;
            if (collider.CompareTag("Background"))
            {
                originalPosition.y += 13f;
            }
            else
            {
                originalPosition.y += 40f;
            }
            go.transform.position = originalPosition;
        }
    }
}
