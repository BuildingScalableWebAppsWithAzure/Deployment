namespace Deployment.Persistence
{
    using System.ComponentModel.DataAnnotations;

    public partial class ReceivedMessage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Message { get; set; }
    }
}
