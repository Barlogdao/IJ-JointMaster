using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _projectilePoint;

    [SerializeField] private KeyCode _shootKey;
    [SerializeField] private KeyCode _reloadKey;

    [SerializeField] private float _shootAnchorValue = 0f;
    [SerializeField] private float _normalAnchorValue = 5f;

    private Rigidbody _spoonRigidbody;

    private bool _hasProjectile;
    private Coroutine _reloading = null;
    private WaitForSeconds _reloadDuration = new WaitForSeconds(2f);


    private void Awake()
    {
        _spoonRigidbody = _springJoint.GetComponent<Rigidbody>();

        SpawnProjectile();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey) && _hasProjectile)
        {
            Shoot();
        }
        else if (Input.GetKeyDown(_reloadKey) && _hasProjectile == false)
        {
            Reload();
        }
    }

    private void Shoot()
    {
        SetAnchorValue(_shootAnchorValue);
        _hasProjectile = false;
    }

    private void Reload()
    {
        if (_reloading == null)
        {
            _reloading = StartCoroutine(Reloading());
        }
    }

    private IEnumerator Reloading()
    {
        SetAnchorValue(_normalAnchorValue);

        yield return _reloadDuration;

        SpawnProjectile();
        _reloading = null;
    }

    private void SetAnchorValue(float value)
    {
        Vector3 anchor = _springJoint.connectedAnchor;
        anchor.y = value;

        _springJoint.connectedAnchor = anchor;
        _spoonRigidbody.WakeUp();
    }

    private void SpawnProjectile()
    {
        Instantiate(_projectilePrefab, _projectilePoint.position, Quaternion.identity);

        _hasProjectile = true;
    }
}