using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.UnitOfWork;

namespace MWIE.Service.UserService
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private MWIEDbContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork, MWIEDbContext context, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }

        public UserProfile GetById(int? id)
        {
            try
            {
                return _unitOfWork.UserReponsitory.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public IEnumerable<UserProfile> GetAll()
        {
            try
            {
                return _unitOfWork.UserReponsitory.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public void Add(UserProfile user)
        {
            try
            {
                _unitOfWork.UserReponsitory.Add(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "add Fail");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _unitOfWork.UserReponsitory.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "delete fail");
                throw;
            }
        }

        public void Update(UserProfile user)
        {
            try
            {
                _unitOfWork.UserReponsitory.Update(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "update fail");
                throw;
            }
        }

        public void Save()
        {
            _unitOfWork.UserReponsitory.Save();
        }
    }
}