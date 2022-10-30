using UnityEngine;

public class SpawnerForTesting : MonoBehaviour
{

    [SerializeField] private GameObject Skele;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var randomPos = new Vector3(9.5f, Random.Range(0, 5) + 0.5f, 0f);
            Instantiate(Skele, randomPos, Quaternion.identity);
        }
    }
}
