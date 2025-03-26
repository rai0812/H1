using System;

class JogoDaVelha
{
    static char[] tabuleiro = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int jogador = 1;
    static int opcao;
    static int rodada = 1;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            ExibirTabuleiro();
            Console.WriteLine($"Rodada {rodada}");

            if (jogador == 1)
            {
                Console.WriteLine("Digite a coluna: ");
                opcao = int.Parse(Console.ReadLine());

                if (tabuleiro[opcao - 1] != 'X' && tabuleiro[opcao - 1] != 'O')
                {
                    tabuleiro[opcao - 1] = 'X';
                    jogador = 2;
                    rodada++;
                }
                else
                {
                    Console.WriteLine("Posição ocupada! Tente novamente.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("É a vez da máquina...");

                Random random = new Random();
                opcao = random.Next(1, 10);

                if (tabuleiro[opcao - 1] != 'X' && tabuleiro[opcao - 1] != 'O')
                {
                    tabuleiro[opcao - 1] = 'O';
                    jogador = 1;
                    rodada++;
                }
            }

            int vencedor = VerificarVencedor();
            if (vencedor != 0)
            {
                Console.Clear();
                ExibirTabuleiro();
                if (vencedor == 1)
                    Console.WriteLine("Parabéns, você venceu!");
                else
                    Console.WriteLine("A máquina venceu!");

                break;
            }

            if (rodada > 9)
            {
                Console.Clear();
                ExibirTabuleiro();
                Console.WriteLine("O jogo empatou!");
                break;
            }
        }

        Console.ReadKey();
    }

    static void ExibirTabuleiro()
    {
        Console.WriteLine("Jogador (X) vs Máquina (O)");
        Console.WriteLine();
        Console.WriteLine($" {tabuleiro[0]} | {tabuleiro[1]} | {tabuleiro[2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {tabuleiro[3]} | {tabuleiro[4]} | {tabuleiro[5]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {tabuleiro[6]} | {tabuleiro[7]} | {tabuleiro[8]} ");
        Console.WriteLine();
    }

    static int VerificarVencedor()
    {
        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[i * 3] == tabuleiro[i * 3 + 1] && tabuleiro[i * 3 + 1] == tabuleiro[i * 3 + 2])
            {
                if (tabuleiro[i * 3] == 'X')
                    return 1;
                else if (tabuleiro[i * 3] == 'O')
                    return 2;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[i] == tabuleiro[i + 3] && tabuleiro[i + 3] == tabuleiro[i + 6])
            {
                if (tabuleiro[i] == 'X')
                    return 1;
                else if (tabuleiro[i] == 'O')
                    return 2;
            }
        }

        if (tabuleiro[0] == tabuleiro[4] && tabuleiro[4] == tabuleiro[8])
        {
            if (tabuleiro[0] == 'X')
                return 1;
            else if (tabuleiro[0] == 'O')
                return 2;
        }
        if (tabuleiro[2] == tabuleiro[4] && tabuleiro[4] == tabuleiro[6])
        {
            if (tabuleiro[2] == 'X')
                return 1;
            else if (tabuleiro[2] == 'O')
                return 2;
        }

        return 0;
    }
}