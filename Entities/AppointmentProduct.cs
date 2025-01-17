namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// Represents a product associated with an appointment, including its quantity and references to the related appointment and product.
    /// </summary>
    public class AppointmentProduct
    {
        /// <summary>
        /// The unique identifier for the appointment product.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The unique identifier of the associated appointment.
        /// </summary>
        public Guid AppointmentId { get; set; }

        /// <summary>
        /// The unique identifier of the associated product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The quantity of the product associated with the appointment.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The appointment associated with this product.
        /// </summary>
        public Appointment Appointment { get; set; }

        /// <summary>
        /// A product associated with this appointment.
        /// </summary>
        public Product Product { get; set; }
    }
}
