using Microsoft.EntityFrameworkCore;
using SaborExpress.Context;
using SaborExpress.Models;
using SaborExpress.Repositories.Interfaces;

namespace SaborExpress.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly AppDbContext _Context;
        public SnackRepository(AppDbContext context)
        {
            _Context = context;
        }

        public IEnumerable<Snack> Snacks =>_Context.Snacks.Include(c => c.Category);

        public IEnumerable<Snack> FavoriteSnack => _Context.Snacks.Where(l => l.IsFavoriteSnack).Include(c => c.Category);

        public Snack GetSnackById(int snackId)
        {
            return _Context.Snacks.FirstOrDefault(l => l.SnackId == snackId);
        }
    }
}
// Injetamos as dependências do contexto através do construtor
//Acessamos a tabela Snacks e incluimos sua categoria no resultado da consulta
// Acessamos a tabela FavoriteSnack onde o lanche for o preferido e inclui a categoria na consulta
// Retornamos o lanche com o Id consultado

