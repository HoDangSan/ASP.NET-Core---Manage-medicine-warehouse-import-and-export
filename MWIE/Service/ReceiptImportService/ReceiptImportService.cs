using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.UnitOfWork;

namespace MWIE.Service.ReceiptImportService
{
    public class ReceiptImportService : IReceiptImportService
    {
        private IUnitOfWork _unitOfWork;
        private MWIEDbContext _context;
        private readonly ILogger<ReceiptImportService> _logger;

        public ReceiptImportService(IUnitOfWork unitOfWork, MWIEDbContext context, ILogger<ReceiptImportService> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }

        public ReceiptImport GetById(int id)
        {
            try
            {
                return _unitOfWork.ReceiptImportRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public IEnumerable<ReceiptImport> GetAll()
        {
            try
            {
                return _unitOfWork.ReceiptImportRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public void Add(ReceiptImport receiptImport)
        {
            try
            {
                _unitOfWork.ReceiptImportRepository.Add(receiptImport);
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
                _unitOfWork.ReceiptImportRepository.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "delete fail");
                throw;
            }
        }

        public void Update(ReceiptImport receiptImport)
        {
            try
            {
                _unitOfWork.ReceiptImportRepository.Update(receiptImport);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "update fail");
                throw;
            }
        }

        public void Save()
        {
            _unitOfWork.ReceiptImportRepository.Save();
        }
    }
}