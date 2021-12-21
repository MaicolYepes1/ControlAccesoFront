using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.PROVIDERS.Interfaces;

namespace WebControlAcceso.PROVIDERS.Data
{
    public class DataServiceSE<T> : IDataServiceSE<T>
    {
        public async Task<List<T>> Get(object objrequest = null)
        {
            var _RestClient = ConexionWebAPis();
            RestRequest request = new RestRequest(Base.EndPoint, Method.GET, DataFormat.Json);
            _RestClient.Authenticator = new HttpBasicAuthenticator("AS Access", "SCOHC-1JQVX-SCGG5-3QI7T-22P12");
            request.Timeout = 10000000;
            if (objrequest == null)
            {
                List<T> response = await _RestClient.GetAsync<List<T>>(request);
                return response;
            }
            else
            {
                List<T> response = await _RestClient.GetAsync<List<T>>(request);
                return response;
            }
        }

        public async Task<List<T>> Post(string url, object objrequest = null)
        {
            var _RestClient = ConexionWebAPis();
            RestRequest request = new RestRequest(url, Method.POST, DataFormat.Json);
            _RestClient.Authenticator = new HttpBasicAuthenticator("AS Access", "SCOHC-1JQVX-SCGG5-3QI7T-22P12");
            request.RequestFormat = DataFormat.Json;
            request.Timeout = 10000000;
            if (objrequest != null)
            {
                request.AddParameter("application/json", JsonConvert.SerializeObject(objrequest), ParameterType.RequestBody);
                List<T> response = await _RestClient.PostAsync<List<T>>(request);
                return response;
            }
            else
            {
                List<T> response = await _RestClient.PostAsync<List<T>>(request);
                return response;
            }
        }
        public async Task<bool> PostBool(object objrequest = null)
        {
            var _RestClient = ConexionWebAPis();
            RestRequest request = new RestRequest(Base.EndPoint, Method.POST, DataFormat.Json);
            _RestClient.Authenticator = new HttpBasicAuthenticator("AS Access", "SCOHC-1JQVX-SCGG5-3QI7T-22P12");
            request.RequestFormat = DataFormat.Json;
            request.Timeout = 10000000;
            if (objrequest != null)
            {
                request.AddParameter("application/json", JsonConvert.SerializeObject(objrequest), ParameterType.RequestBody);
               bool response = await _RestClient.PostAsync<bool>(request);
                return response;
            }
            else
            {
                bool response = await _RestClient.PostAsync<bool>(request);
                return response;
            }
        }
        public RestClient ConexionWebAPis()
        {
            RestClient _RestClient = new RestClient(Base.UrlSE);
            return _RestClient;
        }
    }
}
