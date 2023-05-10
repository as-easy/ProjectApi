using Microsoft.AspNetCore.Mvc;
using ProjectApiApp.Api;
using ProjectApiApp.EFCore;
using ProjectApiApp.Model;

namespace ProjectApiApp.Controllers
{
    [ApiController]
    public class ProjectApiController : ControllerBase
    {
        private readonly DbHelper _db;
        public ProjectApiController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }
        // GET: api/ProjectApi/GetItems
        [HttpGet]
        [Route("api/[controller]/getItems")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<ItemModel> data = _db.GetItems();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/ProjectApi>/<id>
        [HttpGet]
        [Route("api/[controller]/getItemById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                ItemModel data = _db.GetItemById(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/ProjectApi/saveItem
        [HttpPost]
        [Route("api/[controller]/saveItem")]
        public IActionResult Post([FromBody] ItemModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveItem(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/ProjectApi/updateItem
        [HttpPut]
        [Route("api/[controller]/updateItem")]
        public IActionResult Put([FromBody] ItemModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateItem(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/ProjectApi/deleteItem/<id>
        [HttpDelete]
        [Route("api/[controller]/deleteItem/{id}")]
        public IActionResult DeleteItem(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteItem(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/ProjectApi/saveProject
        [HttpPost]
        [Route("api/[controller]/saveProject")]
        public IActionResult Post([FromBody] ProjectModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveProject(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/ProjectApi/updateProject
        [HttpPut]
        [Route("api/[controller]/updateProject")]
        public IActionResult Put([FromBody] ProjectModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateProject(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/ProjectApi/deleteProject/<id>
        [HttpDelete]
        [Route("api/[controller]/deleteProject/{id}")]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteProject(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}

