using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private Rigidbody _plank;
    [SerializeField] private float _force;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _plank.AddForce(_plank.transform.forward * _force);
        }
    }
}