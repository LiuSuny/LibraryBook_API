using AutoMapper;
using LibraryBook_TaskAPI.CustomizeValidation;
using LibraryBook_TaskAPI.DTO;
using LibraryBook_TaskAPI.Interface;
using LibraryBook_TaskAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace LibraryBook_TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        //initialize  IMediator
       // private readonly IMediator _mediator;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        //injecting for use inside our ctor
        public AuthorController( /*IMediator mediator,*/ IAuthorRepository authorRepository, IMapper mapper)
        {
            //_mediator = mediator;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            //var author = await _authorRepository.GetAllAuthorsAsync();;
            //return Ok(author);

            var author = await _authorRepository.GetAllAuthorsAsync();
            var bookDto = _mapper.Map<List<BookDTO>>(author);
            return Ok(author);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<Book>> GetBookbyId([FromRoute] Guid id)
        {
            //var book = await _mediator.Send(_bookRepository.GetByIdAsync(id));
            //  return Ok(book);

            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }
            // Map/Convert  Domain Model to 
            // 
            var authorDto = _mapper.Map<AuthorDTO>(author);

            // Return DTO back to client
            return Ok(authorDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<Book>> CreateBook([FromBody] AuthorDTO authorDTO)
        {
            if (ModelState.IsValid)
            {
                var authorModel = _mapper.Map<Author>(authorDTO);
                authorModel = await _authorRepository.CreateAsync(authorModel);

                var authorDto = _mapper.Map<Author>(authorModel);

                return CreatedAtAction(nameof(GetBookbyId), new { id = authorDto.Id }, authorDTO);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] AuthorDTO authorDTO)
        {
            if (ModelState.IsValid)
            {
                // Map or Convert DTO to Domain Model
                var authorModel = _mapper.Map<Author>(authorDTO);

                // Check if author exists
                authorModel = await _authorRepository.UpdateAsync(id, authorModel);

                if (authorModel == null)
                {
                    return NotFound();
                }

                // Convert Domain Model to DTO
                return Ok(_mapper.Map<Author>(authorModel));
            }

            return BadRequest();
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var authorModel = await _authorRepository.DeleteAsync(id);
            if (authorModel == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<AuthorDTO>(authorModel));
        }
    }
}
