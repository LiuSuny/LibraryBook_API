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
    public class BooksController : ControllerBase
    {
        //initialize  IMediator
       // private readonly IMediator _mediator;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        //injecting for use inside our ctor
        public BooksController( /*IMediator mediator,*/ IBookRepository bookRepository, IMapper mapper)
        {
            //_mediator = mediator;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            //var book = await _mediator.Send(_bookRepository.GetAllBooksAsync());
            //return Ok(book);

            var book = await _bookRepository.GetAllBooksAsync();
            var bookDto = _mapper.Map<List<BookDTO>>(book);
            return Ok(bookDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<Book>> GetBookbyId([FromRoute] Guid id)
        {
            //var book = await _mediator.Send(_bookRepository.GetByIdAsync(id));
            //  return Ok(book);

            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            // Map/Convert  Domain Model to 
            // 
            var bookDto = _mapper.Map<BookDTO>(book);

            // Return DTO back to client
            return Ok(bookDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult> CreateBook([FromBody] BookDTO createBookDTO)
        {
            if (ModelState.IsValid)
            {
                var bookModel = _mapper.Map<Book>(createBookDTO);
                bookModel = await _bookRepository.CreateAsync(bookModel);

                var bookDto = _mapper.Map<BookDTO>(bookModel);

                return CreatedAtAction(nameof(GetBookbyId), new { id = createBookDTO.Id }, createBookDTO);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] BookDTO createBookDTO)
        {
            if (ModelState.IsValid)
            {
                // Map or Convert DTO to Domain Model
                var bookModel = _mapper.Map<Book>(createBookDTO);                

                // Check if region exists
                bookModel = await _bookRepository.UpdateAsync(id, bookModel);

                if (bookModel == null)
                {
                    return NotFound();
                }

                // Convert Domain Model to DTO
                return Ok(_mapper.Map<Book>(bookModel));
            }

            return BadRequest();
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var bookModel = await _bookRepository.DeleteAsync(id);
            if (bookModel == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<BookDTO>(bookModel));
        }
    }
}
