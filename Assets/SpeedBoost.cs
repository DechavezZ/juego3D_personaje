using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedBoost : MonoBehaviour
{
    public Slider speedSlider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement3D player =
                other.GetComponent<PlayerMovement3D>();

            if (player != null)
            {
                StartCoroutine(Boost(player));
            }
        }
    }

    IEnumerator Boost(PlayerMovement3D player)
    {
        // Guarda velocidad original
        float originalSpeed = player.forwardSpeed;

        // Obtiene el renderer del jugador
        Renderer rend = player.GetComponent<Renderer>();

        // Cambia color a rojo
        if (rend != null)
        {
            rend.material.color = Color.red;
        }

        // Aumenta velocidad
        player.forwardSpeed *= 2f;

        // Tiempo del boost
        float timer = 3f;

        // Configura slider
        if (speedSlider != null)
        {
            speedSlider.maxValue = 3f;
            speedSlider.value = 3f;
        }

        // Cuenta regresiva
        while (timer > 0)
        {
            timer -= Time.deltaTime;

            if (speedSlider != null)
            {
                speedSlider.value = timer;
            }

            yield return null;
        }

        // Regresa velocidad normal
        player.forwardSpeed = originalSpeed;

        // Regresa color normal
        if (rend != null)
        {
            rend.material.color = Color.white;
        }

        // Reinicia slider
        if (speedSlider != null)
        {
            speedSlider.value = 0;
        }
    }
}