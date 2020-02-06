using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.UnitOfWork;

namespace MWIE.Service.ReceiptExportService
{
    public class ReceiptExportService : IReceiptExportService
    {
        private IUnitOfWork _unitOfWork;
        private MWIEDbContext _context;
        private readonly ILogger<ReceiptExportService> _logger;

        public ReceiptExportService(IUnitOfWork unitOfWork, MWIEDbContext context, ILogger<ReceiptExportService> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }

        public ReceiptExport GetById(int id)
        {
            try
            {
                return _unitOfWork.ReceiptExportRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public IEnumerable<ReceiptExport> GetAll()
        {
            try
            {
                return _unitOfWork.ReceiptExportRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public void Add(ReceiptExport receiptExport)
        {
            try
            {
                _unitOfWork.ReceiptExportRepository.Add(receiptExport);
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
                _unitOfWork.ReceiptExportRepository.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "delete fail");
                throw;
            }
        }

        public void Update(ReceiptExport receiptExport)
        {
            try
            {
                _unitOfWork.ReceiptExportRepository.Update(receiptExport);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "update fail");
                throw;
            }
        }

        public void Save()
        {
            _unitOfWork.ReceiptExportRepository.Save();
        }
    }
}