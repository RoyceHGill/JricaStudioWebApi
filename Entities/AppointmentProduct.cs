namespace JricaStudioWebApi.Entities
{
    public class AppointmentProduct
    {
        public Guid Id { get; set; }

        public Guid AppointmentId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public Appointment Appointment { get; set; }
        public Product Product { get; set; }
    }
}
