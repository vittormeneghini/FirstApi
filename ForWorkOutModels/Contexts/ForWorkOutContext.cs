using ForWorkOutModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForWorkOutModels.Contexts
{
    public class ForWorkOutContext : DbContext
    {
        private string connectionString = "Server=31.220.57.45;Database=ordemservicodb;Uid=awesomedeveloper;Password=awesomedev@2000";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString);
        }        

        public DbSet<Pedido> Pedido {get;set;}
    }
}