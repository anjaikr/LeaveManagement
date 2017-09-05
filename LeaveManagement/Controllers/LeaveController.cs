using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using BusinessEntities;
using BusinessServices;
using LeaveManagement.ActionFilters;
using LeaveManagement.ErrorHelper;

namespace LeaveManagement.Controllers
{
    [AuthorizationRequired]
    [AttributeRouting.RoutePrefix("v1/Leaves/Leave")]
    public class LeaveController : ApiController
    {
        #region Private variable.

        private readonly ILeaveServices _leaveServices;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize leave service instance
        /// </summary>
        public LeaveController(ILeaveServices leaveServices)
        {
            _leaveServices = leaveServices;
        }

        #endregion

        // GET api/leave
        [GET("allleaves")]
        [GET("all")]
        public HttpResponseMessage Get()
        {
            var leaves = _leaveServices.GetAllLeaves();
            var productEntities = leaves as List<LeaveMasterEntity> ?? leaves.ToList();
            if (productEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, productEntities);
            throw new ApiDataException(1000, "Leaves not found", HttpStatusCode.NotFound);
        }

        // GET api/leave/5
        [GET("leaveid/{id?}")]
        [GET("particularleave/{id?}")]
        [GET("myleave/{id:range(1, 3)}")]
        public HttpResponseMessage Get(int id)
        {
            if (id > 0)
            {
                var product = _leaveServices.GetLeaveById(id);
                if (product != null)
                    return Request.CreateResponse(HttpStatusCode.OK, product);

                throw new ApiDataException(1001, "No Leave found for this id.", HttpStatusCode.NotFound);
            }
            throw new ApiException() { ErrorCode = (int)HttpStatusCode.BadRequest, ErrorDescription = "Bad Request..." };
        }

        // POST api/leave
        [POST("Create")]
        [POST("Register")]
        public int Post([FromBody] LeaveMasterEntity leaveMasterEntity)
        {
            return _leaveServices.CreateLeave(leaveMasterEntity);
        }

        // PUT api/product/5
        [PUT("Update/leaveid/{id}")]
        [PUT("Modify/leaveid/{id}")]
        public bool Put(int id, [FromBody] LeaveMasterEntity leaveMasterEntity)
        {
            return id > 0 && _leaveServices.UpdateLeave(id, leaveMasterEntity);
        }

        // DELETE api/product/5
        [DELETE("remove/leaveid/{id}")]
        [DELETE("clear/leaveid/{id}")]
        [PUT("delete/leaveid/{id}")]
        public bool Delete(int id)
        {
            if (id > 0)
            {
                var isSuccess = _leaveServices.DeleteLeave(id);
                if (isSuccess)
                {
                    return true;
                }
                throw new ApiDataException(1002, "Product is already deleted or not exist in system.", HttpStatusCode.NoContent);
            }
            throw new ApiException() { ErrorCode = (int)HttpStatusCode.BadRequest, ErrorDescription = "Bad Request..." };
        }

    }
}
