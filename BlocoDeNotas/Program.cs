using System;
using System.IO;

class BlocoDeNotasCRUD
{
    static string pastaNotas = "notas";

    static void Main()
    {
        if(!Directory.Exists(pastaNotas))
            Directory.CreateDirectory(pastaNotas);

        while(true)
        {
            Console.Clear();
            Console.WriteLine("=== BLOCO DE NOTAS (CRUD) ===");
            Console.WriteLine("1. Criar nova nota");
            Console.WriteLine("2. Listar notas");
            Console.WriteLine("3. Ler nota");
            Console.WriteLine("4. Editar nota");
            Console.WriteLine("5. Deletar nota");
            Console.WriteLine("6. Sair");
            Console.WriteLine("\nEscolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": CriarNota(); break;
                case "2": ListarNotas(); break;
                case "3": LerNota(); break;
                case "4": EditarNota(); break;
                case "5": DeletarNota(); break;
                case "6": return;
                    default:
                    Console.WriteLine("Opção Inválida!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void CriarNota()
    {
        Console.Clear();
        Console.Write("Digite o nome da nota: ");
        string nome = Console.ReadLine();
        string caminho = Path.Combine(pastaNotas, nome + ".txt");

        if (File.Exists(caminho))
        {
            Console.WriteLine("Ja existe uma nota com esse nome.");
        }
        else
        {
            Console.WriteLine("Digite o conteúdo da nota (FIM para terminar)");
            string linha;
            string conteudo = "";
            while ((linha = Console.ReadLine()) != null && linha.ToUpper() != "FIM")
            {
                conteudo += linha + Environment.NewLine;
            }

            File.WriteAllText(caminho, conteudo);
            Console.WriteLine("Nota criada com sucesso!");
        }

        Console.ReadKey();
    }

    static void ListarNotas()
    {
        Console.Clear();
        string[] arquvios = Directory.GetFiles(pastaNotas, "*.txt");

        if(arquvios.Length == 0)
        {
            Console.WriteLine("Nenhuma nota encontrada.");
        }
        else
        {
            Console.WriteLine("Notas disponíveis:");
            foreach (string arq in arquvios)
            {
                Console.WriteLine("- " + Path.GetFileNameWithoutExtension(arq));
            }
        }
        Console.ReadKey();
    }

    static void LerNota()
    {
        Console.Clear();
        Console.WriteLine("Digite o nome da nota que deseja ler: ");
        string nome = Console.ReadLine();
        string caminho = Path.Combine(pastaNotas, nome + ".txt");

        if(File.Exists(caminho))
        {
            string conteudo = File.ReadAllText(caminho);
            Console.WriteLine($"\n--- Conteúdo de '{nome}' ---");
            Console.WriteLine(conteudo);
        }
        else
        {
            Console.WriteLine("Nota não encontrada.");
        }
        Console.ReadKey();
    }

    static void EditarNota()
    {
        Console.Clear();
        Console.WriteLine("Digite o nome da nota que deseja editar: ");
        string nome = Console.ReadLine();
        string caminho = Path.Combine(pastaNotas, nome + ".txt");

        if(File.Exists(caminho))
        {
            Console.WriteLine("Digite o novo conteúdo da nota (FIM para terminar)");
            string linha;
            string conteudo = "";
            while ((linha = Console.ReadLine()) != null && linha.ToUpper() != "FIM")
            {
                conteudo += linha + Environment.NewLine;
            }

            File.WriteAllText(caminho, conteudo);
            Console.WriteLine("Nota atualizada com sucesso!");
        }
        else
        {
            Console.WriteLine("Nota não encontrada.");
        }
        Console.ReadKey();
    }

    static void DeletarNota()
    {
        Console.Clear();
        Console.WriteLine("Digite o nome da nota que deseja deletar: ");
        string nome = Console.ReadLine();
        string caminho = Path.Combine(pastaNotas, nome + ".txt");

        if (File.Exists(caminho))
        {
            File.Delete(caminho);
            Console.WriteLine("Nota deletada com sucesso!");
        }
        else
        {
            Console.WriteLine("Nota não encontrada.");
        }
        Console.ReadKey();
    }

}