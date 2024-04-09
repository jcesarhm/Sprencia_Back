using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAll();

        Task<CommentDto> AddComment(CommentAddRequestDto commentAddRequestDto);
    }
}
