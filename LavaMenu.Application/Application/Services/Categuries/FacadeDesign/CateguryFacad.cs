using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Application.Interfaces.FacadeDesignPattern;
using LavaMenu.Application.Application.Services.Categuries.command;
using LavaMenu.Application.Application.Services.Categuries.query;
using LavaMenu.Application.Common.File;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace LavaMenu.Application.Application.Services.Categuries.FacadeDesign
{
    internal class CateguryFacad : ICateguryFacad
    {
        private readonly Idb _db;
        private readonly ILogger<AddCategury> _loggerAddCategury;
        private readonly ILogger<ChangeCateguryStatus> _loggerChangeStatus;
        private readonly IworkFiles _WorkFile;
        private readonly ILogger<GetSingleCategury> _loggerGetSingle;

        private readonly ILogger<EditCateguryService> _loggerEditCategury;
        public CateguryFacad(Idb db,
            ILogger<AddCategury> loggerAddCategury,
            IworkFiles workFiles,
            ILogger<ChangeCateguryStatus> loggerChangeStatus,
            ILogger<GetSingleCategury> loggerGetSingle,
            ILogger<EditCateguryService> loggerEditCategury)
        {
            _db = db;
            _loggerAddCategury = loggerAddCategury;
            _WorkFile = workFiles;
            _loggerChangeStatus = loggerChangeStatus;
            _loggerGetSingle = loggerGetSingle;
            _loggerEditCategury = loggerEditCategury;

        }
        private IAddCategury _addcategury;
        public IAddCategury addCategury
        {
            get
            {
                return _addcategury = _addcategury ?? new AddCategury(_db, _loggerAddCategury, _WorkFile);
            }
        }
        private IChangeCateguryStatus _categuryStatus;
        public IChangeCateguryStatus changeCateguryStatus
        {
            get
            {
                return _categuryStatus = _categuryStatus ?? new ChangeCateguryStatus(_db, _loggerChangeStatus);
            }
        }
        private IGetAllCategureis _getAllCategureis;
        public IGetAllCategureis getAllCategureis
        {
            get
            {
                return _getAllCategureis = _getAllCategureis ?? new GetAllCategury(_db);
            }
        }
        private IGetSingleCategury _getSingleCategury;
        public IGetSingleCategury getSingleCategury
        {
            get
            {
                return _getSingleCategury = _getSingleCategury ?? new GetSingleCategury(_db, _loggerGetSingle);
            }
        }
        private IEditCateguryService _editCategury;
        public IEditCateguryService editCateguryService { 
            get
            {
                return _editCategury = _editCategury ?? new EditCateguryService(_WorkFile,_db,_loggerEditCategury);
            } 
        }
    }
}
