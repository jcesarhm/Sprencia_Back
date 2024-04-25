using Microsoft.AspNetCore.Mvc;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Application.Services;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA_API.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            //Hacemos la conexion entre Controller y Service
            _commentService = commentService;
        }
        [HttpGet]
        public async Task<List<Comment>> GetAll() 
        {
            // Controladores solamente tiene que llamar a servicios.
            // No debe de hacer ninguna operacion.
            var getAllComment = await _commentService.GetAllComments();

            return getAllComment;
        }
        
      

        [HttpGet("{commentId}")]
        public async Task<ActionResult> GetCommentById(int commentId)
        {
            var commentById =  _commentService.GetCommentById(commentId);
            return Ok(commentById);
        }

        [HttpPost]
        [Route("AddComment")]
        //REcuerda poner el ActionResult
        public async Task<ActionResult> AddNewComment([FromBody] CommentAddRequestDto comment)
        {
            var commentAdded = await _commentService.AddNewComment(comment);

            if (commentAdded == null)

            {

                //Aqui hay un error o el DTO esta vacio
                return BadRequest("la peticion es incorrecta");
            }
            else
            {
                //Aqui ha ido todo bien 
                return Ok(commentAdded);
            }

        }


        [HttpDelete("{commentId}")]

        public async Task<ActionResult> DeleteCommentById(int commentId)
        {
            Comment? comment = await _commentService.DeleteCommentById(commentId);

            if (comment == null)
            {
                return BadRequest(" la peticion es incorrecta");
            }

            return Ok(comment);

        }

        [HttpPut]
        [Route("ModifyComment")]

        public async Task<ActionResult> ModifyCommentById([FromBody] CommentModifyRequestDto commentModifyRequestDto)
        {
            CommentDto? commentModify = await _commentService.ModifyCommentById(commentModifyRequestDto);
            if (commentModify == null)
            {
                return BadRequest("la peticion es incorrecta");
            }

            return Ok(commentModify);
        }

    }
}
