using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.UnitOfWork;

namespace MWIE.Service.DetailReceiptExportService
{
    public class DetailReceiptExportService : IDetailReceiptExportService
    {
        private IUnitOfWork _unitOfWork;
        private MWIEDbContext _context;
        private readonly ILogger<DetailReceiptExportService> _logger;

        public DetailReceiptExportService(IUnitOfWork unitOfWork, MWIEDbContext context, ILogger<DetailReceiptExportService> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }

        public DetailReceiptExport GetById(int id)
        {
            try
            {
                return _unitOfWork.DetailReceiptExportRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public IEnumerable<DetailReceiptExport> GetAll()
        {
            try
            {
                return _unitOfWork.DetailReceiptExportRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public void Add(DetailReceiptExport detailReceiptExport)
        {
            try
            {
                _unitOfWork.DetailReceiptExportRepository.Add(detailReceiptExport);
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
                _unitOfWork.DetailReceiptExportRepository.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "delete fail");
                throw;
            }
        }

        public void Update(DetailReceiptExport detailReceiptExport)
        {
            try
            {
                _unitOfWork.DetailReceiptExportRepository.Update(detailReceiptExport);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "update fail");
                throw;
            }
        }

        public void Save()
        {
            _unitOfWork.DetailReceiptExportRepository.Save();
        }
    }
}