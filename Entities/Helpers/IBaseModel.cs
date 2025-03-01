
namespace JricaStudioWebAPI.Entities.Helpers
{
    public interface IBaseModel
    {
        DateTime Created { get; set; }
        Guid Id { get; set; }
        DateTime? Updated { get; set; }
    }
}