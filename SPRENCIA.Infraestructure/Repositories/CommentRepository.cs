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
            comment.ActivityId = commentAddRequestDto.ActivityId;
            comment.Qualification = commentAddRequestDto.Qualification;
            comment.Name = commentAddRequestDto.Name;
            comment.Detail = commentAddRequestDto.Detail;
            comment.Date = commentAddRequestDto.Date;
            var commentAdded = _context.Comments.Add(comment);
            _context.SaveChanges();

            CommentDto commentDto = new CommentDto();   
            commentDto.Id = commentAdded.Entity.Id;
            commentDto.Name = commentAdded.Entity.Name;
            commentDto.ActivityId = commentAdded.Entity.ActivityId;
            commentDto.Detail = commentAdded.Entity.Detail;
            commentDto.Qualification = commentAdded.Entity.Qualification;
            commentDto.Date = commentAdded.Entity.Date;
            return commentDto;


        }
       

        public async Task<CommentDto> GetCommentById(int commentId)
        {
            Comment? comment = _context.Comments.Where(x => x.Id == commentId).FirstOrDefault();

            CommentDto commentDto = new CommentDto();
            if(comment == null) { return null; }

            commentDto.Id = comment.Id;
            commentDto.Name = comment.Name;
            commentDto.ActivityId = comment.ActivityId;
            commentDto.Detail = comment.Detail;
            comment.Qualification = comment.Qualification;
            comment.Date = comment.Date;
            return commentDto;
        }

        public async Task DeleteCommentById(int? commentId)
        {
            Comment? comment = _context.Comments.Where(x => x.Id == commentId).FirstOrDefault();
            _context.Remove(comment);
            await _context.SaveChangesAsync();

        }

        public  async Task<CommentDto> ModifyCommentById(CommentModifyRequestDto commentModifyRequestDto)
        {
            Comment? commentResult = _context.Comments.Where(x => x.Id == commentModifyRequestDto.Id).FirstOrDefault();

            commentResult.Date = commentModifyRequestDto.Date;
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
            commentDto.Date = commentModifyRequestDto.Date;

            return commentDto;
        }
    }
}
