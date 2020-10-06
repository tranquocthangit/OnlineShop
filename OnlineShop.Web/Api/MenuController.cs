using OnlineShop.Model.Models;
using OnlineShop.Service;
using OnlineShop.Web.Infrastructure.Core;
using OnlineShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShop.Web.Api
{
    [RoutePrefix("api/menu")]
    public class MenuController : ApiControllerBase
    {
        #region Initialize
        IMenuService _menuService;

        public MenuController(IErrorService errorService, IMenuService menuService)
            : base(errorService)
        {
            this._menuService = menuService;
        }
        #endregion

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _menuService.GetAllByMenuGroupId(1);

                var listMenuVm = AutoMapper.Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(model);

                HttpResponseMessage responseData = request.CreateResponse(HttpStatusCode.OK, listMenuVm);
                return responseData;
            });
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}