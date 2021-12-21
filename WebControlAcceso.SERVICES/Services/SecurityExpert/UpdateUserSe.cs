using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.SecurityExpert;

namespace WebControlAcceso.SERVICES.Services.SecurityExpert
{
    public class UpdateUserSe : IUpdateUserSe
    {
        #region Dependencys
        private readonly IDataService<SeInfoDto> _dataServices;
        #endregion

        #region Constructor
        public UpdateUserSe(IDataService<SeInfoDto> data)
        {
            _dataServices = data;
        }
        #endregion

        #region Methods
        public async Task<bool> Update(SeInfoDto seInfoDto, string Url)
        {
            try
            {
                Base.EndPoint = Url;
                var result = await _dataServices.PostBool(seInfoDto);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}
