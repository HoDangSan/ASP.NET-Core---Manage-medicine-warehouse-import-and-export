using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.UnitOfWork;

namespace MWIE.Service.DrugService
{
    public class DrugService : IDrugService
    {
        private IUnitOfWork _unitOfWork;
        private MWIEDbContext _context;
        private readonly ILogger<DrugService> _logger;

        public DrugService(IUnitOfWork unitOfWork, MWIEDbContext context, ILogger<DrugService> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }

        public Drug GetById(int id)
        {
            try
            {
                return _unitOfWork.DrugRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public IEnumerable<Drug> GetAll()
        {
            try
            {
                return _unitOfWork.DrugRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public void Add(Drug drug)
        {
            try
            {
                _unitOfWork.DrugRepository.Add(drug);
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
                _unitOfWork.DrugRepository.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "delete fail");
                throw;
            }
        }

        public void Update(Drug drug)
        {
            try
            {
                _unitOfWork.DrugRepository.Update(drug);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "update fail");
                throw;
            }
        }

        public void Save()
        {
            _unitOfWork.DrugRepository.Save();
        }
    }
}