using SPRENCIA.Domain.Models;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface ICommentService
    {
        Task<List<Comment>>GetAllComments();
    }
}
