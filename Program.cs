using System;
using System.Collections.Generic;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string nomeJogador = "";
int vitorias = 0, derrotas = 0, empates = 0;

ExibirBoasVindas();
nomeJogador = DefinirNomeJogador();

bool rodando = true;
while (rodando)
{
    Console.Clear();
    Console.WriteLine($"--- JOGADOR ATUAL: {nomeJogador} ---");
    Console.WriteLine("1 - Jogar Jokenpô");
    Console.WriteLine("2 - Ver Estatísticas");
    Console.WriteLine("3 - Mudar de Jogador");
    Console.WriteLine("0 - Sair");
    Console.Write("\nEscolha uma opção: ");

    char opcaoMenu = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (opcaoMenu)
    {
        case '1':
            JogarRodada(ref vitorias, ref derrotas, ref empates);
            break;
        case '2':
            ExibirEstatisticas(nomeJogador, vitorias, derrotas, empates);
            break;
        case '3':
            nomeJogador = MudarJogador(out vitorias, out derrotas, out empates);
            break;
        case '0':
            rodando = false;
            break;
        default:
            Console.WriteLine("Opção inválida! Tente novamente.");
            AguardarTecla();
            break;
    }
}

Console.WriteLine("\n👋 Tchau! Até a próxima!");

void ExibirBoasVindas()
{
    Console.WriteLine("😀 Olá! Vamos jogar Jokenpô?");
}

string DefinirNomeJogador()
{
    string nome;
    do
    {
        Console.Write("Digite o seu nome para começar: ");
        nome = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(nome));
    return nome;
}

void JogarRodada(ref int v, ref int d, ref int e)
{
    Console.WriteLine("\nEscolha: 0 - Pedra ✊, 1 - Papel ✋ ou 2 - Tesoura ✌");
    char escolha = Console.ReadKey().KeyChar;

    if (escolha != '0' && escolha != '1' && escolha != '2')
    {
        Console.WriteLine("\n❌ Opção inválida!");
        AguardarTecla();
        return;
    }

    int opcaoPC = new Random().Next(3);
    int opcaoUsuario = int.Parse(escolha.ToString());

    ExibirEscolhas(opcaoUsuario, opcaoPC);

    if (opcaoUsuario == opcaoPC)
    {
        Console.WriteLine("😀 Empatamos!");
        e++;
    }
    else if ((opcaoUsuario == 0 && opcaoPC == 2) ||
             (opcaoUsuario == 1 && opcaoPC == 0) ||
             (opcaoUsuario == 2 && opcaoPC == 1))
    {
        Console.WriteLine("😀 Parabéns! Você venceu.");
        v++;
    }
    else
    {
        Console.WriteLine("😀 Haha, eu venci!");
        d++;
    }
    AguardarTecla();
}

void ExibirEscolhas(int usuario, int pc)
{
    string[] nomes = { "Pedra ✊", "Papel ✋", "Tesoura ✌" };
    Console.WriteLine($"\nVocê escolheu {nomes[usuario]}");
    Console.WriteLine($"Eu escolhi {nomes[pc]}");
}

void ExibirEstatisticas(string nome, int v, int d, int e)
{
    Console.WriteLine($"\n=== Estatísticas de {nome} ===");
    Console.WriteLine($"Vitórias: {v}");
    Console.WriteLine($"Derrotas: {d}");
    Console.WriteLine($"Empates:  {e}");
    AguardarTecla();
}

string MudarJogador(out int v, out int d, out int e)
{
    v = 0; d = 0; e = 0;
    return DefinirNomeJogador();
}

void AguardarTecla()
{
    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}
