using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float baseSpeed;
    private MapManager _mapManager;
    
    void Awake()
    {
        _mapManager = FindObjectOfType<MapManager>();

    }

    // Update is called once per frame
    void Update()
    {
        float adjustedSpeed = baseSpeed * _mapManager.GetSpeedMultiplier(transform.position);
        transform.position += -transform.right * Time.deltaTime * adjustedSpeed;
    }

    private void SetRotation()
    {
        float newRotation = Random.Range(0, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
