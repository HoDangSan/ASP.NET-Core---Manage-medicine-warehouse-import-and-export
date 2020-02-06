using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.UnitOfWork;

namespace MWIE.Service.ReceiptLiquidationService
{
    public class ReceiptLiquidationService : IReceiptLiquidationService
    {
        private IUnitOfWork _unitOfWork;
        private MWIEDbContext _context;
        private readonly ILogger<ReceiptLiquidationService> _logger;

        public ReceiptLiquidationService(IUnitOfWork unitOfWork, MWIEDbContext context, ILogger<ReceiptLiquidationService> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }

        public ReceiptLiquidation GetById(int id)
        {
            try
            {
                return _unitOfWork.ReceiptLiquidationRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public IEnumerable<ReceiptLiquidation> GetAll()
        {
            try
            {
                return _unitOfWork.ReceiptLiquidationRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public void Add(ReceiptLiquidation receiptLiquidation)
        {
            try
            {
                _unitOfWork.ReceiptLiquidationRepository.Add(receiptLiquidation);
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
                _unitOfWork.ReceiptLiquidationRepository.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "delete fail");
                throw;
            }
        }

        public void Update(ReceiptLiquidation receiptLiquidation)
        {
            try
            {
                _unitOfWork.ReceiptLiquidationRepository.Update(receiptLiquidation);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "update fail");
                throw;
            }
        }

        public void Save()
        {
            _unitOfWork.ReceiptLiquidationRepository.Save();
        }
    }
}