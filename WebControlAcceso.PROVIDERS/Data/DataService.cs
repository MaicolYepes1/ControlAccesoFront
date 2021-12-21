using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.MODELS.Loads;
using WebControlAcceso.PROVIDERS.Interfaces;

namespace WebControlAcceso.PROVIDERS.Data
{
    public class DataService<T> : IDataService<T>
    {
        public async Task<T> GetParameters(LoginLoad loginLoad)
        {
            try
            {
                var _RestClient = ConexionWebAPis();
                RestRequest request = new RestRequest(Base.EndPoint, Method.POST, DataFormat.Json);

                request.AddParameter("application/json", JsonConvert.SerializeObject(loginLoad), ParameterType.RequestBody);
                T response = await _RestClient.PostAsync<T>(request);

                return response;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<List<T>> PostList(object objrequest)
        {
            try
            {
                var _RestClient = ConexionWebAPis();
                RestRequest request = new RestRequest(Base.EndPoint, Method.POST, DataFormat.Json);
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
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<T> Post(object objrequest = null)
        {
            try
            {
                var _RestClient = ConexionWebAPis();
                RestRequest request = new RestRequest(Base.EndPoint, Method.POST, DataFormat.Json);
                request.Timeout = 10000000;
                if (objrequest != null)
                {
                    request.AddParameter("application/json", JsonConvert.SerializeObject(objrequest), ParameterType.RequestBody);

                    T response = await _RestClient.PostAsync<T>(request);
                    return response;
                }
                else
                {
                    T response = await _RestClient.PostAsync<T>(request);

                    return response;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> PostBool(object objrequest = null)
        {
            try
            {
                var _RestClient = ConexionWebAPis();
                RestRequest request = new RestRequest(Base.EndPoint, Method.POST, DataFormat.Json);
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
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<List<T>> Get(object objrequest = null)
        {
            var _RestClient = ConexionWebAPis();
            RestRequest request = new RestRequest(Base.EndPoint, Method.GET, DataFormat.Json);
            request.Timeout = 10000000;
            if (objrequest == null)
            {
                List<T> response = await _RestClient.GetAsync<List<T>>(request);
                return response;
            }
            else
            {
                request.AddParameter("par", objrequest);
                List<T> response = await _RestClient.GetAsync<List<T>>(request);                
                return response;
            }
        }

        public RestClient ConexionWebAPis()
        {
            RestClient _RestClient = new RestClient(Base.Url);
            return _RestClient;
        }
    }
}
