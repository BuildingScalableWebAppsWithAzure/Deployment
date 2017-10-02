namespace Deployment.Persistence
{
    using System.Data.Entity;

    public partial class DeploymentContext : DbContext
    {
        public DeploymentContext()
            : base("name=DeploymentContext")
        {
        }

        public virtual DbSet<ReceivedMessage> ReceivedMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
