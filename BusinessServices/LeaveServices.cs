using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices
{
    public class LeaveServices : ILeaveServices
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public LeaveServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Fetches product details by id
        /// </summary>
        /// <param name="leaveId"></param>
        /// <returns></returns>
        LeaveMasterEntity ILeaveServices.GetLeaveById(int leaveId)
        {
            //throw new NotImplementedException();
            var leave = _unitOfWork.LeaveMasterRepository.GetByID(leaveId);
            if (leave != null)
            {
                Mapper.CreateMap<Leave_Master, LeaveMasterEntity>();
                var leaveModel = Mapper.Map<Leave_Master, LeaveMasterEntity>(leave);
                return leaveModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the products.
        /// </summary>
        /// <returns></returns>
        IEnumerable<LeaveMasterEntity> ILeaveServices.GetAllLeaves()
        {
            //throw new NotImplementedException();
            var leaves = _unitOfWork.LeaveMasterRepository.GetAll().ToList();
            if (leaves.Any())
            {
                Mapper.CreateMap<Leave_Master, LeaveMasterEntity>();
                var leavesModel = Mapper.Map<List<Leave_Master>, List<LeaveMasterEntity>>(leaves);
                return leavesModel;
            }
            return null;
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="leaveId"></param>
        /// <param name="leavemasterEntity">todo: describe leavemasterEntity parameter on UpdateProduct</param>
        /// <returns></returns>
        bool ILeaveServices.UpdateLeave(int leaveId, LeaveMasterEntity leaveEntity)
        {
            //throw new NotImplementedException();
            var success = false;
            if (leaveEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var leave_Master = _unitOfWork.LeaveMasterRepository.GetByID(leaveId);
                    if (leave_Master != null)
                    {
                        leave_Master.LeaveDetails = leaveEntity.LeaveDetails;
                        _unitOfWork.LeaveMasterRepository.Update(leave_Master);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;

        }

        /// <summary>
        /// Deletes a particular product
        /// </summary>
        /// <param name="leaveId"></param>
        /// <returns></returns>
        bool ILeaveServices.DeleteLeave(int leaveId)
        {
            //throw new NotImplementedException();
            var success = false;
            if (leaveId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var leave_Master = _unitOfWork.LeaveMasterRepository.GetByID(leaveId);
                    if (leave_Master != null)
                    {

                        _unitOfWork.LeaveMasterRepository.Delete(leave_Master);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="leavemasterEntity"></param>
        /// <returns></returns>
        int ILeaveServices.CreateLeave(LeaveMasterEntity leaveMasterEntity)
        {
            //throw new NotImplementedException();
            using (var scope = new TransactionScope())
            {
                var leave_Master = new Leave_Master
                {
                    LeaveDetails = leaveMasterEntity.LeaveDetails
                };

                _unitOfWork.LeaveMasterRepository.Insert(leave_Master);
                _unitOfWork.Save();
                scope.Complete();
                return leave_Master.LeaveId;
            };
        }
    }
}
