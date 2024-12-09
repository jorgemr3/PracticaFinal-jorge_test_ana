using UnityEngine;
using TMPro;

public class RandomQuestion : MonoBehaviour
{
    public TextMeshProUGUI questionText; // Arrastra aquí el TextMeshProUGUI element en el Inspector
    public int questionCount = 5; // Contador de preguntas
    [TextArea(3, 10)] public string[] questions = new string[5]; // Arreglo de preguntas inicializado con 5 preguntas

    void OnValidate()
    {
        // Asegúrate de que el arreglo de preguntas tenga el mismo tamaño que el contador
        if (questions.Length != questionCount)
        {
            System.Array.Resize(ref questions, questionCount);
        }
    }

    void Start()
    {
        DisplayRandomQuestion();
    }

    public void DisplayRandomQuestion()
    {
        if (questions.Length == 0 || string.IsNullOrEmpty(questions[0]))
        {
            questionText.text = "No hay preguntas disponibles.";
            return;
        }

        int randomIndex = Random.Range(0, questions.Length);
        questionText.text = questions[randomIndex];
    }
}
