using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostAmount = 5f;

    public float boostDuration = 3f;

    private bool boosting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !boosting)
        {
            PlayerMovement3D player =
                other.GetComponent<PlayerMovement3D>();

            if (player != null)
            {
                StartCoroutine(
                    Boost(player, other.gameObject)
                );
            }
        }
    }

    IEnumerator Boost(
        PlayerMovement3D player,
        GameObject playerObject
    )
    {
        boosting = true;

        float originalSpeed = player.forwardSpeed;

        player.forwardSpeed += boostAmount;

        Renderer rend =
            playerObject.GetComponent<Renderer>();

        if (rend != null)
        {
            rend.material.color = Color.red;
        }

        yield return new WaitForSeconds(boostDuration);

        player.forwardSpeed = originalSpeed;

        if (rend != null)
        {
            rend.material.color = Color.white;
        }

        boosting = false;
    }
}