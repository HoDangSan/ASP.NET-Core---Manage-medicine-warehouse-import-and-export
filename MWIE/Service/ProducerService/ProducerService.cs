using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.UnitOfWork;

namespace MWIE.Service.ProducerService
{
    public class ProducerService : IProducerService
    {
        private IUnitOfWork _unitOfWork;
        private MWIEDbContext _context;
        private readonly ILogger<ProducerService> _logger;
        
        public ProducerService(IUnitOfWork unitOfWork, MWIEDbContext context, ILogger<ProducerService> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }

        public Producer GetById(int id)
        {
            try
            {
                return _unitOfWork.ProducerRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public IEnumerable<Producer> GetAll()
        {
            try
            {
                return _unitOfWork.ProducerRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public void Add(Producer producer)
        {
            try
            {
                _unitOfWork.ProducerRepository.Add(producer);
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
                _unitOfWork.ProducerRepository.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "delete fail");
                throw;
            }
        }

        public void Update(Producer producer)
        {
            try
            {
                _unitOfWork.ProducerRepository.Update(producer);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "update fail");
                throw;
            }
        }

        public void Save()
        {
            _unitOfWork.ProducerRepository.Save();
        }
    }
}