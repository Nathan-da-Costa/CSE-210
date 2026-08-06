using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    // Classe Base Abstrata para cumprir os requisitos de Herança e Abstração
    public abstract class MindfulnessActivity
    {
        // Atributos privados (Encapsulamento)
        private string _name;
        private string _description;
        private int _duration;

        public MindfulnessActivity(string name, string description)
        {
            _name = name;
            _description = description;
            _duration = 0;
        }

        // Métodos Getters e Setters protegidos/públicos
        public int GetDuration()
        {
            return _duration;
        }

        public void SetDuration(int duration)
        {
            _duration = duration;
        }

        // Mensagem de início comum a todas as atividades
        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Bem-vindo(a) à Atividade de {_name}.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("Por favor, digite a duração da atividade em segundos: ");
            
            if (int.TryParse(Console.ReadLine(), out int duration))
            {
                _duration = duration;
            }
            else
            {
                _duration = 10; // Valor padrão caso a entrada seja inválida
                Console.WriteLine("Entrada inválida. Definido para 10 segundos por padrão.");
            }

            Console.Clear();
            Console.WriteLine("Prepare-se...");
            ShowSpinner(3);
        }

        // Mensagem de término comum a todas as atividades
        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Bom trabalho!!");
            ShowSpinner(3);
            Console.WriteLine();
            Console.WriteLine($"Você concluiu a atividade de {_name} por {_duration} segundos.");
            ShowSpinner(3);
        }

        // Animação de contagem regressiva
        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // Animação de Spinner (Carregamento)
        public void ShowSpinner(int seconds)
        {
            List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
            int startTime = Environment.TickCount;
            int i = 0;

            while ((Environment.TickCount - startTime) < seconds * 1000)
            {
                string s = animationStrings[i];
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b");

                i++;
                if (i >= animationStrings.Count)
                {
                    i = 0;
                }
            }
        }

        // Método abstrato que será implementado nas classes derivadas
        public abstract void Run();
    }

    // 1. Atividade de Respiração
    public class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity() : base(
            "Respiração", 
            "Esta atividade ajudará você a relaxar guiando-a(o) através de respirações lentas de inspiração e expiração. Esvazie sua mente e concentre-se na sua respiração.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();

            int duration = GetDuration();
            int elapsed = 0;

            while (elapsed < duration)
            {
                Console.Write(" Inspire... ");
                ShowCountDown(4);
                Console.WriteLine();

                elapsed += 4;
                if (elapsed >= duration) break;

                Console.Write(" Expire... ");
                ShowCountDown(4);
                Console.WriteLine();

                elapsed += 4;
            }

            DisplayEndingMessage();
        }
    }

    // 2. Atividade de Reflexão
    public class ReflectingActivity : MindfulnessActivity
    {
        private List<string> _prompts;
        private List<string> _questions;

        public ReflectingActivity() : base(
            "Reflexão", 
            "Esta atividade ajudará você a refletir sobre momentos da sua vida em que demonstrou força e resiliência. Isso ajudará a reconhecer o seu poder interior.")
        {
            _prompts = new List<string>
            {
                "Pense em um momento em que você defendeu outra pessoa.",
                "Pense em um momento em que você fez algo realmente difícil.",
                "Pense em um momento em que você ajudou alguém necessitado.",
                "Pense em um momento em que você fez algo totalmente altruísta."
            };

            _questions = new List<string>
            {
                "Por que essa experiência foi significativa para você?",
                "Você já fez algo parecido antes?",
                "Como você começou?",
                "Como você se sentiu quando terminou?",
                "O que tornou esta vez diferente de outras vezes em que não teve tanto sucesso?",
                "Qual é a sua coisa favorita sobre essa experiência?",
                "O que você pode aprender com essa experiência que se aplica a outras situações?",
                "O que você aprendeu sobre si mesma(o) através desta experiência?",
                "Como você pode manter essa experiência em mente no futuro?"
            };
        }

        public override void Run()
        {
            DisplayStartingMessage();

            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];

            Console.WriteLine("Considere o seguinte:");
            Console.WriteLine();
            Console.WriteLine($" --- {prompt} --- ");
            Console.WriteLine();
            Console.WriteLine("Quando tiver isso em mente, pressione enter para continuar.");
            Console.ReadLine();

            Console.WriteLine("Agora pondere sobre cada uma das seguintes perguntas relacionadas a esta experiência.");
            Console.Write("Você pode começar em: ");
            ShowCountDown(5);
            Console.Clear();

            int duration = GetDuration();
            int elapsed = 0;

            while (elapsed < duration)
            {
                string question = _questions[rand.Next(_questions.Count)];
                Console.Write($"> {question} ");
                ShowSpinner(5);
                Console.WriteLine();
                elapsed += 5;
            }

            DisplayEndingMessage();
        }
    }

    // 3. Atividade de Listagem
    public class ListingActivity : MindfulnessActivity
    {
        private List<string> _prompts;

        public ListingActivity() : base(
            "Listagem", 
            "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, listando tantas coisas quanto puder em uma determinada área.")
        {
            _prompts = new List<string>
            {
                "Quem são as pessoas que você aprecia?",
                "Quais são os seus pontos fortes pessoais?",
                "Quem são as pessoas que você ajudou esta semana?",
                "Quando você sentiu inspiração ou paz este mês?",
                "Quem são alguns dos seus heróis pessoais?"
            };
        }

        public override void Run()
        {
            DisplayStartingMessage();

            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];

            Console.WriteLine("Liste tantas respostas quanto puder para o seguinte prompt:");
            Console.WriteLine($" --- {prompt} --- ");
            Console.Write("Você poderá começar em: ");
            ShowCountDown(5);
            Console.WriteLine();

            List<string> userItems = new List<string>();
            int duration = GetDuration();
            
            // Simulação de captura de itens baseada no tempo
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    userItems.Add(input);
                }
            }

            Console.WriteLine($"Você listou {userItems.Count} itens!");
            DisplayEndingMessage();
        }
    }

    // Classe Principal do Programa (Menu)
    public class Program
    {
        /* 
         * Relatório de Superação dos Requisitos (Exceeding Requirements):
         * - Além dos requisitos principais, adicionei validação robusta de entradas do usuário 
         *   para evitar falhas caso digitem letras no lugar de números de segundos.
         * - Estrutura limpa de código modularizado em arquivos lógicos separados conceitualmente.
         */
        static void Main(string[] args)
        {
            int choice = 0;

            while (choice != 4)
            {
                Console.Clear();
                Console.WriteLine("Menu de Opções:");
                Console.WriteLine("  1. Iniciar Atividade de Respiração");
                Console.WriteLine("  2. Iniciar Atividade de Reflexão");
                Console.WriteLine("  3. Iniciar Atividade de Listagem");
                Console.WriteLine("  4. Sair");
                Console.Write("Selecione uma opção entre 1 e 4: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    MindfulnessActivity activity = null;

                    switch (choice)
                    {
                        case 1:
                            activity = new BreathingActivity();
                            break;
                        case 2:
                            activity = new ReflectingActivity();
                            break;
                        case 3:
                            activity = new ListingActivity();
                            break;
                        case 4:
                            Console.WriteLine("Obrigado por usar o Programa de Mindfulness. Até logo!");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            Thread.Sleep(2000);
                            break;
                    }

                    if (activity != null)
                    {
                        activity.Run();
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}