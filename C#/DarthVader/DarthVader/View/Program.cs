﻿using System;
using System.Collections.Generic;
using DarthVader.Model;
using DarthVader.DAO;

namespace DarthVader.View
{
    class Program
    {
        static void Main(string[] args)
        {
            int escolha;
            do
            {
                Menu(); //Só imprime o menu//
                escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Adiciona_Jogo(escolha);
                        break;
                    case 2:
                        Adiciona_Jogo(escolha);
                        break;
                    case 3:
                        Lista_Jogos_em_Casa();
                        break;
                    case 4:
                        Lista_Jogos_Emprestados();
                        break;
                    //case 5:
                    //   Lista_Jogos_Emprestados_por_RG();
                    //  break;
                    case 6:
                        EmprestarJogo();
                        break;
                    //case 7:
                    //   Devolucao();
                    //  break;
                    //case 8:
                    //   Lista_Valor_de_todos_os_jogos();
                    //  break;
                }
            } while (escolha != 9);
        }

        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////

        public static void Adiciona_Jogo(int escolha)
        {
            Jogo jogo = new Jogo();

            if (escolha == 1)
            {
                Console.WriteLine("Adicionando jogo de Playstation3 à coleção: ");
                jogo.plataforma = "Playstation 3"; //Ja adicionando a plataforma.
            }
            else
            {
                Console.WriteLine("Adicionando jogo de Xbox360 à coleção: ");
                jogo.plataforma = "Xbox 360"; //Ja adicionando a plataforma.
            }

            Console.WriteLine("Título do Jogo?");
            jogo.titulo = Console.ReadLine();

            //Adicionar bloco que verifica se o jogo ja está na coleção

            Console.WriteLine("Ano de Lançamento?");
            jogo.ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Quanto pagou neste jogo?");
            jogo.custo = float.Parse(Console.ReadLine());

            jogo.emprestado = false; //Não emprestado

            jogo.data_cadastro = DateTime.Now;

            JogosDAO.Insert(jogo);
        }
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////
            public static void EmprestarJogo()
        {
            Jogo jogo = new Jogo();
            Console.WriteLine("Nome do Jogo");
            jogo.titulo = Console.ReadLine();

            jogo = JogosDAO.search(jogo); //Verifica se o jogo esta em casa

            if (jogo != null)
            {
                if (!jogo.emprestado)
                {

                    Console.WriteLine("Achou");
                    JogosDAO.Toggler(jogo); //Marca como emprestado

                    Emprestimo emprestar = new Emprestimo(); //Ja que tem o jogo, criamos o objeto do emprestimo
                    emprestar.jogo = jogo; //Emprestimos.Jogos_ID recebe o jogo

                    Console.WriteLine("Qual o seu nome?");
                    emprestar.nome = Console.ReadLine();

                    Console.WriteLine("Qual o seu RG?");
                    emprestar.rg = int.Parse(Console.ReadLine());

                    emprestar.data_do_emprestimo = DateTime.Now;
                    EmprestimosDAO.Insert(emprestar);
                }
            }
            else {
                Console.WriteLine("Jogo não cadastrado");
            }
        }

        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////

        public static void Lista_Jogos_Emprestados()
        {
            List<Emprestimo> emprestados = new List<Emprestimo>();
            emprestados = EmprestimosDAO.Lista();

            if (emprestados != null)
            {
                foreach (Emprestimo x in emprestados)
                {
                    Console.WriteLine("");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Nome: " + x.nome);
                    Console.WriteLine("Plataforma : " + x.jogo.plataforma);
                    Console.WriteLine("Título: " + x.jogo.titulo);
                    Console.WriteLine("Adicionado em " + x.jogo.data_cadastro);
                    Console.WriteLine("Emprestei em " + x.data_do_emprestimo);
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Lista de emprestados vazia... good!\n");
            }
        }
        /////////////////////////////////////////////////////////////////////////////        
        /////////////////////////////////////////////////////////////////////////////
        public static void Lista_Jogos_em_Casa()
        {
            List<Jogo> jogos = new List<Jogo>();
            jogos = JogosDAO.Lista();

            if (jogos != null)
            {
                foreach (Jogo x in jogos)
                {
                    {
                        Console.WriteLine("");
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Plataforma: " + x.plataforma);
                        Console.WriteLine("Título: " + x.titulo);
                        Console.WriteLine("Ano: " + x.ano);
                        Console.WriteLine("Custo: " + x.custo);
                        Console.WriteLine("Adicionado em " + x.data_cadastro);
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("");
                    }
                }
            }
            else
            {
                Console.WriteLine("Lista de jogos vazia\n");
            }
        }
        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////

        public static void Menu()
        {
            Console.WriteLine("1 - Adicionar jodo de PS3 à Coleção");
            Console.WriteLine("2 - Adicionar jogo de Xbox 360 à Coleção");
            Console.WriteLine("3 - Listar todos os jogos que estão em casa");
            Console.WriteLine("4 - Listar todos os jogos emprestados");
            //Console.WriteLine("5 - Consultar jogos que emprestei pra alguém por RG");
            Console.WriteLine("6 - Emprestar Jogo Para alguém");
            //Console.WriteLine("7 - Alguém quer devolver um jogo");
            //Console.WriteLine("8 - Listar valor total de todos os meus jogos, inclusive os emprestados");
            Console.WriteLine("9 - Sair");
        }
    }
}