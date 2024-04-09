using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository) 
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentDto> AddNewComment(CommentAddRequestDto commentAddRequestDto)
        {
            CommentDto commentAdded = null; 

           if (commentAddRequestDto != null)
            {
                commentAdded = await  _commentRepository.AddComment(commentAddRequestDto);
            }

            return commentAdded;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            var AllComments = await _commentRepository.GetAll();

            return AllComments;
        }
    }
}

