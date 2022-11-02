using DRMusicRest.DBContext;
using DRMusicRest.Managers;
using DRMusicRest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DRMusicRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly RecordsManager _manager = new RecordsManager();

        //public RecordsController(RecordsContext context)
        //{
        //    _manager = new RecordsManagerDB context;
        //}

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IEnumerable<Record> Get([FromQuery] string ?title)
        {
            return _manager.GetAll(title);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("{id}")]
        public ActionResult<Record> Get(int id)
        {
            Record record = _manager.GetById(id);
            if (record == null) return null;
            return record;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [HttpPost]
        public Record Post([FromBody] Record value)
        {
            return _manager.Add(value);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("id")]
        public ActionResult<Record> Put(int id, [FromBody] Record value)
        {
            Record record = _manager.Update(id, value);
            if (record == null) return NotFound("There is not record with given id!");
            return Ok(value);
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("id")]
        public ActionResult<Record> Delete(int id)
        {
            Record record = _manager.Delete(id);
            if (record == null) return NotFound("there is no record with given id!");
            return Ok(record);

        }
        
    }
}
