using Microsoft.AspNetCore.Mvc;
using ToDoList.Aggregator.Interfaces;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Aggregator.Abstractions
{
    public class TodoListBaseController<TPostRequest, TPutRequest> : ControllerBase
        where TPostRequest: IModel
        where TPutRequest : IModel
        
        
    {
        private readonly IToDoListService<TPostRequest, TPutRequest> _service;
        private readonly string _uri;

        public TodoListBaseController(IToDoListService<TPostRequest, TPutRequest> service, string uri)
        {
            _service = service;
            _uri = uri;
        }
        
        [HttpPost/*, Authorize*/]
        public virtual async Task<IActionResult> PostAsync(TPostRequest request)
        {
            return Ok(await _service.PostAsync(request, _uri));
        }
        [HttpPut/*, Authorize*/]
        public virtual async Task<IActionResult> PutAsync(TPutRequest request)
        {
            return Ok(await _service.PutAsync(request, _uri));
        }

        [HttpGet("{id}")/*, Authorize*/]
        public virtual async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id, _uri));
        }
        [HttpDelete("{id}")/*, Authorize*/]
        public virtual async Task<IActionResult> DeleteByID(Guid id)
        {
            return Ok(await _service.DeleteByIdAsync(id, _uri));
        }
    }

}
