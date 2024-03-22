using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public float timeRemaining = 10f; // Tempo total em segundos
    public TMP_Text timerText; // Referência ao componente de Text Mesh Pro que mostrará o timer
    private bool timerIsRunning = false; // Verifica se o temporizador está em execução
    private bool timeIsUp = false; // Verifica se o tempo acabou

    void Start()
    {
        // Configura o temporizador para estar em execução
        timerIsRunning = true;
    }

    void Update()
    {
        // Verifica se o temporizador está em execução
        if (timerIsRunning)
        {
            // Verifica se o tempo restante é maior que 0
            if (timeRemaining > 0)
            {
                // Decrementa o tempo restante
                timeRemaining -= Time.deltaTime;
                // Atualiza o texto do timer
                DisplayTime(timeRemaining);
            }
            else
            {
                // Caso o tempo acabe, define o texto do timer como 0 e para o temporizador
                timeRemaining = 0;
                DisplayTime(timeRemaining);
                timerIsRunning = false;
                timeIsUp = true; // Indica que o tempo acabou
                // Adicione aqui qualquer ação que deseje executar quando o tempo acabe
                Debug.Log("Tempo acabou!");
            }
        }
    }

    // Método para exibir o tempo formatado no componente de Text Mesh Pro
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); // Calcula os minutos
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // Calcula os segundos

        // Atualiza o texto do componente de Text Mesh Pro para exibir o tempo restante
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Método para verificar se o tempo acabou
    public bool IsTimeUp()
    {
        return timeIsUp;
    }
}
