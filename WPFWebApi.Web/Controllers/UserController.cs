using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WPFWebApi.Data.Model;
using WPFWebApi.Data.Repositories.Interfaces;



namespace WPFWebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _unitOfWork.UserRepository.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            _unitOfWork.UserRepository.Add(value);
            _unitOfWork.SaveChanges();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var myUser =  await _unitOfWork.UserRepository.GetFirstOrDefault(u => u.Id == id);
            if (myUser != null) 
            {
                await _unitOfWork.UserRepository.Delete(myUser);
                _unitOfWork.SaveChanges();
            }
            
        }
    }
}
