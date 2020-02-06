using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.UnitOfWork;

namespace MWIE.Service.DetailReceiptImportService
{
    public class DetailReceiptImportService : IDetailReceiptImportService
    {
        private IUnitOfWork _unitOfWork;
        private MWIEDbContext _context;
        private readonly ILogger<DetailReceiptImportService> _logger;

        public DetailReceiptImportService(IUnitOfWork unitOfWork, MWIEDbContext context, ILogger<DetailReceiptImportService> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }

        public DetailReceiptImport GetById(int id)
        {
            try
            {
                return _unitOfWork.DetailReceiptImportRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public IEnumerable<DetailReceiptImport> GetAll()
        {
            try
            {
                return _unitOfWork.DetailReceiptImportRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public void Add(DetailReceiptImport detailReceiptImport)
        {
            try
            {
                _unitOfWork.DetailReceiptImportRepository.Add(detailReceiptImport);
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
                _unitOfWork.DetailReceiptImportRepository.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "delete fail");
                throw;
            }
        }

        public void Update(DetailReceiptImport detailReceiptImport)
        {
            try
            {
                _unitOfWork.DetailReceiptImportRepository.Update(detailReceiptImport);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "update fail");
                throw;
            }
        }

        public void Save()
        {
            _unitOfWork.DetailReceiptImportRepository.Save();
        }
    }
}