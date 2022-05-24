using System;
using IntroducaoEFCore.Domain;
using IntroducaoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IntroducaoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new Data.ApplicationContext();

            //db.Database.Migrate();
            var existe = db.Database.GetPendingMigrations().Any();
            if (existe)
            {
                // 
            }

            //InserirDados();
            //InserirDadosEmMassa();

        }

        private static void ConsultarDados()
        {
            using var db = new Data.ApplicationContext();
            var consultaPorSintaxe = (from c in db.clientes where c.Id > 0 select c).ToList();
            var consultaPorMetodo = db.clientes.Where(p => p.Id > 0).ToList();
            foreach(var cliente in consultaPorMetodo)
            {
                Console.WriteLine($"Consultado Cliente: {cliente.Id}");
                db.clientes.Find(cliente.Id);
            }
        }

        private static void InserirDadosEmMassa()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234564565454",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            var cliente = new Cliente
            {
                Nome = "Jean Michael",
                CEP = "99999000",
                Cidade = "Curitiba",
                Estado = "PR",
                Telefone = "41992119200"
            };

            //using var db = new Data.ApplicationContext();
            //db.AddRange(produto, cliente);

            //var registros = db.SaveChanges();
            //Console.WriteLine($"Total Registro(s): {registros}");

        }

        private static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234564565454",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            //using var db = new Data.ApplicationContext();
            ////db.Produtos.Add(produto);
            ////db.Set<Produto>().Add(produto);
            ////db.Entry(produto).State = EntityState.Added;
            //db.Add(produto);

            //var registros = db.SaveChanges();
            //Console.WriteLine($"Total registro(s): {registros}");
        }
    }
}