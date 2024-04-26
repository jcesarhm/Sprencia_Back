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

        public async Task<List<Comment>> GetAllComments()
        {
            var AllComments = await _commentRepository.GetAll();

            return AllComments;
        }

        public async Task<CommentDto> AddNewComment(CommentAddRequestDto newComment)
        {
            CommentDto? commentAdded = null; 

           if (newComment != null)
            {
                commentAdded = await  _commentRepository.AddComment(newComment);
            }

            return commentAdded;
        }

        public async Task<CommentDto> GetCommentById(int commentId)
        {
            CommentDto comment = null;
            if (commentId != null)
            {
                comment = await _commentRepository.GetCommentById(commentId);
            }

            return comment;
        }

        public async Task DeleteCommentById(int? commentId)
        {
            
            if (commentId != null)
            {
           await _commentRepository.DeleteCommentById(commentId);
            }
        }

        public  async Task<CommentDto> ModifyCommentById(CommentModifyRequestDto commentModifyRequestDto)
        {
            CommentDto? commentModify = null;
            if (commentModifyRequestDto != null) 
            { 
                commentModify = await _commentRepository.ModifyCommentById(commentModifyRequestDto);
            }

            return commentModify;
        }
    }
}

