using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.UnitOfWork;

namespace MWIE.Service.DetailReceiptLiquidationService
{
    public class DetailReceiptLiquidationService : IDetailReceiptLiquidationService
    {
        private IUnitOfWork _unitOfWork;
        private MWIEDbContext _context;
        private readonly ILogger<DetailReceiptLiquidationService> _logger;

        public DetailReceiptLiquidationService(IUnitOfWork unitOfWork, MWIEDbContext context, ILogger<DetailReceiptLiquidationService> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }

        public DetailReceiptLiquidation GetById(int id)
        {
            try
            {
                return _unitOfWork.DetailReceiptLiquidationRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public IEnumerable<DetailReceiptLiquidation> GetAll()
        {
            try
            {
                return _unitOfWork.DetailReceiptLiquidationRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public void Add(DetailReceiptLiquidation detailReceiptLiquidation)
        {
            try
            {
                _unitOfWork.DetailReceiptLiquidationRepository.Add(detailReceiptLiquidation);
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
                _unitOfWork.DetailReceiptLiquidationRepository.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "delete fail");
                throw;
            }
        }

        public void Update(DetailReceiptLiquidation detailReceiptLiquidation)
        {
            try
            {
                _unitOfWork.DetailReceiptLiquidationRepository.Update(detailReceiptLiquidation);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "update fail");
                throw;
            }
        }

        public void Save()
        {
            _unitOfWork.DetailReceiptLiquidationRepository.Save();
        }
    }
}