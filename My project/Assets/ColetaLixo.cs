using UnityEngine;
using UnityEngine.UI; // Para trabalhar com UI Text

public class ColetaLixo : MonoBehaviour
{
    private GameObject lixoProximo; // Declaração da variável para armazenar o lixo detectado
    public int pontos;
    public Text textoPontuacao; // Referência ao UI Text

    void Start()
    {
        pontos = 0; // Inicializa a pontuação
    }

    void Update()
    {
        // Verifica se o jogador pressiona a tecla "E" e há um lixo próximo
        if (Input.GetKeyDown(KeyCode.E) && lixoProximo != null)
        {
            // Adiciona pontos dependendo do tipo de lixo
            if (lixoProximo.CompareTag("lixo"))
            {
                pontos += 10;
            }
            else if (lixoProximo.CompareTag("lixoReciclavel"))
            {
                pontos += 20;
            }

            // Atualiza o texto da pontuação
            textoPontuacao.text = "Pontuação: " + pontos;

            // Destroi o lixo
            Destroy(lixoProximo);
            lixoProximo = null; // Remove a referência ao lixo
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta se o jogador está próximo de um lixo
        if (other.CompareTag("lixo") || other.CompareTag("lixoReciclavel"))
        {
            lixoProximo = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove a referência ao lixo quando o jogador se afasta
        if (other.gameObject == lixoProximo)
        {
            lixoProximo = null;
        }
    }
}
