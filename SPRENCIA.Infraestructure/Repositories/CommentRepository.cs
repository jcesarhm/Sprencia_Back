using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Repositories
{
    public class CommentRepository : ICommentRepository
    { 
        private readonly SprenciaDbContext _context;

        public CommentRepository(SprenciaDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<CommentDto> AddComment(CommentAddRequestDto commentAddRequestDto)
        {
          Comment comment = new Comment();
            comment.Date = commentAddRequestDto.Date;
            comment.ActivityId = commentAddRequestDto.ActivityId;
            comment.Qualification = commentAddRequestDto.Qualification;
            comment.Name = commentAddRequestDto.Name;
            comment.Detail = commentAddRequestDto.Detail;

            var commentAdded = _context.Comments.Add(comment);
            _context.SaveChanges();

            CommentDto commentDto = new CommentDto();   
            commentDto.Id = commentAdded.Entity.Id;
            commentDto.Name = commentAdded.Entity.Name;
            commentDto.Date = commentAdded.Entity.Date;
            commentDto.ActivityId = commentAdded.Entity.ActivityId;
            commentDto.Detail = commentAdded.Entity.Detail;
            commentDto.Qualification = commentAdded.Entity.Qualification;

            return commentDto;


        }

        public async Task<List<Comment>> GetAll()
        {
            var comments = await _context.Comments.ToListAsync();

            return comments;
        }
    }
}
