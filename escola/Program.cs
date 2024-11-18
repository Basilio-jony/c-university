using System;
using System.Collections.Generic;
using System.Linq;

public class Disciplina
{
    public string NomeCadeira;
    public Professor Professor;

    public Disciplina(string nomeCadeira, Professor professor)
    {
        NomeCadeira = nomeCadeira;
        Professor = professor;
    }
}

public class Professor
{
    public string Nome;
    public int Idade;
    public string Genero;
    public float Salario;

    public Professor(string nome, int idade, string genero, float salario)
    {
        Nome = nome;
        Idade = idade;
        Genero = genero;
        Salario = salario;
    }
}

class Program
{
    static void Main(string[] argc)
    {
        List<Professor> professores = new List<Professor>
        {
            new Professor("João Silva", 30, "M", 50000),
            new Professor("Maria Oliveira", 25, "F", 40000),
            new Professor("Pedro Santos", 35, "M", 60000),
            new Professor("Ana Costa", 25, "F", 70000)
        };
        //criar disciplinas e associando professores
        List<Disciplina> disciplinas = new List<Disciplina>
        {
            new Disciplina("Matemática", professores[1]), //Maria oliveira
            new Disciplina("História", professores[0]), //Joao silva
            new Disciplina("Física", professores[3]), //Ana costa
            new Disciplina("Informática", professores[2]) //Pedro santos
        };

        Professor profMaiorSal = professores[0];
        Professor profMaisjovem = professores[0];
        //encontrar o professor com maior salário e o mais jovem
        foreach (var professor in professores)
        {
            if (professor.Salario > profMaiorSal.Salario)
            {
                profMaiorSal = professor;
            }
            if (professor.Idade < profMaisjovem.Idade)
            {
                profMaisjovem = professor;
            }
        }
        //listas para armazenar professores por gênero
        List<Professor> profsFemeninos = new List<Professor>();
        List<Professor> profsMasculinos = new List<Professor>();
        //separar professores por gênero
        foreach (var professor in professores)
        {
            if (professor.Genero == "F")
            {
                profsFemeninos.Add(professor);
            }
            else if (professor.Genero == "M")
            {
                profsMasculinos.Add(professor);
            }
        }
        //imprime os resultados
        Console.WriteLine($"professor com o maior salário: {profMaiorSal.Nome}, Salario: {profMaiorSal.Salario}");
        Console.WriteLine($"professor mais jovem: {profMaisjovem.Nome}, Idade: {profMaisjovem.Idade}");
        //imprime as listas por generos
        Console.WriteLine("\nProfessores do genero Feminino:");
        foreach (var prof in profsFemeninos)
        {
            Console.WriteLine($"Nome: {prof.Nome}, Idade: {prof.Idade}, Salario: {prof.Salario}");
        }

        Console.WriteLine("\nProfessores do genero masculino:");
        foreach (var prof in profsMasculinos)
        {
            Console.WriteLine($"Nome: {prof.Nome}, Idade: {prof.Idade}, Salario: {prof.Salario}");
        }
        //imprime as disciplinas e seus profs
        Console.WriteLine("\nDisciplinas e seus professores:");
        for (int i = 0; i < disciplinas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {disciplinas[i].NomeCadeira} - {disciplinas[i].Professor.Nome}");
        }
        //finalmente acabou essa desgraça :) 
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey(); //essa porra espera o usuario pressionar uma tecla
        //quem nao entender se ferrou!!!
    }
}