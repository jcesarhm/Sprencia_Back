using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;

namespace SPRENCIA.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository) 
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            var AllComments = await _commentRepository.GetAll();

            return AllComments;
        }
    }
}

