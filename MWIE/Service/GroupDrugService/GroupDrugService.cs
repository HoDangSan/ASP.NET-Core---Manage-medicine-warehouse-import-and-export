using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.UnitOfWork;

namespace MWIE.Service.GroupDrugService
{
    public class GroupDrugService : IGroupDrugService
    {
        private readonly IUnitOfWork _unitOfWork;
        private MWIEDbContext _context;
        private readonly ILogger<GroupDrugService> _logger;
        
        public GroupDrugService(IUnitOfWork unitOfWork, MWIEDbContext context, ILogger<GroupDrugService> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }

        public GroupDrug GetById(int id)
        {
            try
            {
                return _unitOfWork.GroupDrugRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public IEnumerable<GroupDrug> GetAll()
        {
            try
            {
                return _unitOfWork.GroupDrugRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public void Add(GroupDrug groupDrug)
        {
            try
            {
                _unitOfWork.GroupDrugRepository.Add(groupDrug);
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
                _unitOfWork.GroupDrugRepository.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "delete fail");
                throw;
            }
        }

        public void Update(GroupDrug groupDrug)
        {
            try
            {
                _unitOfWork.GroupDrugRepository.Update(groupDrug);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "update fail");
                throw;
            }
        }

        public void Save()
        {
            _unitOfWork.GroupDrugRepository.Save();
        }
    }
}