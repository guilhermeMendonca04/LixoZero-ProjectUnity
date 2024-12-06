using UnityEngine;
using UnityEngine.UI; // Para trabalhar com UI Text
using TMPro;
public class ColetaLixo : MonoBehaviour
{
    public GameObject lixoProximo; // Declaração da variável para armazenar o lixo detectado
    public GameObject pickUpElement;
    public int pontos;
    public TextMeshProUGUI textoPontuacao; // Referência ao UI Text
    public float distanciaMaxima = 2.0f;
    public AudioClip audio;
    public AudioSource source;

    void Start()
    {
        pontos = 0; // Inicializa a pontuação
        pickUpElement.SetActive(false);
    }

    void Update()
    {
        // Verifica se o jogador pressiona a tecla "E" e há um lixo próximo
        if (Input.GetKeyDown(KeyCode.E) && lixoProximo != null)
        {
            float distancia = Vector3.Distance(transform.position, lixoProximo.transform.position);
            if (distancia <= distanciaMaxima){
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
            source.PlayOneShot(audio);
            lixoProximo.SetActive(false);
            pickUpElement.SetActive(false);
        }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta se o jogador está próximo de um lixo
        if (other.CompareTag("lixo") || other.CompareTag("lixoReciclavel"))
        {
            lixoProximo = other.gameObject;
            pickUpElement.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove a referência ao lixo quando o jogador se afasta
        if (other.gameObject == lixoProximo)
        {
            lixoProximo = null;
            pickUpElement.SetActive(false);
        }
    }
}
