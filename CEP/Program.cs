using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;

namespace CEP
{
    class Program
    {
        static void Main(string[] args)
        {
            char menu;
            Console.WriteLine("--------CONSULTA DE CEPs E ENDEREÇOS--------", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.Write("ESCOLHA UMA OPÇÃO:\nOPÇÃO 1 - CONSULTAR CEP POR ENDEREÇO\nOPÇÃO 2 - CONSULTAR ENDEREÇO POR CEP\n--->  ", Console.ForegroundColor = ConsoleColor.Cyan);
            EscolherNovamente:
            menu = char.Parse(Console.ReadLine());
            if (menu == '1') Opção1();
            else if (menu == '2') Opção2();
            else Console.Write("\nOPÇÃO INVÁLIDA! ESCOLHA NOVAMENTE: "); goto EscolherNovamente;
        }
        static void Opção1()
        {
            XmlDocument document = new XmlDocument();
            document.Load("cep.xml");
            string opçao;
            Console.WriteLine("OPÇÃO 1\n\t---CONSULTAR CEP POR ENDEREÇO---", Console.ForegroundColor = ConsoleColor.Green);
            Console.Write("DIGITE O ENDEREÇO: ");
            opçao = Console.ReadLine();
            XmlNodeList endereços = document.SelectNodes("ceps/registro");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (XmlNode itens in endereços)
            {
                string cep = itens["cep"].InnerText;
                string cidade = itens["cidade"].InnerText;
                string uf = itens["uf"].InnerText;
                string bairro = itens["bairro"].InnerText;
                string logradouro = itens["logradouro"].InnerText;
                string edificio = itens["complemento"].InnerText;
                if (opçao == logradouro) Console.WriteLine($"CEP: [{cep}] Cidade: [{cidade}] UF: [{uf}]\nBairro: [{bairro}] Logradouro: [{logradouro}] Edifício: [{edificio}]", Console.ForegroundColor = ConsoleColor.White);
            }
            stopwatch.Stop();
            Console.WriteLine($"Tempo da pesquisa: {stopwatch.Elapsed}");
            Console.Read();
        }
        static void Opção2()
        {
            XmlDocument document = new XmlDocument();
            document.Load("cep.xml");
            string opçao;
            Console.WriteLine("OPÇÃO 2\n\t---CONSULTAR ENDEREÇO POR CEP---", Console.ForegroundColor = ConsoleColor.Green);
            Console.Write("DIGITE O CEP: ");
            opçao = Console.ReadLine();
            XmlNodeList endereços = document.SelectNodes("ceps/registro");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (XmlNode itens in endereços)
            {
                string cep = itens["cep"].InnerText;
                string cidade = itens["cidade"].InnerText;
                string uf = itens["uf"].InnerText;
                string bairro = itens["bairro"].InnerText;
                string logradouro = itens["logradouro"].InnerText;
                string edificio = itens["complemento"].InnerText;
                if (opçao == cep) Console.WriteLine($"CEP: [{cep}] Cidade: [{cidade}] UF: [{uf}]\nBairro: [{bairro}] Logradouro: [{logradouro}] Edifíco: [{edificio}]", Console.ForegroundColor = ConsoleColor.White);
            }
            stopwatch.Stop();
            Console.WriteLine($"Tempo da pesquisa: {stopwatch.Elapsed}");
            Console.Read();
        }
    }
}
