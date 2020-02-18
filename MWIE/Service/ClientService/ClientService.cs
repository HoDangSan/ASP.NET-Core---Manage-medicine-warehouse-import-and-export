using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.UnitOfWork;

namespace MWIE.Service.ClientService
{
    public class ClientService
    : IClientService
    {
        private IUnitOfWork _unitOfWork;
        private MWIEDbContext _context;
        private readonly ILogger<ClientService> _logger;

        public ClientService(IUnitOfWork unitOfWork, MWIEDbContext context, ILogger<ClientService> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }

        public Client GetById(int? id)
        {
            try
            {
                return _unitOfWork.ClientRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public IEnumerable<Client> GetAll()
        {
            try
            {
                return _unitOfWork.ClientRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "Get Fail");
                throw;
            }
        }

        public void Add(Client client)
        {
            try
            {
                _unitOfWork.ClientRepository.Add(client);
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
                _unitOfWork.ClientRepository.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "delete fail");
                throw;
            }
        }

        public void Update(Client client)
        {
            try
            {
                _unitOfWork.ClientRepository.Update(client);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "update fail");
                throw;
            }
        }

        public void Save()
        {
            _unitOfWork.ClientRepository.Save();
        }
    }
}
