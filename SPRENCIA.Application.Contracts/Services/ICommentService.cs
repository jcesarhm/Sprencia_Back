using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface ICommentService
    {
        Task<List<Comment>>GetAllComments();

        Task<CommentDto> AddNewComment(CommentAddRequestDto newComment);
    }
}
