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

        public async Task<List<Comment>> GetAll()
        {
            //Crear la Consulta LINQ
            var comments = await _context.Comments.ToListAsync();

            return comments;

        }

        public async Task<CommentDto> AddComment(CommentAddRequestDto newComment)
        {
            CommentAddRequestDto commentAddRequestDto = newComment;
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

        public async Task<Comment> GetCommentById(int CommentId)
        {
            Comment? comment = _context.Comments.Where(x => x.Id == CommentId).FirstOrDefault();

            CommentDto commentDto = new CommentDto();

            commentDto.Id = comment.Id;
            commentDto.Name = comment.Name;
            commentDto.Date = comment.Date;
            commentDto.ActivityId = comment.ActivityId;
            commentDto.Detail = comment.Detail;
            comment.Qualification = comment.Qualification;

            return comment;
        }

        public async Task<Comment> DeleteCommentById(int commentId)
        {
            Comment? comment = _context.Comments.Where(x => x.Id == commentId).FirstOrDefault();
            _context.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public  async Task<CommentDto> ModifyCommentById(CommentModifyRequestDto commentModifyRequestDto)
        {
            Comment? commentResult = _context.Comments.Where(x => x.Id == commentModifyRequestDto.Id).FirstOrDefault();


            commentResult.Name = commentModifyRequestDto.Name;
            commentResult.Detail = commentModifyRequestDto.Detail;
            commentResult.Qualification = commentModifyRequestDto.Qualification;
          


            _context.Comments.Update(commentResult);
            _context.SaveChanges();

            CommentDto commentDto = new CommentDto();
            commentDto.Id = commentModifyRequestDto.Id;
            commentDto.Name = commentModifyRequestDto.Name;
            commentDto.Detail = commentModifyRequestDto.Detail;
            commentDto.Qualification = commentModifyRequestDto.Qualification;
  

            return commentDto;
        }
    }
}
