using EstudoRest.Model;
using EstudoRest.Model.Context;
using EstudoRest.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EstudoRest.Repository
{
    public class CadGruRepository : ICadGruRepository
    {
        private readonly MySQLContext _context;

        public CadGruRepository(MySQLContext context)
        {
            _context = context;
        }

        public CadGru Create(CadGru cadGru)
        {
            try
            {
                _context.Add(cadGru);
                _context.SaveChanges();

                return cadGru;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public CadGru Update(CadGru cadGru)
        {
            if (!Exists(cadGru.CodGru)) return null;

            var result = _context.CadGrus.SingleOrDefault(p => p.CodGru.Equals(cadGru.CodGru));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(cadGru);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return cadGru;
        }

        public void Delete(string codGru)
        {
            var result = _context.CadGrus.SingleOrDefault(p => p.CodGru.Equals(codGru));
            if (result != null)
            {
                try
                {
                    _context.CadGrus.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(string codGru)
        {
            return _context.CadGrus.Any(p => p.CodGru.Equals(codGru));
        }

        public List<CadGru> FindByNomGru(string nomGru)
        {
            if (!string.IsNullOrWhiteSpace(nomGru))
            {
                return _context.CadGrus.Where(
                    p => p.NomGru.Contains(nomGru)).ToList();
            }

            return null;
            
        }

        public List<CadGru> FindByCodGru(string codGru)
        {
            if (!string.IsNullOrWhiteSpace(codGru))
            {
                return _context.CadGrus.Where(p => p.CodGru.Contains(codGru)).ToList();
            }

            return null;

        }

        public int GetCount(string query)
        {
            var result = "";

            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    result = command.ExecuteScalar().ToString();
                }
            }

            return int.Parse(result);
        }
    }
}
