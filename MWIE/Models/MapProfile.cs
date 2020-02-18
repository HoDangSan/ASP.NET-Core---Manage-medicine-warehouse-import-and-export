using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using MWIE.Models.Entity;
using MWIE.Models.ViewModel;
using MWIE.Service.GroupDrugService;

namespace MWIE.Models
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserProfile, UserProfileViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.Sex, opt => opt.MapFrom(src => src.Sex))
                .ForMember(d => d.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive ? "Đang hoạt động" : "Đã khóa"));

            CreateMap<UserProfileViewModelEdit, UserProfile>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.Sex, opt => opt.MapFrom(src => src.Sex))
                .ForMember(d => d.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive));
            
            CreateMap<UserProfile, UserProfileViewModelEdit>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.Sex, opt => opt.MapFrom(src => src.Sex))
                .ForMember(d => d.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive));
            
            CreateMap<Producer, ProducerViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(d => d.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive? "Đang hoạt động" : "Đã khóa"))
                .ForMember(d => d.Drugs, opt => opt.MapFrom(src => src.Drugs));
            CreateMap<ProducerViewModelEdit, Producer>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(d => d.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.Drugs, opt => opt.MapFrom(src => src.Drugs));
            CreateMap<Producer, ProducerViewModelEdit>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(d => d.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.Drugs, opt => opt.MapFrom(src => src.Drugs));
            
            CreateMap<GroupDrug, GroupDrugViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive? "Đang hoạt động" : "Đã khóa"))
                .ForMember(d => d.Drugs, opt => opt.MapFrom(src => src.Drugs));
            CreateMap<GroupDrugViewModelEdit, GroupDrug>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.Drugs, opt => opt.MapFrom(src => src.Drugs));
            CreateMap<GroupDrug, GroupDrugViewModelEdit>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.Drugs, opt => opt.MapFrom(src => src.Drugs));
            
            CreateMap<Drug, DrugViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(d => d.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(d => d.DateOfManufacture, opt => opt.MapFrom(src => src.DateOfManufacture))
                .ForMember(d => d.ExpriryDate, opt => opt.MapFrom(src => src.ExpriryDate))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive? "Đang hoạt động" : "Đã khóa"))
                .ForMember(d => d.ProducerId, opt => opt.MapFrom(src => src.ProducerId))
                .ForMember(d => d.ProducerName, opt => opt.MapFrom(src => src.GroupDrug.Name))
                .ForMember(d => d.GroupDrugId, opt => opt.MapFrom(src => src.GroupDrugId))
                .ForMember(d => d.GroupDrugName, opt => opt.MapFrom(src => src.GroupDrug.Name));
            CreateMap<Drug, DrugViewModelEdit>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(d => d.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(d => d.DateOfManufacture, opt => opt.MapFrom(src => src.DateOfManufacture))
                .ForMember(d => d.ExpriryDate, opt => opt.MapFrom(src => src.ExpriryDate))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.ProducerId, opt => opt.MapFrom(src => src.ProducerId))
                .ForMember(d => d.GroupDrugId, opt => opt.MapFrom(src => src.GroupDrugId));
            CreateMap<DrugViewModelEdit, Drug>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(d => d.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(d => d.DateOfManufacture, opt => opt.MapFrom(src => src.DateOfManufacture))
                .ForMember(d => d.ExpriryDate, opt => opt.MapFrom(src => src.ExpriryDate))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.ProducerId, opt => opt.MapFrom(src => src.ProducerId))
                .ForMember(d => d.GroupDrugId, opt => opt.MapFrom(src => src.GroupDrugId));

            CreateMap<ReceiptExport, ReceiptExportViewModelEdit>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.CodeReceipt, opt => opt.MapFrom(src => src.CodeReceipt))
                .ForMember(d => d.DateCreate, opt => opt.MapFrom(src => src.DateCreate))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(d => d.IsPay, opt => opt.MapFrom(src => src.IsPay))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))
                .ForMember(d => d.ProUserProfilefile, opt => opt.MapFrom(src => src.ProUserProfilefile))
                .ForMember(d => d.DetailReceiptExports, opt => opt.MapFrom(src => src.DetailReceiptExports));
            CreateMap<ReceiptExportViewModelEdit, ReceiptExport>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.CodeReceipt, opt => opt.MapFrom(src => src.CodeReceipt))
                .ForMember(d => d.DateCreate, opt => opt.MapFrom(src => src.DateCreate))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(d => d.IsPay, opt => opt.MapFrom(src => src.IsPay))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))
                .ForMember(d => d.ProUserProfilefile, opt => opt.MapFrom(src => src.ProUserProfilefile))
                .ForMember(d => d.DetailReceiptExports, opt => opt.MapFrom(src => src.DetailReceiptExports));

            CreateMap<DetailReceiptExport, DetailReceiptExportViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(d => d.AmountRemaining, opt => opt.MapFrom(src => src.AmountRemaining))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(d => d.ReceiptExportId, opt => opt.MapFrom(src => src.ReceiptExportId));
            CreateMap<DetailReceiptExportViewModel, DetailReceiptExport>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(d => d.AmountRemaining, opt => opt.MapFrom(src => src.AmountRemaining))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(d => d.ReceiptExportId, opt => opt.MapFrom(src => src.ReceiptExportId));

            CreateMap<ReceiptImport, ReceiptImportViewModelEdit>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.CodeReceipt, opt => opt.MapFrom(src => src.CodeReceipt))
                .ForMember(d => d.DateCreate, opt => opt.MapFrom(src => src.DateCreate))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))
                .ForMember(d => d.ProUserProfilefile, opt => opt.MapFrom(src => src.ProUserProfilefile))
                .ForMember(d => d.DetailReceiptImports, opt => opt.MapFrom(src => src.DetailReceiptImports));
            CreateMap<ReceiptImportViewModelEdit, ReceiptImport>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.CodeReceipt, opt => opt.MapFrom(src => src.CodeReceipt))
                .ForMember(d => d.DateCreate, opt => opt.MapFrom(src => src.DateCreate))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))
                .ForMember(d => d.ProUserProfilefile, opt => opt.MapFrom(src => src.ProUserProfilefile))
                .ForMember(d => d.DetailReceiptImports, opt => opt.MapFrom(src => src.DetailReceiptImports));
            
            CreateMap<ReceiptLiquidation, ReceiptLiquidationViewModelEdit>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.CodeReceipt, opt => opt.MapFrom(src => src.CodeReceipt))
                .ForMember(d => d.DateCreate, opt => opt.MapFrom(src => src.DateCreate))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))
                .ForMember(d => d.ProUserProfilefile, opt => opt.MapFrom(src => src.ProUserProfilefile))
                .ForMember(d => d.DetailReceiptLiquidations, opt => opt.MapFrom(src => src.DetailReceiptLiquidations));
            CreateMap<ReceiptLiquidationViewModelEdit, ReceiptLiquidation>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.CodeReceipt, opt => opt.MapFrom(src => src.CodeReceipt))
                .ForMember(d => d.DateCreate, opt => opt.MapFrom(src => src.DateCreate))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))
                .ForMember(d => d.ProUserProfilefile, opt => opt.MapFrom(src => src.ProUserProfilefile))
                .ForMember(d => d.DetailReceiptLiquidations, opt => opt.MapFrom(src => src.DetailReceiptLiquidations));

            CreateMap<DetailReceiptImport, DetailReceiptImportViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));
            CreateMap<DetailReceiptImportViewModel, DetailReceiptImport>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));

            CreateMap<DetailReceiptLiquidation, DetailReceiptLiquidationViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));
            CreateMap<DetailReceiptLiquidationViewModel, DetailReceiptLiquidation>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));
            
            CreateMap<ReceiptExportCreate, ReceiptExport>()
                .ForMember(d => d.CodeReceipt, opt => opt.MapFrom(src => src.CodeReceipt))
                .ForMember(d => d.DateCreate, opt => opt.MapFrom(src => src.DateCreate))
                .ForMember(d => d.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(d => d.IsPay, opt => opt.MapFrom(src => src.IsPay))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(d => d.UserProfileId, opt => opt.MapFrom(src => src.UserProfileId))
                .ForMember(d => d.DetailReceiptExports, opt => opt.MapFrom(src => src.DetailReceiptExportCreates));

            CreateMap<Client, ClientViewModelEdit>()
               .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(d => d.Phone, opt => opt.MapFrom(src => src.Phone))
               .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive));
            CreateMap<ClientViewModelEdit, Client>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(d => d.Phone, opt => opt.MapFrom(src => src.Phone))
               .ForMember(d => d.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}