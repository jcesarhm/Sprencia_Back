using Microsoft.AspNetCore.Mvc;
using SPRENCIA.Application.Contracts.Services;
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
        
        [HttpPost]
        [Route("AddComment")]
        //REcuerda poner el ActionResult
        public async Task<ActionResult> AddNewComment([FromBody] CommentAddRequestDto comment)
        {
            var commentAdded = await _commentService.AddNewComment(comment);

            if(commentAdded == null) 

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

      
    }
}
