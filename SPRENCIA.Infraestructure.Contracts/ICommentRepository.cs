using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAll();

        Task<CommentDto> AddComment(CommentAddRequestDto newComment);
    }
}
