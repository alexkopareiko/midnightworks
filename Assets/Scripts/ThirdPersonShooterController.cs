using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;


[RequireComponent(typeof(StarterAssetsInputs))]
[RequireComponent(typeof(ThirdPersonController))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Stats))]

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField]
    private float normalSensitivity;
    [SerializeField]
    private float aimSensitivity;
    [SerializeField]
    private LayerMask aimColliderLayerMask;
    [SerializeField]
    private Transform debugTransform;
    [SerializeField]
    private Transform spawnBulletPosition;
    [SerializeField]
    private Transform vfxBlue;
    [SerializeField]
    private Transform vfxYellow;
    [SerializeField]
    private float damage = 1f;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private Animator animator;
    private Stats stats;


    private void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
        stats = GetComponent<Player>();
    }

    private void Update()
    {
        if (stats.isDead) return;
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }


        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            //animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 10f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            //animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));

        }

        if (starterAssetsInputs.shoot)
        {
            animator.SetTrigger("Fire");

            //Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            if(hitTransform != null)
            {
                if(hitTransform.GetComponent<Enemy>() != null) {
                    Instantiate(vfxYellow, raycastHit.point, Quaternion.identity);
                    hitTransform.GetComponent<Enemy>().HealthReduce(damage);
                }
                else
                {
                    Instantiate(vfxBlue, raycastHit.point, Quaternion.identity);
                }
            }
            starterAssetsInputs.shoot = false;
        }



    }
}
